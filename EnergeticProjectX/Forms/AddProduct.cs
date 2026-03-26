using ClientControl;
using DBControl;
using GeneratedCode;
using ProductCatalogForm;
using ProductControl;

namespace AddProductForm
{
    public partial class AddProduct : Form
    {
        string userLogin;
        public AddProduct(string userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;

            textBoxOfName.TextChanged += isTextChanged!;
            comboBoxOfCategory.TextChanged += isTextChanged!;
            textBoxOfPrice.TextChanged += isTextChanged!;
            comboBoxOfUnit.TextChanged += isTextChanged!;
            comboBoxOfCategory.SelectedIndexChanged += CheckFields!;

            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] Lines = File.ReadAllLines(Path.Combine(baseDir, "Files/UnitProduct.txt"));

            foreach (var item in Lines)
            {
                comboBoxOfUnit.Items.Add(item);
            }

            LoadCategories();

            comboBoxOfCategory.SelectedIndex = -1;
            buttonOfAdd.Enabled = false;

        }

        public void LoadCategories()
        {
            using (var context = new ApplicationContextDB())
            {

                var db = new ApplicationContextDB();
                var categories = db.Categories.ToList();

                if (categories != null)
                {
                    comboBoxOfCategory.DataSource = categories;
                    comboBoxOfCategory.DisplayMember = "Name";
                    comboBoxOfCategory.ValueMember = "CategoryId";
                }
                else
                {
                    MessageBox.Show("Ошибка с загрузкой категорий\nПопробуйте снова!",
                    "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CheckFields(object sender, EventArgs e)
        {
            bool allFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                             comboBoxOfCategory.SelectedItem != null &&
                             !string.IsNullOrWhiteSpace(textBoxOfPrice.Text) &&
                             !string.IsNullOrWhiteSpace(comboBoxOfUnit.Text);

            buttonOfAdd.Enabled = allFilled;
        }

        private void isTextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                                   !string.IsNullOrWhiteSpace(comboBoxOfCategory.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfPrice.Text) &&
                                   !string.IsNullOrWhiteSpace(comboBoxOfUnit.Text);

            buttonOfAdd.Enabled = allFieldsFilled;
        }

        private void buttonOfCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            this.Close();
        }

        private void buttonOfAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxOfCategory.SelectedValue == null)
            {
                MessageBox.Show("Выберите категорию товара!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var generateUniqueCode = new GenerateUniqueCode();
            var db = new ApplicationContextDB();

            int selectedCategoryId = (int)comboBoxOfCategory.SelectedValue!;
            var product = new Product();

            for (int i = 0; i < 100; i++)
            {
                var codes = "K" + generateUniqueCode.Generate6();
                var existingProduct = db.Products.FirstOrDefault(p => p.Article == codes);
                if (existingProduct == null)
                {
                    product.Article = codes;
                    break;
                }
            }
            product.Name = textBoxOfName.Text;
            product.CategoryId = selectedCategoryId;
            if (double.TryParse(textBoxOfPrice.Text, out var result))
            {
                product.Price = result;
            }
            else
            {
                MessageBox.Show("Некорректная цена\nПопробуйте снова!", 
                    "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOfPrice.Clear();
            }
            product.Unit = comboBoxOfUnit.Text;

            db.Products.Add(product);
            db.SaveChanges();

            this.Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            this.Close();
        }
    }
}
