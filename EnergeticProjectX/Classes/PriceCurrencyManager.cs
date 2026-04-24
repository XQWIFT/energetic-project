using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using System.Globalization;
using System.IO.Packaging;

namespace EnergeticProjectX.Classes
{

    /// <summary>
    /// Класс, содержащий методы, которые определяют взаимосвязь цены, курса валюты и формы записи для UI.
    /// </summary>
    public class PriceCurrencyManager
    {
        private const decimal MaxPurchasePriceValue = 99999999.99m;
        private const decimal MinPurchasePriceValue = 0m;

        /// <summary>
        /// Приведение цены к заданному формату относительно курса валюты.
        /// Формат: XXX.XXX.XX + курс валюты
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        /// <param name="priceInChosenCurrency">Цена для форматирования, выраженная в выбранной у пользователя валюте</param>
        /// <returns>При успешном форматировании выводится цена с округлением до двух знаков после запятой и точкой в качестве
        /// разделителя</returns>
        public static string PriceToCorrectFormat(ApplicationContextDB db, decimal priceInChosenCurrency, string userLogin)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            if (user == null)
                return string.Empty;

            var currency = db.Currencies.FirstOrDefault(c => c.Currency_Id == user.CurrencyId);

            if (currency == null)
                return string.Empty;

            var numberFormatInfo = new NumberFormatInfo()
            {
                NumberGroupSeparator = " ",
                NumberDecimalSeparator = ",",
                NumberDecimalDigits = 2
            };

            return priceInChosenCurrency.ToString("N", numberFormatInfo) + " " + currency.CurrencySymbol;
        }

        /// <summary>
        /// Метод для проверки введённой пользователем закупочной цены на конвертацию в число с плавающей точкой и положительность.
        /// </summary>
        /// <param name="purchasePriceString">Закупочная цена</param>
        /// <returns>При прохождении валидации выводится число с плавающей точкой, иначе - null.</returns>
        public static decimal? ValidatePurchasePrice(string purchasePriceString)
        {
            if (string.IsNullOrEmpty(purchasePriceString))
            {
                MessageBox.Show(Resources.WaitingToEnterThePrice, Resources.TitleAlert,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return null;
            }

            if (!decimal.TryParse(purchasePriceString, out decimal purchasePrice))
            {
                var isAllDigits = purchasePriceString.All(c => char.IsDigit(c) || c == ',' || c == '.');

                if (isAllDigits)
                    MessageBox.Show($"{Resources.PurchasePriceOverflowExc}.\n{Resources.TryAgain}", Resources.TitleWarning,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show($"{Resources.PurchasePriceIsSupposedToBeNumber}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            else if (purchasePrice <= MinPurchasePriceValue)
            {
                MessageBox.Show($"{Resources.PurchasePriceIsNegative}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            else if (purchasePrice > MaxPurchasePriceValue)
            {
                MessageBox.Show($"{Resources.PurchasePriceOverflowExc}.\n{Resources.TryAgain}", Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return null;
            }
            else
                return purchasePrice;
        }

        /// <summary>
        /// Метод для получения цены продажи товара в рублях относительно закупочной цены в рублях.
        /// </summary>
        /// <param name="purchasePriceInDefaultCurrency">Закупочная цена товара в рублях</param>
        /// <returns>Цена продажи товара в рублях</returns>
        public static decimal GetSalePriceInDefaultCurrency(decimal purchasePriceInDefaultCurrency)
        {
            return Math.Round(Product.priceIncreaseCoefficient * purchasePriceInDefaultCurrency, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Метод для переопределения любой цены в заданной валюте в рубли.
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        /// <param name="price"></param>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public static decimal SetPriceToDefaultCurrency(ApplicationContextDB db, decimal price, string userLogin)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            var chosenCurrency = db.Currencies.FirstOrDefault(c => c.Currency_Id == user!.CurrencyId);

            var priceInDefaultCurrency = Math.Round((decimal)chosenCurrency!.ExchangeRate * price, 2, MidpointRounding.AwayFromZero);

            return priceInDefaultCurrency;
        }

        /// <summary>
        /// Метод для переопределения цены в рублях в эквивалент в выбранной пользователем валюте.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="priceInDefaultCurrency"></param>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public static decimal SetPriceToChosenCurrency(ApplicationContextDB db, decimal priceInDefaultCurrency, string userLogin)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);

            var chosenCurrency = db.Currencies.FirstOrDefault(c => c.Currency_Id == user!.CurrencyId);

            var priceInChosenCurrency = Math.Round(priceInDefaultCurrency / (decimal)chosenCurrency!.ExchangeRate, 2, MidpointRounding.AwayFromZero);

            return priceInChosenCurrency;
        }
    }
}
