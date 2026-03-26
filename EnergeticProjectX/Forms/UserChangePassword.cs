using AdministratorPanelForm;
using BCrypt;
using DBControl;
using WarehousemanPanelForm;

namespace UserChangePasswordForm
{
    /// <summary>
    /// Работа по изменению пароля пользователя
    /// </summary>
    public partial class UserChangePassword : Form
    {
        string userLogin;

        bool isPasswordsEqual;
        bool isOldPasswordEqualDB;
        bool isUserFound;

        public UserChangePassword(string userLogin)
        {
            InitializeComponent();
            this.userLogin = userLogin;
        }

        private void buttonOfSaveInfo_Click(object sender, EventArgs e)
        {
            ChangePassword(sender, e);
        }

        private void buttonOfCancel_Click(object sender, EventArgs e)
        {
            Cancel(sender, e);
        }

        private void ChangePassword(object sender, EventArgs e)
        {
            DBControl.ApplicationContextDB db = new();
            BCryptRealization bc = new();
            var oldPassword = textBoxForOldPassword.Text.Trim();
            var newPassword = textBoxForNewPassword.Text.Trim();
            var confirmationPassword = textBoxOfConfirmation.Text.Trim();

            IsAllPasswordsandLoginValid(oldPassword, newPassword, confirmationPassword, db);
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);
            if (isUserFound && user != null)
            {
                if (isOldPasswordEqualDB)
                {
                    if (isPasswordsEqual)
                    {
                        user.Password = bc.PasswordHash(newPassword);
                        db.SaveChanges();
                        MessageBox.Show("Вы изменили пароль!", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (user.UserRole == "Admin")
                        {
                            this.Hide();
                            var administratorPanel = new AdministratorPanel(userLogin);
                            administratorPanel.ShowDialog();
                            this.Close();
                        }
                        else if (user.UserRole == "Warehouseman")
                        {
                            this.Hide();
                            var warehousemanPanel = new WarehousemanPanel(userLogin);
                            warehousemanPanel.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Новые пароли не совпадают!\n Попробуйте снова!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxForNewPassword.Clear();
                        textBoxOfConfirmation.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Вы неверно ввели старый пароль!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxForOldPassword.Clear();
                    textBoxForNewPassword.Clear();
                    textBoxOfConfirmation.Clear();
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден!\n Try again!", "Ошибка",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.Dispose();
        }

        /// <summary>
        /// Проверка пароля и логина на наличие и надёжность
        /// </summary>
        public void IsAllPasswordsandLoginValid(string oldPassword, string newPassword, string confirmationPassword, DBControl.ApplicationContextDB db)
        {
            BCryptRealization bc = new();
            var user = db.Users.FirstOrDefault(u => u.Login == userLogin);
            if (user != null)
            {
                isUserFound = true;

                if (bc.CheckPassword(oldPassword, user.Password))
                {
                    isOldPasswordEqualDB = true;
                    if (newPassword == confirmationPassword)
                    {
                        isPasswordsEqual = true;
                    }
                    else
                    {
                        //Если новые пароли не совпадают
                        isPasswordsEqual = false;
                    }
                }
                else
                {
                    // Если старый пароль введен неправильно
                    isOldPasswordEqualDB = false;
                }
            }
            else
            {
                //Если пользователь не найден
                isUserFound = false;
            }
        }
        private void Cancel(object sender, EventArgs e)
        {
            AdministratorPanel administratorPanel = new(userLogin);
            this.Hide();
            administratorPanel.ShowDialog();
            this.Close();
        }
    }
}