using EnergeticProjectX.Enums;
using EnergeticProjectX.Properties;
using System.Runtime.CompilerServices;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс, содержащий методы, которые вызываются при запуске программы.
    /// </summary>
    public static class ApplicationMethod
    {
        public static void Initialize(ApplicationContextDB db)
        {
            CheckConnectionDB();

            DeleteHiddenProducts(db);

            DeleteHiddenCategories(db);
        }

        /// <summary>
        /// Метод для проверки подключения пользователя к базе данных.
        /// </summary>
        private static void CheckConnectionDB()
        {
            var db = new ApplicationContextDB();

            if (!db.Database.CanConnect())
            {
                MessageBox.Show(Resources.ConnectionToDataBaseFailed, Resources.TitleErrorBD,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();
            }
        }

        /// <summary>
        /// Метод для удаления скрытого товара, который не участвует ни в одной ранее совершённой отгрузке.
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        private static void DeleteHiddenProducts(ApplicationContextDB db)
        {
            var hiddenProducts = db.Products.Where(p => p.Status == ProductStatus.Hidden).ToList();

            foreach (var hiddenProduct in hiddenProducts)
            {
                bool participateInShipment = db.ShipmentItems.Any(item => item.Product_Id == hiddenProduct.Product_Id);

                if (!participateInShipment)
                    db.Products.Remove(hiddenProduct);
            }

            ErrorHandler.DBSaveChangesCleanUpHiddenItemsError(db, Resources.CleanUpHiddenProductsError);
        }

        /// <summary>
        /// Метод для удаления скрытых категорий, за которыми не закреплено ни одного товара.
        /// </summary>
        /// <param name="db"></param>
        private static void DeleteHiddenCategories(ApplicationContextDB db)
        {
            var hiddenCategories = db.Categories.Where(u => u.Status == CategoryStatus.Hidden).ToList();

            foreach (var hiddenCategory in hiddenCategories)
            {
                bool hasProducts = db.Products.Any(product => product.CategoryId == hiddenCategory.Category_Id);

                if (!hasProducts)
                    db.Categories.Remove(hiddenCategory);
            }

            ErrorHandler.DBSaveChangesCleanUpHiddenItemsError(db, Resources.CleanUpHiddenCategoriesError);
        }
    }
}
