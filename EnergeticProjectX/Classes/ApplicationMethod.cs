using EnergeticProjectX.Objects;

namespace EnergeticProjectX.Classes
{
    /// <summary>
    /// Класс, содержащий методы, которые вызываются при запуске программы
    /// </summary>
    public static class ApplicationMethod
    {
        public static void Initialize(ApplicationContextDB db)
        {
            Category.DeleteHiddenCategories(db);

            Product.DeleteHiddenProducts(db);
        }
    }
}
