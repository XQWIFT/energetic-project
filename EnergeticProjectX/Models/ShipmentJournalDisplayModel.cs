using System.ComponentModel;

namespace EnergeticProjectX.Models
{
    /// <summary>
    /// Отображение отгрузки в журнале.
    /// </summary>
    public class ShipmentJournalDisplayModel
    {
        /// <summary>
        /// ID отгрузки.
        /// </summary>
        [Browsable(false)]
        public Guid ShipmentId { get; set; }

        /// <summary>
        /// Пользователь, оформивший отгрузку.
        /// </summary>
        [DisplayName("Оформил")]
        public required string UserName { get; set; }

        /// <summary>
        /// Получатель.
        /// </summary>
        [DisplayName("Получатель")]
        public required string ClientName { get; set; }

        /// <summary>
        /// Дата отгрузки.
        /// </summary>
        [DisplayName("Дата")]
        public required DateOnly Date { get; set; }

        /// <summary>
        /// Выручка.
        /// </summary>
        [Browsable(false)]
        public decimal RevenueValue { get; set; }

        /// <summary>
        /// Выручка в строковом эквиваленте.
        /// </summary>
        [DisplayName("Выручка")]
        public required string Revenue { get; set; }

        /// <summary>
        /// Прибыль.
        /// </summary>
        [Browsable(false)]
        public decimal ProfitValue { get; set; }

        /// <summary>
        /// Прибыль в строковом эквиваленте.
        /// </summary>
        [DisplayName("Прибыль")]
        public required string Profit { get; set; }
    }
}