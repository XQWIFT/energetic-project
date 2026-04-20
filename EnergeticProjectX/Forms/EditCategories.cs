using EnergeticProjectX.Classes;
using EnergeticProjectX.Objects;
using EnergeticProjectX.Properties;
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
            LoadUnits();

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

                textBoxForCurrentUnit.Text = currentUnit!.Value;
            }
            else
            {
                MessageBox.Show($"{Resources.ErrorCategoryUpload}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
        }

        /// <summary>
        /// Загрузка категорий из базы данных
        /// </summary>
        public void LoadCategories()
        {
            var categories = db.Categories.Where(u => u.Status == 1).ToList();

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

        /// <summary>=
        /// Загрузка единиц измерения из базы данных
        /// </summary>
        public void LoadUnits()
        {
            var units = db.Units.ToList();

            if (units != null && units.Count != 0)
            {
                ComboBoxOfNewUnitData.DataSource = units;
                ComboBoxOfNewUnitData.DisplayMember = Resources.UnitDisplayMember;
                ComboBoxOfNewUnitData.ValueMember = Resources.UnitValueMember;
            }
            else
            {
                MessageBox.Show($"{Resources.ErrorUnitUpload}\n{Resources.TryAgain}", Resources.TitleError,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void ButtonOfCancel_Click(object sender, EventArgs e)
        {
            Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            Close();
        }

        private void ButtonOfSaveChanges_Click(object sender, EventArgs e)
        {
            if (ComboBoxOfCategory.SelectedItem == null || ComboBoxOfNewUnitData.SelectedItem == null)
            {
                MessageBox.Show(Resources.ChooseEditCategoryAndNewUnit, Resources.TitleAlert,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newCategoryName = Microsoft.VisualBasic.Interaction.InputBox(Resources.InputNewCategoryName,
                                                                                Resources.EditCategory,
                                                                                ComboBoxOfCategory.Text);

            if (!string.IsNullOrWhiteSpace(newCategoryName))
            {
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
                    selectedCategory.Name = newCategoryName;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{Resources.UniversalErrorBD}\n{Resources.TryAgain}\n\n" +
                                        $"Текст ошибки: {ex.Message}", Resources.TitleErrorBD,
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    MessageBox.Show(Resources.SuccessUpdateCategory, Resources.TitleSuccess,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCategories();
                    LoadUnits();

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

            var result = MessageBox.Show($"{Resources.AskForDeleteCategory} \"{ComboBoxOfCategory.Text}\"?\n\n" +
                                         Resources.AlertOfDeleteCategory, Resources.ConfirmationDelete,
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var selectedCategory = (Category)ComboBoxOfCategory.SelectedItem;

                var category = db.Categories.Find(selectedCategory.Category_Id);
                if (category != null)
                {
                    category.Status = 0;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{Resources.UniversalErrorBD}\n{Resources.TryAgain}" +
                            $"Текст ошибки: {ex.Message}", Resources.TitleErrorBD,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show(Resources.SuccessDeleteCategory, Resources.TitleSuccess,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCategories();
                    ComboBoxOfCategory.SelectedIndex = -1;
                }
            }
        }
    }
}
