using System.Text.Json.Serialization;

namespace EnergeticProjectX.Services
{
    /// <summary>
    /// Корневой объект ответа API Центрального Банка РФ.
    /// </summary>
    public class CbrResponse
    {
        /// <summary>
        /// Дата.
        /// </summary>
        [JsonPropertyName("Date")]
        public string Date { get; set; } = string.Empty;

        /// <summary>
        /// Словарь по значениям название - валюта.
        /// </summary>
        [JsonPropertyName("Valute")]
        public Dictionary<string, CbrCurrency> Valute { get; set; } = [];
    }
}
