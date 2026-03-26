using CategoryControl;
using System.ComponentModel;

namespace SelectProductDataForTable
{
    public class ProductDisplayModel
    {
        [DisplayName("Артикул")]
        public string Article { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Категория")] 
        public virtual Category Category { get; set; }
        [DisplayName("Цена (руб.)")]
        public double Price { get; set; }
        [DisplayName("Остаток")]
        public int StockQuantity { get; set; }
        [DisplayName("Единица")]
        public string Unit { get; set; }
    }
}
