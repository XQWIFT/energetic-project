using EditProductForms;
using ProductCatalogForm;
using DBControl;

namespace ProductManagementForms
{
    public partial class ProductManagement : Form
    {
        string Article;
        string userLogin;
        public ProductManagement(string userLogin, string Article)
        {
            InitializeComponent();
            this.userLogin = userLogin;
            this.Article = Article;
        }

        private void buttonOfCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            this.Close();
        }

        private void buttonOfEditProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            var editProduct = new EditProduct(userLogin, Article);
            editProduct.ShowDialog();
            this.Close();
        }

        private void buttonOfDeleteProduct_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить этот товар?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question); 

            if (result == DialogResult.Yes)
            {
                var db = new ApplicationContextDB();

                var product = db.Products.FirstOrDefault(u => u.Article == Article);

                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();

                    MessageBox.Show("Товар успешно удален!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    var productCatalog = new ProductCatalog(userLogin);
                    productCatalog.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Товар не найден!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
