using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;
using Microsoft.EntityFrameworkCore;
using ProductCatalogForm;

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

            LoadUnits(db, ComboBoxOfUnit);

            ComboBoxOfUnit.SelectedIndex = -1;
        }

        /// <summary>
        /// Загрузка единиц измерений в выпадающий список
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        /// <param name="comboBoxName">Название выпадающего списка</param>
        public static void LoadUnits(ApplicationContextDB db, ComboBox comboBoxName)
        {
            var units = db.Units.ToList();

            if (units != null && units.Count != 0)
            {
                comboBoxName.DataSource = units;
                comboBoxName.DisplayMember = Resources.UnitDisplayMember;
                comboBoxName.ValueMember = Resources.UnitValueMember;
            }
            else
            {
                MessageBox.Show($"{Resources.ErrorUnitUpload}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            var allFieldsFilled = !string.IsNullOrWhiteSpace(TextBoxForName.Text) &&
                                  !string.IsNullOrWhiteSpace(ComboBoxOfUnit.Text);

            ButtonOfAddCategory.Enabled = allFieldsFilled;
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
                Name = TextBoxForName.Text.Trim(),
                Unit_Id = selectedUnitId
            };

            if (db.Categories.Any(c => c.Status == CategoryStatus.Active && EF.Functions.ILike(c.Name, newCategory.Name)))
            {
                MessageBox.Show(Resources.NewCategoryExists, Resources.TitleWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            db.Categories.Add(newCategory);
            if (ErrorHandler.DBSaveChangesUniversalErrorCheck(db))
                return;

            MessageBox.Show(Resources.SuccessAddCategory, Resources.TitleInformation,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            Close();
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            Close();
        }
    }
}
