using EditProductForms;
using ProductCatalogForm;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Classes;

namespace ProductManagementForms
{
    /// <summary>
    /// Форма для изменения товара: изменение и удаление
    /// </summary>
    public partial class ProductManagement : Form
    {
        ApplicationContextDB db = new();

        string Article;
        string userLogin;

        /// <summary>
        /// Конструктор для изменения товара
        /// </summary>
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
            DialogResult result = MessageBox.Show(Resources.AskForDeleteProduct,
                Resources.ConfirmationDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Question); 

            if (result == DialogResult.Yes)
            {
                var product = db.Products.FirstOrDefault(u => u.Article == Article);

                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();

                    MessageBox.Show(Resources.SuccessDeleteProduct, Resources.TitleSuccess,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    var productCatalog = new ProductCatalog(userLogin);
                    productCatalog.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Resources.ProductNotFound, Resources.TitleError,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
