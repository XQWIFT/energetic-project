using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Services;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс, содержащий методы, которые вызываются при запуске программы.
    /// </summary>
    public static class ApplicationMethod
    {
        public static void Initialize(ApplicationContextDB db)
        {
            CheckConnectionDB(db);

            CheckAndUpdateRates(db);

            DeleteHiddenProducts(db);

            DeleteHiddenCategories(db);
        }

        /// <summary>
        /// Метод для проверки подключения пользователя к базе данных.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        public static void CheckConnectionDB(this ApplicationContextDB db)
        {
            if (!db.Database.CanConnect())
            {
                EH.ShowError(Resources.ConnectionToDataBaseFailed);
            }
        }

        /// <summary>
        /// Метод для удаления скрытого товара, который не участвует ни в одной ранее совершённой отгрузке.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        private static void DeleteHiddenProducts(ApplicationContextDB db)
        {
            var hiddenProducts = db.Products.Where(p => p.Status == ProductStatus.Hidden).ToList();

            foreach (var hiddenProduct in hiddenProducts)
            {
                var participateInShipment = db.ShipmentItems.Any(item => item.Product_Id == hiddenProduct.Product_Id);

                if (!participateInShipment)
                    db.Products.Remove(hiddenProduct);
            }

            EH.DBSaveChangesCleanUpHiddenItemsError(db, Resources.CleanUpHiddenProductsError);
        }

        /// <summary>
        /// Метод для удаления скрытых категорий, за которыми не закреплено ни одного товара.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        private static void DeleteHiddenCategories(ApplicationContextDB db)
        {
            var hiddenCategories = db.Categories.Where(u => u.Status == CategoryStatus.Hidden).ToList();

            foreach (var hiddenCategory in hiddenCategories)
            {
                var hasProducts = db.Products.Any(product => product.CategoryId == hiddenCategory.Category_Id);

                if (!hasProducts)
                    db.Categories.Remove(hiddenCategory);
            }

            EH.DBSaveChangesCleanUpHiddenItemsError(db, Resources.CleanUpHiddenCategoriesError);
        }

        /// <summary>
        /// Метод для проверки и обновления курсов валют.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        private static void CheckAndUpdateRates(ApplicationContextDB db)
        {
            try
            {
                var lastUpdate = db.Currencies.Max(c => c.DataOfUpdate);

                if (ExchangeRateService.ShouldUpdateRates(lastUpdate, TimeSpan.FromMinutes(1)))
                {
                    EH.ShowInformation($"{Resources.UploadingExchangeRates}\n\n{Resources.PleaseWait}");

                    var currencyRUB = db.Currencies.FirstOrDefault(c => c.Code == "RUB");

                    currencyRUB!.DataOfUpdate = DateTime.UtcNow;

                    var updated = ExchangeRateService.UpdateRatesFromCbr(db);

                    if (updated > 0)
                    {
                        EH.ShowInformation($"{Resources.ExchangeRatesUploaded}\n\n{Resources.HowMuchExchangeRatesUploaded} {updated}");
                    }
                }
            }
            catch (Exception)
            {
                EH.ShowWarning($"{Resources.NotManagedToUploadExchangeRates}\n\n{Resources.ApplicationWillContinue}");
            }
        }
    }
}
