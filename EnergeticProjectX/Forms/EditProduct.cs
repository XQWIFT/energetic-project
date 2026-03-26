using CategoryControl;
using DBControl;
using ProductCatalogForm;
using ProductControl;

namespace EditProductForms
{
    public partial class EditProduct : Form
    {
        string userLogin;
        string article;
        private Product currentProduct;

        public EditProduct(string userLogin, string article)
        {
            InitializeComponent();
            this.userLogin = userLogin;
            this.article = article;

            LoadProductData();

            textBoxOfName.TextChanged += isTextChanged!;
            comboBoxOfCategory.TextChanged += isTextChanged!;
            textBoxOfPrice.TextChanged += isTextChanged!;
            comboBoxOfUnit.TextChanged += isTextChanged!;
            comboBoxOfCategory.SelectedIndexChanged += CheckFields!;

            LoadUnits();

            LoadCategories();

            buttonOfSaveChanges.Enabled = false;
        }

        private void LoadProductData()
        {
            try
            {
                using (var context = new ApplicationContextDB())
                {
                    currentProduct = context.Products
                        .FirstOrDefault(p => p.Article == article)!;

                    if (currentProduct != null)
                    {
                        textBoxOfName.Text = currentProduct.Name;
                        textBoxOfPrice.Text = currentProduct.Price.ToString();
                        comboBoxOfUnit.Text = currentProduct.Unit;
                    }
                    else
                    {
                        MessageBox.Show("Товар не найден!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Загрузка категорий из базы данных
        /// </summary>
        public void LoadCategories()
        {
            try
            {
                using (var context = new ApplicationContextDB())
                {
                    var categories = context.Categories.ToList();

                    if (categories != null && categories.Any())
                    {
                        comboBoxOfCategory.DataSource = categories;
                        comboBoxOfCategory.DisplayMember = "Name";
                        comboBoxOfCategory.ValueMember = "CategoryId";

                        if (currentProduct != null)
                        {
                            comboBoxOfCategory.SelectedValue = currentProduct.CategoryId;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка с загрузкой категорий\nПопробуйте снова!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки категорий: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HasChanges()
        {
            if (currentProduct == null) return false;

            bool nameChanged = textBoxOfName.Text != currentProduct.Name;

            bool categoryChanged = false;
            if (comboBoxOfCategory.SelectedItem != null)
            {
                var selectedCategory = comboBoxOfCategory.SelectedItem as Category;
                if (selectedCategory != null)
                {
                    categoryChanged = selectedCategory.CategoryId != currentProduct.CategoryId;
                }
            }

            bool priceChanged = false;
            if (double.TryParse(textBoxOfPrice.Text, out double newPrice))
            {
                priceChanged = Math.Abs(newPrice - currentProduct.Price) > 0.01;
            }

            bool unitChanged = comboBoxOfUnit.Text != currentProduct.Unit;

            return nameChanged || categoryChanged || priceChanged || unitChanged;
        }

        private void LoadUnits()
        {
            try
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string[] Lines = File.ReadAllLines(Path.Combine(baseDir, "Files/UnitProduct.txt"));

                comboBoxOfUnit.Items.Clear();
                foreach (var item in Lines)
                {
                    comboBoxOfUnit.Items.Add(item);
                }

                if (!string.IsNullOrEmpty(currentProduct?.Unit))
                {
                    comboBoxOfUnit.Text = currentProduct.Unit;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки единиц измерения: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckFields(object sender, EventArgs e)
        {
            bool allFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                             comboBoxOfCategory.SelectedItem != null &&
                             !string.IsNullOrWhiteSpace(textBoxOfPrice.Text) &&
                             !string.IsNullOrWhiteSpace(comboBoxOfUnit.Text);

            buttonOfSaveChanges.Enabled = allFilled && HasChanges();
        }

        private void isTextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(textBoxOfName.Text) &&
                                   !string.IsNullOrWhiteSpace(comboBoxOfCategory.Text) &&
                                   !string.IsNullOrWhiteSpace(textBoxOfPrice.Text) &&
                                   !string.IsNullOrWhiteSpace(comboBoxOfUnit.Text);

            buttonOfSaveChanges.Enabled = allFieldsFilled && HasChanges();
        }

        private void buttonOfSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxOfCategory.SelectedValue == null)
                {
                    MessageBox.Show("Выберите категорию товара!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var context = new ApplicationContextDB())
                {
                    var productToUpdate = context.Products
                        .FirstOrDefault(p => p.Article == article);

                    if (productToUpdate != null)
                    {
                        productToUpdate.Name = textBoxOfName.Text;
                        productToUpdate.CategoryId = (int)comboBoxOfCategory.SelectedValue;

                        if (double.TryParse(textBoxOfPrice.Text, out double price))
                        {
                            productToUpdate.Price = price;
                        }
                        else
                        {
                            MessageBox.Show("Некорректная цена\nПопробуйте снова!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxOfPrice.Clear();
                            return;
                        }

                        productToUpdate.Unit = comboBoxOfUnit.Text;

                        context.SaveChanges();

                        MessageBox.Show("Товар успешно обновлён!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        var productCatalog = new ProductCatalog(userLogin);
                        productCatalog.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Товар не найден в базе данных!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOfCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите отменить редактирование?\nВсе несохранённые изменения будут потеряны.",
                "Подтверждение отмены",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                var productCatalog = new ProductCatalog(userLogin);
                productCatalog.ShowDialog();
                this.Close();
            }
        }
    }
}