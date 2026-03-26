using CategoryControl;
using DBControl;
using ProductCatalogForm;
using Windows.UI.Xaml.Controls.Primitives;

namespace EditCategoriesForm
{
    public partial class EditCategories : Form
    {
        string userLogin;
        public EditCategories(string userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;

            buttonOfSaveChanges.Enabled = false;
            buttonOfDelete.Enabled = false;

            LoadCategories();

            comboBoxOfCategory.SelectedIndex = -1;
        }

        private void comboBoxOfCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonOfSaveChanges.Enabled = comboBoxOfCategory.SelectedIndex != -1 &&
                                  comboBoxOfCategory.SelectedItem != null;
            buttonOfDelete.Enabled = comboBoxOfCategory.SelectedIndex != -1 &&
                                   comboBoxOfCategory.SelectedItem != null;
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

        private void buttonOfReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var productCatalog = new ProductCatalog(userLogin);
            productCatalog.ShowDialog();
            this.Close();
        }

        private void buttonOfSaveChanges_Click(object sender, EventArgs e)
        {
            if (comboBoxOfCategory.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию для редактирования",
                "Предупреждение",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newCategoryName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новое название категории:",
                "Редактирование категории",
                comboBoxOfCategory.Text);

            if (!string.IsNullOrWhiteSpace(newCategoryName))
            {
                var selectedCategory = (Category)comboBoxOfCategory.SelectedItem;

                using (var db = new ApplicationContextDB())
                {
                    var category = db.Categories.Find(selectedCategory.CategoryId);
                    if (category != null)
                    {
                        category.Name = newCategoryName;
                        db.SaveChanges();

                        MessageBox.Show("Категория успешно обновлена!",
                        "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadCategories();
                    }
                }
            }
        }

        private void buttonOfDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxOfCategory.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию для удаления",
                "Предупреждение",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Вы уверены, что хотите удалить категорию \"{comboBoxOfCategory.Text}\"?\n\n" +
                "ВНИМАНИЕ: Если у этой категории есть товары, они могут быть удалены или остаться без категории!",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var selectedCategory = (Category)comboBoxOfCategory.SelectedItem;

                using (var db = new ApplicationContextDB())
                {
                    var category = db.Categories.Find(selectedCategory.CategoryId);
                    if (category != null)
                    {
                        db.Categories.Remove(category);
                        db.SaveChanges();

                        MessageBox.Show("Категория успешно удалена!",
                        "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadCategories();
                        comboBoxOfCategory.SelectedIndex = -1;
                    }
                }
            }
        }
    }
}
