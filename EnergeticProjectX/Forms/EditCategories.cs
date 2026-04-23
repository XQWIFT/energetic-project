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
    /// Класс для изменения существующей категории
    /// </summary>
    public partial class EditCategories : Form
    {
        private readonly ApplicationContextDB db = new();

        private readonly string userLogin;

        /// <summary>
        /// Конструктор изменения существующей категорий
        /// </summary>
        /// <param name="userLogin">Логин авторизованного пользователя</param>
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
                MessageBox.Show($"{Resources.ErrorUnitUpload}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
        }

        /// <summary>
        /// Загрузка категорий из базы данных
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
                MessageBox.Show($"{Resources.ErrorCategoryUpload}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void ButtonOfSaveChanges_Click(object sender, EventArgs e)
        {
            if (ComboBoxOfCategory.SelectedItem == null || ComboBoxOfNewUnitData.SelectedItem == null)
            {
                MessageBox.Show(Resources.ChooseEditCategoryAndNewUnit, Resources.TitleAlert,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newCategory = Interaction.InputBox(Resources.InputNewCategoryName,Resources.EditCategory, ComboBoxOfCategory.Text);

            if (!string.IsNullOrWhiteSpace(newCategory))
            {
                if (db.Categories.Any(c => c.Status == CategoryStatus.Active &&
                                           EF.Functions.ILike(c.Name, newCategory)))
                {
                    MessageBox.Show(Resources.NewCategoryExists, Resources.TitleWarning,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (!Guid.TryParse(ComboBoxOfNewUnitData.SelectedValue!.ToString(), out Guid selectedUnitId))
                {
                    MessageBox.Show(Resources.ErrorUnitUpload, Resources.TitleError,
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                var selectedCategory = (Category)ComboBoxOfCategory.SelectedItem;

                var category = db.Categories.Find(selectedCategory.Category_Id);
                if (category != null)
                {
                    selectedCategory.Unit_Id = selectedUnitId;
                    selectedCategory.Name = newCategory;

                    var question = MessageBox.Show($"{Resources.SureWantToSaveCategoryChange}\n\n{Resources.ConsequencesSaveCategoryChange}",
                                                   Resources.TitleConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (question == DialogResult.Yes)
                    {
                        if (ErrorHandler.DBSaveChangesUniversalErrorCheck(db))
                            return;

                        MessageBox.Show(Resources.SuccessUpdateCategory, Resources.TitleInformation,
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"{Resources.ErrorSaveCategory}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void ButtonOfDelete_Click(object sender, EventArgs e)
        {
            if (ComboBoxOfCategory.SelectedItem == null)
            {
                MessageBox.Show(Resources.ChooseCategoryDelete, Resources.TitleAlert,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var question = MessageBox.Show($"{Resources.AskForDeleteCategory}\n{ComboBoxOfCategory.Text}?", Resources.TitleConfirmation,
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (question == DialogResult.Yes)
            {
                var selectedCategory = (Category)ComboBoxOfCategory.SelectedItem;

                var category = db.Categories.Find(selectedCategory.Category_Id);
                if (category != null)
                {
                    category.Status = CategoryStatus.Hidden;

                    if (ErrorHandler.DBSaveChangesUniversalErrorCheck(db))
                        return;

                    MessageBox.Show(Resources.SuccessDeleteCategory, Resources.TitleInformation,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

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
