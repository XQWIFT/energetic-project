using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using ProductCatalogForm;
using EnergeticProjectX.Classes;

namespace AddCategoryForm
{
    /// <summary>
    /// Класс для добавления новой категории
    /// </summary>
    public partial class AddCategory : Form
    {
        /// <summary>
        /// Логин пользователя который управляет программой
        /// </summary>
        private readonly string userLogin;

        private readonly ApplicationContextDB db = new();

        /// <summary>
        /// Основной конструктор добавления новой категории 
        /// </summary>
        public AddCategory(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            TextBoxForName.TextChanged += IsTextChanged!;
            ComboBoxOfUnit.TextChanged += IsTextChanged!;
            ComboBoxOfUnit.SelectedIndexChanged += IsTextChanged!;

            LoadUnits();

            ComboBoxOfUnit.SelectedIndex = -1;
        }

        /// <summary>
        /// Загрузка единиц измерения
        /// </summary>
        public void LoadUnits()
        {
            var units = db.Units.ToList();

            if (units != null && units.Count != 0)
            {
                ComboBoxOfUnit.DataSource = units;
                ComboBoxOfUnit.DisplayMember = Resources.UnitDisplayMember;
                ComboBoxOfUnit.ValueMember = Resources.UnitValueMember;
            }
            else
            {
                MessageBox.Show(Resources.ErrorUnitUpload + $"\n{Resources.TryAgain}",
                                Resources.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = !string.IsNullOrWhiteSpace(TextBoxForName.Text) &&
                             !string.IsNullOrWhiteSpace(ComboBoxOfUnit.Text);

            ButtonOfAddCategory.Enabled = allFieldsFilled;
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            Close();
        }

        private void ButtonOfAddCategory_Click(object sender, EventArgs e)
        {
            if (ComboBoxOfUnit.SelectedValue == null)
            {
                MessageBox.Show(Resources.ChooseUnit, Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            Guid selectedUnitId = (Guid)ComboBoxOfUnit.SelectedValue;

            var newCategory = new Category
            {
                Category_Id = Guid.NewGuid(),
                Name = TextBoxForName.Text.Trim(),
                Status = 1,
                Unit_Id = selectedUnitId
            };

            try
            {
                db.Categories.Add(newCategory);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.ErrorSaveCategory}\n{Resources.TryAgain}" +
                                $"Текст ошибки: {ex.Message}",Resources.TitleErrorBD, 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            MessageBox.Show(Resources.SuccessAddCategory, Resources.TitleSuccess,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            Close();
        }
    }
}
