using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace EnergeticProjectX.RepositoriesAndServices
{
    public class ProductRepository(ApplicationContextDB db) : IProductRepository
    {
        public Product? GetProductByArticle(string article)
        {
            var product = db.Products.FirstOrDefault(p => p.Article == article);

            return product;
        }

        public string GenerateUniqueProductArticle()
        {
            var maxArticleString = db.Products
                                     .Select(u => u.Article)
                                     .Where(article => !string.IsNullOrWhiteSpace(article))
                                     .OrderByDescending(article => article)
                                     .FirstOrDefault();

            var maxCode = string.IsNullOrEmpty(maxArticleString) ? 0 : int.Parse(maxArticleString![1..]);

            if (maxCode >= 999999)
                throw new InvalidOperationException(Resources.MaxNumberOfProducts);

            return "A" + (maxCode + 1).ToString("D6");
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
        }

        public IQueryable<Product> GetQuery()
        {
            var query = db.Products.AsQueryable();

            return query;
        }

        public List<Product> GetProductsByCategoryId(Guid categoryId)
        {
            var products = db.Products.Where(p => p.CategoryId == categoryId && p.Status == Status.Active).ToList();

            return products;
        }

        public List<Product> GetAvailableProducts()
        {
            var products = db.Products.Where(p => p.Status == Status.Active && p.StockQuantity > 0).ToList();

            return products;
        }

        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
        }

        public List<Category> LoadActiveCategories()
        {
            var categories = db.Categories.Where(u => u.Status == Status.Active).ToList();

            return categories;
        }

        public bool IsCategoryBusy(string categoryName)
        {
            var categoryIsBusy = db.Categories.Any(c => c.Status == Status.Active && EF.Functions.ILike(c.Name, categoryName)) ||
                                 db.Categories.Any(c => c.Status == Status.Active && EF.Functions.ILike(c.Name, Regex.Replace(categoryName, @"\s+", "")) ||
                                 db.Categories.Any(c => c.Status == Status.Active && EF.Functions.ILike(Regex.Replace(c.Name, @"\s+", ""), Regex.Replace(categoryName, @"\s+", ""))));

            return categoryIsBusy;
        }

        public Category? GetCategoryById(Guid categoryId)
        {
            var category = db.Categories.FirstOrDefault(c => c.Category_Id == categoryId);

            return category;
        }

        public Unit? LoadCategoryUnit(Category category)
        {
            var unit = db.Units.FirstOrDefault(u => u.Unit_Id == category.Unit_Id);

            return unit;
        }

        public List<Unit> LoadUnits()
        {
            var units = db.Units.ToList();

            return units;
        }

        public void AddDeliveries(Delivery delivery)
        {
            db.Deliveries.Add(delivery);
        }

        public void AddDeliveryItems(Guid deliveryId, Guid productId, decimal purchaisePrice, int quantity)
        {
            db.DeliveryItems.Add(new DeliveryItems
            {
                Delivery_Id = deliveryId,
                Product_Id = productId,
                PurchasePrice = purchaisePrice,
                Quantity = quantity
            });
        }

        public Shipment? GetShipmentById(Guid shipmentId)
        {
            var shipment = db.Shipments.FirstOrDefault(s => s.Shipment_Id == shipmentId);

            return shipment;
        }

        public IQueryable<Shipment> GetShipmentsInQuery()
        {
            var query = db.Shipments.AsQueryable();

            return query;
        }

        public void AddShipment(Shipment shipment)
        {
            db.Shipments.Add(shipment);
        }

        public List<ShipmentItems> GetShipmentItemsByID(Guid ID)
        {
            var shipmentItems = db.ShipmentItems
                    .Where(si => si.Shipment_Id == ID)
                    .Include(si => si.Product)
                    .ThenInclude(p => p!.Category)
                    .ThenInclude(c => c!.Unit)
                    .ToList();

            return shipmentItems;
        }

        public void AddShipmentItems(Guid shipmentId, Guid productId, decimal fixedPurchasePrice,
            decimal fixedSalePrice, int quantity)
        {
            db.ShipmentItems.Add(new ShipmentItems
            {
                Shipment_Id = shipmentId,
                Product_Id = productId,
                FixedPurchasePrice = fixedPurchasePrice,
                FixedSalePrice = fixedSalePrice,
                Quantity = quantity
            });
        }
    }
}