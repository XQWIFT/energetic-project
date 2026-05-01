namespace EnergeticProjectX.Objects;

/// <summary>
/// Позиция поставки (рабочая копия).
/// </summary>
public class DeliveryItemRow
{
    /// <summary>
    /// Артикул выбранного товара.
    /// </summary>
    public string Article { get; set; } = string.Empty;

    /// <summary>
    /// Название выбранного товара.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Количество выбранного товара.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Закупочная цена выбранного товара.
    /// </summary>
    public decimal PurchasePrice { get; set; }

    /// <summary>
    /// Категория выбранного товара.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Единица измерения выбранного товара.
    /// </summary>
    public string Unit { get; set; } = string.Empty;
}