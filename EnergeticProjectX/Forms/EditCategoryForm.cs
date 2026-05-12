using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using EH = EnergeticProjectX.Classes.ErrorHandler;

namespace EnergeticProjectX.Forms
{
    /// <summary>
    /// Форма для изменения существующей категории.
    /// </summary>
    public partial class EditCategoryForm : Form
    {
        private static ApplicationContextDB Db => Program.Database;

        private readonly string userLogin;

        /// <summary>
        /// Конструктор для реализации изменения существующей категорий.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public EditCategoryForm(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadCategories();

            AddCategoryForm.LoadUnits(Db, ref ComboBoxOfNewUnitData);
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var chosenCategory = ComboBoxOfCategory.SelectedItem as Category;

            var hasUnit = ComboBoxOfNewUnitData.SelectedIndex != -1;

            ButtonOfDeleteCategory.Enabled = chosenCategory != null;

            ButtonOfSaveChanges.Enabled = chosenCategory != null && hasUnit;

            if (chosenCategory != null)
            {
                var currentUnit = Db.Units.FirstOrDefault(u => u.Unit_Id == chosenCategory.Unit_Id);

                if (currentUnit != null)
                {
                    TextBoxForCurrentUnit.Text = currentUnit.Name;
                }
                else
                {
                    TextBoxForCurrentUnit.Text = string.Empty;

                    EH.ShowError(Resources.ErrorUnitUpload, true);

                    return;
                }
            }
            else
            {
                TextBoxForCurrentUnit.Text = string.Empty;
            }
        }

        private void LoadCategories()
        {
            var categories = Db.Categories.Where(u => u.Status == Status.Active).ToList();

            if (categories != null && categories.Count != 0)
            {
                ComboBoxOfCategory.DisplayMember = nameof(Category.Name);
                ComboBoxOfCategory.ValueMember = nameof(Category.Category_Id);
                ComboBoxOfCategory.DataSource = categories;
            }
            else
            {
                EH.ShowError(Resources.ErrorCategoryUpload, true);

                return;
            }

            ComboBoxOfCategory.SelectedIndex = -1;
        }

        private void ButtonOfSaveChanges_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            if (ComboBoxOfCategory.SelectedValue == null || ComboBoxOfNewUnitData.SelectedValue == null)
            {
                EH.ShowAlert(Resources.ChooseCategoryAndNewUnitToEdit);

                return;
            }

            var newCategoryName = Interaction.InputBox(Resources.InputNewCategoryName, Resources.EditCategory, ComboBoxOfCategory.Text).Trim();

            if ((Db.Categories.Any(c => c.Status == Status.Active && EF.Functions.ILike(c.Name, newCategoryName)) ||
                Db.Categories.Any(c => c.Status == Status.Active && EF.Functions.ILike(c.Name, Regex.Replace(newCategoryName, @"\s+", "")) ||
                Db.Categories.Any(c => c.Status == Status.Active && EF.Functions.ILike(Regex.Replace(c.Name, @"\s+", ""),
                Regex.Replace(newCategoryName, @"\s+", ""))))))
            {
                EH.ShowWarning(Resources.NewCategoryAlreadyExists, true);

                return;
            }
            else if (string.IsNullOrWhiteSpace(newCategoryName))
            {
                EH.ShowWarning(Resources.NewCategoryNameShouldNotBeEmpty, true);

                return;
            }

            var selectedUnitId = (Guid)ComboBoxOfNewUnitData.SelectedValue;
            var chosenCategoryId = (Guid)ComboBoxOfCategory.SelectedValue;

            var category = Db.Categories.Find(chosenCategoryId);

            if (category != null)
            {
                category.Unit_Id = selectedUnitId;
                category.Name = newCategoryName;

                var question = EH.ShowConfirmation($"{Resources.SureWantToSaveCategoryChange}\n\n{Resources.SaveCategoryChangeConsequences}");

                if (question == DialogResult.Yes)
                {
                    if (EH.DBSaveChangesUniversalErrorCheck(Db))
                        return;

                    EH.ShowInformation(Resources.SuccessUpdateCategory);
                }

                OpenProductCatalog();
            }
            else
            {
                EH.ShowError(Resources.ErrorSaveCategory, true);

                return;
            }
        }

        private void ButtonOfDelete_Click(object sender, EventArgs e)
        {
            if (EH.EnsureUserActive(this, Db, userLogin, Resources.CurrentSessionWasInterruptedOrUserWasDeleted) == null) return;

            if (ComboBoxOfCategory.SelectedValue == null)
            {
                EH.ShowAlert(Resources.ChooseCategoryToDeleteFirst);

                ComboBoxOfCategory.Focus();

                return;
            }

            var question = EH.ShowConfirmation($"{Resources.SureWantToDeleteCategory} {ComboBoxOfCategory.Text}?");

            if (question == DialogResult.Yes)
            {
                var chosenCategoryId = (Guid)ComboBoxOfCategory.SelectedValue;

                var category = Db.Categories.Find(chosenCategoryId);

                if (category != null)
                {
                    category.Status = Status.Hidden;

                    if (EH.DBSaveChangesUniversalErrorCheck(Db))
                        return;

                    EH.ShowInformation(Resources.CategorySuccessfullyDeleted);

                    LoadCategories();
                }
            }
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            OpenProductCatalog();
        }

        private void OpenProductCatalog()
        {
            Hide();
            var productCatalog = new TableOfProducts(userLogin);
            productCatalog.ShowDialog();
            Close();
        }

        private void TabSelection_Enter(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.BackColor = Color.LightSteelBlue;
            }
        }

        private void TabSelection_Leave(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.BackColor = Color.Transparent;
            }
        }
    }
}
