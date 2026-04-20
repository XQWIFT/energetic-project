using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using ProductCatalogForm;

namespace AddProductForm
{
    /// <summary>
    /// Форма добавления товара
    /// </summary>
    public partial class AddProduct : Form
    {
        readonly GenerateUniqueCode generateUniqueCode = new();
        readonly ApplicationContextDB db = new();

        readonly string userLogin;

        /// <summary>
        /// Конструктор добавления товара
        /// </summary>
        public AddProduct(string userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;

            textBoxOfName.TextChanged += IsTextChanged!;
            comboBoxOfCategory.TextChanged += IsTextChanged!;
            textBoxOfPrice.TextChanged += IsTextChanged!;
            comboBoxOfCategory.SelectedIndexChanged += IsTextChanged!;
            comboBoxOfCategory.SelectedIndexChanged += IsComboBoxOfCategoryChanged!;

            LoadCategories();

            comboBoxOfCategory.SelectedIndex = -1;
            ButtonOfAdd.Enabled = false;
        }

        /// <summary>
        /// Загрузка категорий из базы данных
        /// </summary>
        public void LoadCategories()
        {
            comboBoxOfCategory.SelectedIndexChanged -= IsComboBoxOfCategoryChanged!;

            Category.DeleteHiddenCategories(db);

            var categories = db.Categories.Where(u => u.Status == 1).ToList();

            if (categories != null)
            {
                comboBoxOfCategory.DataSource = categories;
                comboBoxOfCategory.DisplayMember = Resources.CategoryDisplayMember;
                comboBoxOfCategory.ValueMember = Resources.CategoryValueMember;

                comboBoxOfCategory.SelectedIndex = -1;
                textBoxOfUnit.Text = string.Empty;

                comboBoxOfCategory.SelectedIndexChanged += IsComboBoxOfCategoryChanged!;
            }
            else
            {
                MessageBox.Show($"{Resources.ErrorCategoryUpload}\n{Resources.TryAgain}",
                Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                                   !string.IsNullOrWhiteSpace(comboBoxOfCategory.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfPrice.Text);

            ButtonOfAdd.Enabled = allFieldsFilled;
        }

        private void IsComboBoxOfCategoryChanged(object sender, EventArgs e)
        {
            if (comboBoxOfCategory.SelectedItem is not Category selectedCategory)
                return;

            var categoryId = selectedCategory.Category_Id;

            var unit = db.Units.FirstOrDefault(u => u.Unit_Id == selectedCategory.Unit_Id);

            if (unit != null)
                textBoxOfUnit.Text = unit.Value.ToString();
            else
                MessageBox.Show($"{Resources.UnitNotFound}\n{Resources.TryAgain}",
                    Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            Close();
        }

        private void ButtonOfAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxOfCategory.SelectedValue == null)
            {
                MessageBox.Show(Resources.ChooseCategoryProduct, Resources.TitleError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /// ... TryParse
            Guid selectedCategoryId = Guid.Parse(comboBoxOfCategory.SelectedValue.ToString()!);
            var product = new Product
            {
                Product_Id = Guid.NewGuid()
            };

            for (int i = 0; i < 100; i++)
            {
                var codes = GenerateUniqueCode.GenerateUniqueProductArticle(db);
                var existingProduct = db.Products.FirstOrDefault(p => p.Article == codes);
                if (existingProduct == null)
                {
                    product.Article = codes;
                    break;
                }
            }

            product.Name = textBoxOfName.Text;
            product.CategoryId = selectedCategoryId;

            /// ... double ?
            //if (double.TryParse(textBoxOfPrice.Text, out var result) && result > 0)
            //{
            //    product.PurchasePrice = result;
            //}
            //else
            //{
            //    MessageBox.Show($"{Resources.UncorrectPrice}\n{Resources.TryAgain}", 
            //                       Resources.TitleError,
            //                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    textBoxOfPrice.Clear();
            //    return;
            //}

            try
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show($"{Resources.UniversalErrorBD}\n{Resources.TryAgain}", Resources.TitleErrorBD,
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            Close();
        }
    }
}
