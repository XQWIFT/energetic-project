using System.Text.Json.Serialization;

namespace EnergeticProjectX.Services
{
    /// <summary>
    /// Информация о валюте из API Центрального Банка РФ.
    /// </summary>
    public class CbrCurrency
    {
        /// <summary>
        /// Id Валюты.
        /// </summary>
        [JsonPropertyName("ID")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Трехзначный числовой идентификатор денежной единицы.
        /// </summary>
        [JsonPropertyName("NumCode")]
        public string NumCode { get; set; } = string.Empty;

        /// <summary>
        /// Уникальное трехбуквенное обозначение денежной единицы.
        /// </summary>
        [JsonPropertyName("CharCode")]
        public string CharCode { get; set; } = string.Empty;

        /// <summary>
        /// Номинал.
        /// </summary>
        [JsonPropertyName("Nominal")]
        public int Nominal { get; set; }

        /// <summary>
        /// Название валюты.
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Актуальный курс валюты.
        /// </summary>
        [JsonPropertyName("Value")]
        public decimal Value { get; set; }

        /// <summary>
        /// Курс валюты на предыдущую дату.
        /// </summary>
        [JsonPropertyName("Previous")]
        public decimal Previous { get; set; }
    }
}