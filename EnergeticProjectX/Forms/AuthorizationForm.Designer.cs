
namespace EnergeticProjectX
{
    partial class AuthorizationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LabelOfAuthorization = new Label();
            LabelOfLogin = new Label();
            TextBoxForLogin = new TextBox();
            LabelOfPassword = new Label();
            TextBoxOfPassword = new TextBox();
            ButtonOfInvolve = new Button();
            LabelOfRegistration = new Label();
            LabelOfRequiredFieldsInfo = new Label();
            SuspendLayout();
            // 
            // LabelOfAuthorization
            // 
            LabelOfAuthorization.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LabelOfAuthorization.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfAuthorization.Location = new Point(306, 106);
            LabelOfAuthorization.Name = "LabelOfAuthorization";
            LabelOfAuthorization.Size = new Size(386, 63);
            LabelOfAuthorization.TabIndex = 0;
            LabelOfAuthorization.Text = "Авторизация";
            LabelOfAuthorization.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LabelOfLogin
            // 
            LabelOfLogin.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfLogin.Location = new Point(158, 220);
            LabelOfLogin.Name = "LabelOfLogin";
            LabelOfLogin.Size = new Size(149, 55);
            LabelOfLogin.TabIndex = 1;
            LabelOfLogin.Text = "Логин";
            LabelOfLogin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TextBoxForLogin
            // 
            TextBoxForLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            TextBoxForLogin.BackColor = Color.White;
            TextBoxForLogin.BorderStyle = BorderStyle.FixedSingle;
            TextBoxForLogin.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxForLogin.Location = new Point(363, 220);
            TextBoxForLogin.Name = "TextBoxForLogin";
            TextBoxForLogin.Size = new Size(474, 55);
            TextBoxForLogin.TabIndex = 2;
            // 
            // LabelOfPassword
            // 
            LabelOfPassword.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfPassword.Location = new Point(158, 326);
            LabelOfPassword.Name = "LabelOfPassword";
            LabelOfPassword.Size = new Size(177, 50);
            LabelOfPassword.TabIndex = 3;
            LabelOfPassword.Text = "Пароль*";
            LabelOfPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TextBoxOfPassword
            // 
            TextBoxOfPassword.BackColor = Color.White;
            TextBoxOfPassword.BorderStyle = BorderStyle.FixedSingle;
            TextBoxOfPassword.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfPassword.Location = new Point(363, 326);
            TextBoxOfPassword.Name = "TextBoxOfPassword";
            TextBoxOfPassword.Size = new Size(474, 55);
            TextBoxOfPassword.TabIndex = 4;
            TextBoxOfPassword.UseSystemPasswordChar = true;
            // 
            // ButtonOfInvolve
            // 
            ButtonOfInvolve.Enabled = false;
            ButtonOfInvolve.FlatAppearance.BorderColor = Color.Black;
            ButtonOfInvolve.FlatAppearance.BorderSize = 4;
            ButtonOfInvolve.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfInvolve.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfInvolve.FlatStyle = FlatStyle.Flat;
            ButtonOfInvolve.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfInvolve.ForeColor = SystemColors.ControlText;
            ButtonOfInvolve.Location = new Point(265, 511);
            ButtonOfInvolve.Name = "ButtonOfInvolve";
            ButtonOfInvolve.Size = new Size(437, 79);
            ButtonOfInvolve.TabIndex = 5;
            ButtonOfInvolve.Text = "Войти";
            ButtonOfInvolve.UseVisualStyleBackColor = true;
            ButtonOfInvolve.Click += ButtonOfInvolve_Click;
            // 
            // LabelOfRegistration
            // 
            LabelOfRegistration.AutoSize = true;
            LabelOfRegistration.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            LabelOfRegistration.Location = new Point(215, 421);
            LabelOfRegistration.Name = "LabelOfRegistration";
            LabelOfRegistration.Size = new Size(565, 45);
            LabelOfRegistration.TabIndex = 6;
            LabelOfRegistration.Text = "Нет аккаунта? Зарегистрироваться";
            LabelOfRegistration.Click += LabelOfRegistration_Click;
            // 
            // LabelOfRequiredFieldsInfo
            // 
            LabelOfRequiredFieldsInfo.AutoSize = true;
            LabelOfRequiredFieldsInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfRequiredFieldsInfo.ForeColor = Color.DimGray;
            LabelOfRequiredFieldsInfo.Location = new Point(265, 478);
            LabelOfRequiredFieldsInfo.Name = "LabelOfRequiredFieldsInfo";
            LabelOfRequiredFieldsInfo.Size = new Size(276, 30);
            LabelOfRequiredFieldsInfo.TabIndex = 7;
            LabelOfRequiredFieldsInfo.Text = "*Все поля обязательные";
            // 
            // AuthorizationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(997, 675);
            Controls.Add(LabelOfRequiredFieldsInfo);
            Controls.Add(LabelOfRegistration);
            Controls.Add(ButtonOfInvolve);
            Controls.Add(TextBoxOfPassword);
            Controls.Add(LabelOfPassword);
            Controls.Add(TextBoxForLogin);
            Controls.Add(LabelOfLogin);
            Controls.Add(LabelOfAuthorization);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AuthorizationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Начальная страница";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelOfAuthorization;
        private Label LabelOfLogin;
        private TextBox TextBoxForLogin;
        private Label LabelOfPassword;
        private TextBox TextBoxOfPassword;
        private Button ButtonOfInvolve;
        private Label LabelOfRegistration;
        private Label LabelOfRequiredFieldsInfo;
    }
}
