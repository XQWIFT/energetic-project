using EnergeticProjectX.Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Создаётся продукт
    /// </summary>
    [Table("Products")]
    public class Product
    {
        /// <summary>
        /// Уникальный ID товара 
        /// </summary>
        [Key]
        [Column("Id")]
        public Guid Product_Id { get; set; }

        /// <summary>
        /// Артикул товара (формат: буква A + 6 цифр)
        /// </summary>
        [Column("Article")]
        public string? Article { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        [Column("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// Ссылка на категорию товара
        /// </summary>
        [ForeignKey(nameof(Category))]
        [Column("CategoryId")]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Навигационное свойство: категория товара
        /// </summary>
        public virtual Category? Category { get; set; }

        /// <summary>
        /// Цена закупки товара
        /// </summary>
        [Column("PurchasePrice")]
        public string? PurchasePrice { get; set; }

        /// <summary>
        ///  Цена продажи товара
        /// </summary>
        [Column("SalePrice")]
        public string? SalePrice { get; set; }

        /// <summary>
        /// Текущий остаток товара на складе
        /// </summary>
        [Column("StockQuantity")]
        public int StockQuantity { get; set; } = 0;

        /// <summary>
        /// Дата создания карточки нового товара
        /// </summary>
        [Column("CreationDate")]
        public string? CreationDate { get; set; }

        /// <summary>
        /// Дата назначения скидки для товара
        /// </summary>
        [Column("DiscountDate")]
        public string? DiscountDate { get; set; }

        /// <summary>
        /// Статус товара (0 - товар скрыт или удалён пользователем; 1 - отображается). 
        /// Однако если скрытый товар не участвует ни в одной ранее совершённой
        /// отгрузке, товар удаляется из базы данных окончательно
        /// </summary>
        [Column("Status")]
        public int? Status { get; set; } = 1;

        /// <summary>
        /// Метод для удаления скрытого товара, который не участвует ни в одной ранее совершённой отгрузке
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        public static void DeleteHiddenProducts(ApplicationContextDB db)
        {
            var hiddenProducts = db.Products.Where(p => p.Status == 0).ToList();

            foreach (var hiddenProduct in hiddenProducts)
            {
                bool participateInShipment = db.ShipmentItems.Any(item => item.Product_Id == hiddenProduct.Product_Id);

                if (!participateInShipment)
                    db.Products.Remove(hiddenProduct);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка очистки скрытого товара: {ex}");
            }
        }
    }
}
