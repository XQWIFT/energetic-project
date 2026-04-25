using EH = EnergeticProjectX.Classes.ErrorHandler;
using AddCategoryForm;
using EnergeticProjectX.Classes;
using EnergeticProjectX.Enums;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProductCatalogForm;

namespace EditCategoriesForm
{
    /// <summary>
    /// Класс для изменения существующей категории.
    /// </summary>
    public partial class EditCategories : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        /// <summary>
        /// Конструктор изменения существующей категорий.
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя.</param>
        public EditCategories(string userLogin)
        {
            InitializeComponent();

            this.userLogin = userLogin;

            LoadCategories();
            AddCategory.LoadUnits(db, ComboBoxOfNewUnitData);

            ComboBoxOfCategory.SelectedIndex = -1;
            ComboBoxOfNewUnitData.SelectedIndex = -1;

            ComboBoxOfNewUnitData.SelectedIndexChanged += ComboBoxes_SelectedIndexChanged!;
            ComboBoxOfCategory.SelectedIndexChanged += ComboBoxes_SelectedIndexChanged!;
        }

        private void ComboBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonOfDelete.Enabled = ComboBoxOfCategory.SelectedIndex != -1 &&
                                     ComboBoxOfCategory.SelectedItem != null;

            ButtonOfSaveChanges.Enabled = ComboBoxOfCategory.SelectedIndex != -1 &&
                                          ComboBoxOfCategory.SelectedItem != null &&
                                          ComboBoxOfNewUnitData.SelectedIndex != -1 &&
                                          ComboBoxOfNewUnitData.SelectedItem != null;

            if (ComboBoxOfCategory.SelectedIndex != -1 && 
                ComboBoxOfCategory.SelectedItem != null &&
                ComboBoxOfCategory.SelectedItem is Category chosenCategory)
            {
                var currentUnit = db.Units.FirstOrDefault(u => u.Unit_Id == chosenCategory.Unit_Id);

                textBoxForCurrentUnit.Text = currentUnit!.Name;
            }
            else
            {
                EH.ShowError($"{Resources.ErrorUnitUpload}\n{Resources.TryAgain}");

                return;
            }
        }

        /// <summary>
        /// Загрузка категорий из базы данных.
        /// </summary>
        private void LoadCategories()
        {
            var categories = db.Categories.Where(u => u.Status == CategoryStatus.Active).ToList();

            if (categories != null && categories.Count != 0)
            {
                ComboBoxOfCategory.DataSource = categories;
                ComboBoxOfCategory.DisplayMember = Resources.CategoryDisplayMember;
                ComboBoxOfCategory.ValueMember = Resources.CategoryValueMember;
            }
            else
            {
                EH.ShowError($"{Resources.ErrorCategoryUpload}\n{Resources.TryAgain}");

                return;
            }
        }

        private void ButtonOfSaveChanges_Click(object sender, EventArgs e)
        {
            if (ComboBoxOfCategory.SelectedItem == null || ComboBoxOfNewUnitData.SelectedItem == null)
            {
                EH.ShowAlert(Resources.ChooseEditCategoryAndNewUnit);

                return;
            }

            var chosenCategory = (Category)ComboBoxOfCategory.SelectedItem;

            var newCategory = Interaction.InputBox(Resources.InputNewCategoryName, Resources.EditCategory, ComboBoxOfCategory.Text);

            if (db.Categories.Any(c => c.Category_Id != chosenCategory.Category_Id && c.Status == CategoryStatus.Active && EF.Functions.ILike(c.Name, newCategory)))
            {
                EH.ShowWarning(Resources.NewCategoryExists);

                return;
            }

            if (!string.IsNullOrWhiteSpace(newCategory))
            {
                if (!Guid.TryParse(ComboBoxOfNewUnitData.SelectedValue!.ToString(), out var selectedUnitId))
                {
                    EH.ShowError(Resources.ErrorUnitUpload);

                    return;
                }

                var selectedCategory = (Category)ComboBoxOfCategory.SelectedItem;

                var category = db.Categories.Find(selectedCategory.Category_Id);
                if (category != null)
                {
                    selectedCategory.Unit_Id = selectedUnitId;
                    selectedCategory.Name = newCategory;

                    var question = EH.ShowConfirmation($"{Resources.SureWantToSaveCategoryChange}\n\n{Resources.ConsequencesSaveCategoryChange}");

                    if (question == DialogResult.Yes)
                    {
                        if (EH.DBSaveChangesUniversalErrorCheck(db))
                            return;

                        EH.ShowInformation(Resources.SuccessUpdateCategory);
                    }

                    LoadCategories();
                    AddCategory.LoadUnits(db, ComboBoxOfNewUnitData);

                    Hide();
                    var productCatalog = new ProductCatalog(userLogin);
                    productCatalog.ShowDialog();
                    Close();
                }
            }
            else
            {
                EH.ShowError($"{Resources.ErrorSaveCategory}\n{Resources.TryAgain}");

                return;
            }
        }

        private void ButtonOfDelete_Click(object sender, EventArgs e)
        {
            if (ComboBoxOfCategory.SelectedItem == null)
            {
                EH.ShowAlert(Resources.ChooseCategoryDelete);

                return;
            }

            var question = EH.ShowConfirmation($"{Resources.AskForDeleteCategory}\n{ComboBoxOfCategory.Text}?");

            if (question == DialogResult.Yes)
            {
                var selectedCategory = (Category)ComboBoxOfCategory.SelectedItem;

                var category = db.Categories.Find(selectedCategory.Category_Id);
                if (category != null)
                {
                    category.Status = CategoryStatus.Hidden;

                    if (EH.DBSaveChangesUniversalErrorCheck(db))
                        return;

                    EH.ShowInformation(Resources.SuccessDeleteCategory);

                    LoadCategories();
                    ComboBoxOfCategory.SelectedIndex = -1;
                }
            }
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
