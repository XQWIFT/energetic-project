using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using EH = EnergeticProjectX.Classes.ErrorHandler;
using FH = EnergeticProjectX.Classes.FormHandler;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Класс для добавления новой категории.
    /// </summary>
    public partial class AddCategoryForm : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly string userLogin;

        /// <summary>
        /// Основной конструктор добавления новой категории.
        /// </summary>
        public AddCategoryForm(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadUnits(Db, ref ComboBoxOfUnit);
        }

        /// <summary>
        /// Загрузка единиц измерений в выпадающий список.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        /// <param name="comboBox">Название выпадающего списка.</param>
        public static void LoadUnits(ApplicationContextDB db, ref ComboBox comboBox)
        {
            var units = db.Units.ToList();

            if (units.Count != 0)
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
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            if (ComboBoxOfUnit.SelectedValue == null)
            {
                EH.ShowAlert(Resources.ChooseNewUnitToEditCategoryFirst);

                return;
            }

            var newCategory = new Category
            {
                Name = Regex.Replace(TextBoxOfCategoryName.Text, @"\s+", " "),
                Unit_Id = (Guid)ComboBoxOfUnit.SelectedValue
            };

            if (Db.Categories.Any(c => c.Status == Status.Active && EF.Functions.ILike(c.Name, newCategory.Name)) ||
                Db.Categories.Any(c => c.Status == Status.Active && EF.Functions.ILike(c.Name, Regex.Replace(newCategory.Name, @"\s+", "")) ||
                Db.Categories.Any(c => c.Status == Status.Active && EF.Functions.ILike(Regex.Replace(c.Name, @"\s+", ""),
                Regex.Replace(newCategory.Name, @"\s+", "")))))
            {
                EH.ShowWarning(Resources.NewCategoryAlreadyExists, true);

                return;
            }
            

            Db.Categories.Add(newCategory);
            if (EH.DBSaveChangesUniversalErrorCheck(Db))
                return;

            EH.ShowInformation(Resources.NewCategorySuccessfullyAdded);

            OpenProductCatalog();
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            OpenProductCatalog();
        }

        private void OpenProductCatalog()
        {
            var productCatalog = new TableOfProducts(userLogin);
            FH.OpenForm(this, productCatalog);
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
