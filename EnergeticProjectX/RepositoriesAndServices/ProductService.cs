using EnergeticProjectX.interfaces;
using EnergeticProjectX.Interfaces;
using EnergeticProjectX.Objects;
using System.Globalization;

namespace EnergeticProjectX.RepositoriesAndServices
{
    public class ProductService(IProductRepository repository, IUserService userService) : IProductService
    {
        private readonly IProductRepository _repository = repository;

        private readonly IUserService _userService = userService;

        public Product? GetProductByArticle(string article)
        {
            var product = _repository.GetProductByArticle(article);

            return product;
        }

        public string GenerateUniqueProductArticle()
        {
            var article = _repository.GenerateUniqueProductArticle();

            return article;
        }

        public void AddProduct(Product product)
        {
            _repository.AddProduct(product);
        }

        public List<Product> GetProductsByCategoryId(Guid categoryId)
        {
            var products = _repository.GetProductsByCategoryId(categoryId).ToList();

            return products;
        }

        public IQueryable<Product> GetQueryProducts()
        {
            var query = _repository.GetQuery();
            return query;
        }

        public List<Product> GetAvailableProducts()
        {
            var products = _repository.GetAvailableProducts();
            return products;
        }

        public decimal SetPriceToChosenCurrency(decimal priceInDefaultCurrency, string userLogin)
        {
            var user = _userService.FindByLogin(userLogin);

            var chosenCurrency = _userService.FindUserChosenCurrency(user);

            var priceInChosenCurrency = Math.Round(priceInDefaultCurrency / chosenCurrency!.ExchangeRate, 2, MidpointRounding.AwayFromZero);

            return priceInChosenCurrency;
        }

        public string PriceToCorrectFormat(decimal priceInChosenCurrency, string userLogin)
        {
            var user = _userService.FindByLogin(userLogin);
            if (user == null)
                return string.Empty;

            var currency = _userService.FindUserChosenCurrency(user);

            if (currency == null)
                return string.Empty;

            var numberFormatInfo = new NumberFormatInfo()
            {
                NumberGroupSeparator = " ",
                NumberDecimalSeparator = ",",
                NumberDecimalDigits = 2
            };

            return priceInChosenCurrency.ToString("N", numberFormatInfo) + " " + currency.CurrencySymbol;
        }

        public void AddCategory(Category category)
        {
            _repository.AddCategory(category);
        }

        public Category? GetCategoryById(Guid categoryId)
        {
            var category = _repository.GetCategoryById(categoryId);

            return category;
        }

        public Unit? LoadCategoryUnit(Category category)
        {
            var unit = _repository.LoadCategoryUnit(category);

            return unit;
        }

        public List<Category> GetCategories()
        {
            var categories = _repository.LoadActiveCategories();
            return categories;
        }

        public List<Unit> GetUnits()
        {
            var units = _repository.LoadUnits();

            return units;
        }

        public bool IsCategoryNameBusy(string categoryName)
        {
            if (_repository.IsCategoryBusy(categoryName))
                return true;
            else
                return false;
        }

        public void AddDeliveries(Delivery delivery)
        {
            _repository.AddDeliveries(delivery);
        }

        public void AddDeliveryItems(Guid deliveryId, Guid productId, decimal purchaisePrice, int quantity)
        {
            _repository.AddDeliveryItems(deliveryId, productId, purchaisePrice, quantity);
        }

        public Shipment? GetShipmentById(Guid shipmentId)
        {
            var shipment = _repository.GetShipmentById(shipmentId);

            return shipment;
        }

        public IQueryable<Shipment> GetShipmentsInQuery()
        {
            var query = _repository.GetShipmentsInQuery();
            return query;
        }

        public void AddShipment(Shipment shipment)
        {
            _repository.AddShipment(shipment);
        }

        public List<ShipmentItems> GetShipmentItemsByID(Guid ID)
        {
            var items = _repository.GetShipmentItemsByID(ID);
            return items;
        }

        public void AddShipmentItems(Guid shipmentId, Guid productId, decimal fixedPurchasePrice,
            decimal fixedSalePrice, int quantity)
        {
            _repository.AddShipmentItems(shipmentId, productId, fixedPurchasePrice, fixedSalePrice, quantity);
        }
    }
}