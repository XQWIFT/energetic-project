using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using EnergeticProjectX.Classes;

namespace EnergeticProjectX.Objects
{
    /// <summary>
    /// Создаётся категория
    /// </summary>
    [Table("Categories")]
    public class Category
    {
        /// <summary>
        /// Уникальный ID категории
        /// </summary>
        [Key]
        [Column("Id")]
        public Guid Category_Id { get; set; }

        /// <summary>
        /// Название категории (например, «Ноутбуки», «Смартфоны»)
        /// </summary>
        [Column("Name")]
        public required string Name { get; set; }

        /// <summary>
        /// Статус категории (0 - категория скрыта или удалена пользователем; 1 - отображается). 
        /// Однако если не существует товара, за которым закрепляется категория
        /// и при этом она скрыта, то данная категория удаляется безвозвратно
        /// </summary>
        [Column("Status")]
        public int Status { get; set; }

        /// <summary>
        /// Ссылка на единицу измерения
        /// </summary>
        [ForeignKey(nameof(Unit))]
        [Column("UnitId")]
        public Guid Unit_Id { get; set; }

        /// <summary>
        /// Навигационное свойство: единица измерения
        /// </summary>
        public virtual Unit? Unit { get; set; }

        /// <summary>
        /// Метод для удаления скрытых категорий, за которыми не закреплено ни одного товара
        /// </summary>
        /// <param name="db"></param>
        public static void DeleteHiddenCategories(ApplicationContextDB db)
        {
            var hiddenCategories = db.Categories.Where(u => u.Status == 0).ToList();

            foreach (var hiddenCategory in hiddenCategories)
            {
                bool hasProducts = db.Products.Any(product => product.CategoryId == hiddenCategory.Category_Id);

                if (!hasProducts)
                    db.Categories.Remove(hiddenCategory);

                // Также потенциальная реализация:
                //var productsRelatedToHiddenCategory = db.Products.Where
                //    (u => u.CategoryId == hiddenCategory.Category_Id).ToList();

                //if (productsRelatedToHiddenCategory.Count == 0)
                //    db.Categories.Remove(hiddenCategory);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка очистки скрытых категорий: {ex}");
            }
        }
    }
}
