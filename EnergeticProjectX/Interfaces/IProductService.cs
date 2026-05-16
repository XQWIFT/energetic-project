using EnergeticProjectX.Objects;

namespace EnergeticProjectX.Interfaces
{
    public interface IProductService
    {
        public Product? GetProductByArticle(string article);

        public string GenerateUniqueProductArticle();

        public void AddProduct(Product product);

        public List<Product> GetProductsByCategoryId(Guid categoryId);

        IQueryable<Product> GetQueryProducts();

        public List<Product> GetAvailableProducts();

        public decimal SetPriceToChosenCurrency(decimal priceInDefaultCurrency, string userLogin);

        public string PriceToCorrectFormat(decimal priceInChosenCurrency, string userLogin);

        public void AddCategory(Category category);

        public Category? GetCategoryById(Guid iD);

        public Unit? LoadCategoryUnit(Category category);

        public List<Category> GetCategories();

        public List<Unit> GetUnits();

        public bool IsCategoryNameBusy(string categoryName);

        public void AddDeliveries(Delivery delivery);

        public void AddDeliveryItems(Guid deliveryId, Guid productId, decimal purchaisePrice, int quantity);

        public Shipment? GetShipmentById(Guid ID);

        public IQueryable<Shipment> GetShipmentsInQuery();

        public void AddShipment(Shipment shipment);

        public List<ShipmentItems> GetShipmentItemsByID(Guid ID);

        public void AddShipmentItems(Guid Shipment_Id, Guid Product_Id, decimal FixedPurchasePrice,
            decimal FixedSalePrice, int Quantity);
    }
}
