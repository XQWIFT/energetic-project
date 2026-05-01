using EH = EnergeticProjectX.Classes.ErrorHandler;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using EnergeticProjectX.Enums;
using Microsoft.EntityFrameworkCore;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Класс для добавления новой категории.
    /// </summary>
    public partial class AddCategory : Form
    {
        private readonly string userLogin;

        private readonly ApplicationContextDB db = new();

        /// <summary>
        /// Основной конструктор добавления новой категории.
        /// </summary>
        public AddCategory(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadUnits(db, ref ComboBoxOfUnit);
        }

        /// <summary>
        /// Загрузка единиц измерений в выпадающий список.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        /// <param name="comboBox">Название выпадающего списка.</param>
        public static void LoadUnits(ApplicationContextDB db, ref ComboBox comboBox)
        {
            var units = db.Units.ToList();

            if (units != null && units.Count != 0)
            {
                comboBox.DataSource = units;
                comboBox.DisplayMember = nameof(Unit.Name);
                comboBox.ValueMember = nameof(Unit.Unit_Id);
            }
            else
            {
                EH.ShowError(Resources.ErrorUnitUpload, true);

                return;
            }

            comboBox.SelectedIndex = -1;
        }

        private void IsTextChanged(object sender, EventArgs e)
        {
            ButtonOfAddCategory.Enabled = !string.IsNullOrWhiteSpace(TextBoxOfCategoryName.Text) &&
                                          !string.IsNullOrWhiteSpace(ComboBoxOfUnit.Text);
        }

        private void ButtonOfAddCategory_Click(object sender, EventArgs e)
        {
            if (ComboBoxOfUnit.SelectedValue == null)
            {
                EH.ShowAlert(Resources.ChooseNewUnitToEditCategoryFirst);

                return;
            }

            var newCategory = new Category
            {
                Name = TextBoxOfCategoryName.Text.Trim(),
                Unit_Id = (Guid)ComboBoxOfUnit.SelectedValue
            };

            if (db.Categories.Any(c => c.Status == CategoryStatus.Active && EF.Functions.ILike(c.Name, newCategory.Name)))
            {
                EH.ShowWarning(Resources.NewCategoryAlreadyExists, true);

                return;
            }

            db.Categories.Add(newCategory);
            if (EH.DBSaveChangesUniversalErrorCheck(db))
                return;

            EH.ShowInformation(Resources.NewCategorySuccessfullyAdded);

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

        private void TabSelection_Enter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.LightSteelBlue;
            }
        }

        private void TabSelection_Leave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.Transparent;
            }
        }
    }
}
