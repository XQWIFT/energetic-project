using EH = EnergeticProjectX.Classes.ErrorHandler;
using System.Text.Json;
using EnergeticProjectX.Classes;

namespace EnergeticProjectX.Services
{
    /// <summary>
    /// Сервис для получения и обновления курсов валют с сайта ЦБ РФ.
    /// </summary>
    public static class ExchangeRateService
    {
        private const string CBR_API_URL = "https://www.cbr-xml-daily.ru/daily_json.js";

        /// <summary>
        /// Получение актуальных курсов валют с ЦБ РФ и обновление в базе данных.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        /// <returns>Количество обновлённых валют.</returns>
        public static int UpdateRatesFromCbr(ApplicationContextDB db)
        {
            try
            {
                LoggerService.Debug("Начало обновления курсов валют с ЦБ РФ.");

                var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
                var json = httpClient.GetStringAsync(CBR_API_URL).Result;

                var response = JsonSerializer.Deserialize<CbrResponse>(json);

                if (response?.Valute == null || response.Valute.Count == 0)
                {
                    LoggerService.Warning("Ответ не поступил или произошла ошибка при конвертации.");

                    return 0;
                }

                LoggerService.Debug($"Получено курсов из ЦБ: {response.Valute.Count}");

                var allCurrencies = db.Currencies.ToList();

                var updatedCount = 0;
                var updateDate = DateTime.UtcNow;

                foreach (var cbrCurrency in response.Valute.Values)
                {
                    var matchedCurrency = allCurrencies.FirstOrDefault(c =>
                        c.Code?.Equals(cbrCurrency.CharCode, StringComparison.OrdinalIgnoreCase) == true);

                    if (matchedCurrency != null)
                    {
                        matchedCurrency.ExchangeRate = cbrCurrency.Value / cbrCurrency.Nominal;
                        matchedCurrency.DataOfUpdate = updateDate;
                        updatedCount++;

                        LoggerService.Debug($"Обновлён курс {cbrCurrency.CharCode}: " +
                                           $"{cbrCurrency.Value} / {cbrCurrency.Nominal} = " +
                                           $"{matchedCurrency.ExchangeRate:F4}");
                    }
                }

                if (updatedCount > 0)
                {
                    if (EH.DBSaveChangesUniversalErrorCheck(db))
                        return 0;

                    LoggerService.Info($"Курсы валют обновлены. Количество обновлённых валют: {updatedCount}. Дата: {updateDate:dd.MM.yyyy HH:mm}");
                }
                else
                {
                    LoggerService.Warning("Не найдено совпадений валют между данными от Центробанка и базой данных.");
                }

                return updatedCount;
            }
            catch (Exception ex)
            {
                LoggerService.Error("Необработанная ошибка при обновлении курсов", ex);
                return 0;
            }
        }

        /// <summary>
        /// Проверка, нужно ли обновлять курс валют.
        /// </summary>
        public static bool ShouldUpdateRates(DateTime? lastUpdate, TimeSpan updateInterval)
        {
            if (lastUpdate == null) return true;

            var timeSinceUpdate = DateTime.UtcNow - lastUpdate.Value;

            return timeSinceUpdate > updateInterval;
        }
    }
}