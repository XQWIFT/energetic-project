
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
            textBoxForLogin = new TextBox();
            LabelOfPassword = new Label();
            textBoxOfPassword = new TextBox();
            ButtonOfInvolve = new Button();
            LabelOfRegistration = new Label();
            LabelOfRequiredFieldsInfo = new Label();
            SuspendLayout();
            // 
            // LabelOfAuthorization
            // 
            LabelOfAuthorization.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LabelOfAuthorization.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfAuthorization.Location = new Point(286, 103);
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
            // textBoxForLogin
            // 
            textBoxForLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            textBoxForLogin.BackColor = Color.White;
            textBoxForLogin.BorderStyle = BorderStyle.FixedSingle;
            textBoxForLogin.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxForLogin.Location = new Point(363, 220);
            textBoxForLogin.Name = "textBoxForLogin";
            textBoxForLogin.Size = new Size(474, 55);
            textBoxForLogin.TabIndex = 2;
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
            // textBoxOfPassword
            // 
            textBoxOfPassword.BackColor = Color.White;
            textBoxOfPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxOfPassword.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfPassword.Location = new Point(363, 326);
            textBoxOfPassword.Name = "textBoxOfPassword";
            textBoxOfPassword.Size = new Size(474, 55);
            textBoxOfPassword.TabIndex = 4;
            textBoxOfPassword.UseSystemPasswordChar = true;
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
            ButtonOfInvolve.Location = new Point(256, 511);
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
            LabelOfRegistration.Location = new Point(209, 421);
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
            LabelOfRequiredFieldsInfo.Location = new Point(256, 478);
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
            Controls.Add(textBoxOfPassword);
            Controls.Add(LabelOfPassword);
            Controls.Add(textBoxForLogin);
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
        private TextBox textBoxForLogin;
        private Label LabelOfPassword;
        private TextBox textBoxOfPassword;
        private Button ButtonOfInvolve;
        private Label LabelOfRegistration;
        private Label LabelOfRequiredFieldsInfo;
    }
}
