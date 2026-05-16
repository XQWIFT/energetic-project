using EnergeticProjectX.Objects;

namespace EnergeticProjectX.Interfaces
{
    public interface IProductRepository
    {
        public Product? GetProductByArticle(string article);

        public string GenerateUniqueProductArticle();

        public void AddProduct(Product product);

        public IQueryable<Product> GetQuery();

        public List<Product> GetAvailableProducts();

        public List<Product> GetProductsByCategoryId(Guid categoryId);

        public void AddCategory(Category category);

        public List<Category> LoadActiveCategories();

        public bool IsCategoryBusy(string categoryName);

        public Category? GetCategoryById(Guid iD);

        public Unit? LoadCategoryUnit(Category category);

        public List<Unit> LoadUnits();

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
