namespace EnergeticProjectX.Forms
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LabelOfRegistration = new Label();
            LabelOfFirstName = new Label();
            TextBoxOfName = new TextBox();
            LabelOfSurname = new Label();
            TextBoxOfSurname = new TextBox();
            TextBoxOfPatronymic = new TextBox();
            LabelOfLogin = new Label();
            TextBoxOfLogin = new TextBox();
            LabelOfPassword = new Label();
            TextBoxOfPassword = new TextBox();
            LabelOfPasswordConfirmation = new Label();
            TextBoxOfPasswordConfirmation = new TextBox();
            ButtonOfRegistration = new Button();
            LabelOfAuthorization = new Label();
            LabelOfPatronymicInfo = new Label();
            LabelOfPatronymic = new Label();
            SuspendLayout();
            // 
            // LabelOfRegistration
            // 
            LabelOfRegistration.AutoSize = true;
            LabelOfRegistration.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfRegistration.Location = new Point(267, 39);
            LabelOfRegistration.Name = "LabelOfRegistration";
            LabelOfRegistration.Size = new Size(295, 60);
            LabelOfRegistration.TabIndex = 0;
            LabelOfRegistration.Text = "Регистрация";
            // 
            // LabelOfFirstName
            // 
            LabelOfFirstName.AutoSize = true;
            LabelOfFirstName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfFirstName.Location = new Point(114, 128);
            LabelOfFirstName.Name = "LabelOfFirstName";
            LabelOfFirstName.Size = new Size(88, 45);
            LabelOfFirstName.TabIndex = 0;
            LabelOfFirstName.Text = "Имя";
            // 
            // TextBoxOfName
            // 
            TextBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfName.Location = new Point(366, 128);
            TextBoxOfName.Name = "TextBoxOfName";
            TextBoxOfName.Size = new Size(402, 45);
            TextBoxOfName.TabIndex = 1;
            TextBoxOfName.TextChanged += IsTextChanged;
            // 
            // LabelOfSurname
            // 
            LabelOfSurname.AutoSize = true;
            LabelOfSurname.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfSurname.Location = new Point(114, 193);
            LabelOfSurname.Name = "LabelOfSurname";
            LabelOfSurname.Size = new Size(166, 45);
            LabelOfSurname.TabIndex = 0;
            LabelOfSurname.Text = "Фамилия";
            // 
            // TextBoxOfSurname
            // 
            TextBoxOfSurname.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfSurname.Location = new Point(366, 193);
            TextBoxOfSurname.Name = "TextBoxOfSurname";
            TextBoxOfSurname.Size = new Size(402, 45);
            TextBoxOfSurname.TabIndex = 2;
            TextBoxOfSurname.TextChanged += IsTextChanged;
            // 
            // TextBoxOfPatronymic
            // 
            TextBoxOfPatronymic.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfPatronymic.Location = new Point(366, 263);
            TextBoxOfPatronymic.Name = "TextBoxOfPatronymic";
            TextBoxOfPatronymic.Size = new Size(402, 45);
            TextBoxOfPatronymic.TabIndex = 3;
            // 
            // LabelOfLogin
            // 
            LabelOfLogin.AutoSize = true;
            LabelOfLogin.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfLogin.Location = new Point(114, 334);
            LabelOfLogin.Name = "LabelOfLogin";
            LabelOfLogin.Size = new Size(116, 45);
            LabelOfLogin.TabIndex = 0;
            LabelOfLogin.Text = "Логин";
            // 
            // TextBoxOfLogin
            // 
            TextBoxOfLogin.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfLogin.Location = new Point(366, 334);
            TextBoxOfLogin.Name = "TextBoxOfLogin";
            TextBoxOfLogin.Size = new Size(402, 45);
            TextBoxOfLogin.TabIndex = 4;
            TextBoxOfLogin.TextChanged += IsTextChanged;
            // 
            // LabelOfPassword
            // 
            LabelOfPassword.AutoSize = true;
            LabelOfPassword.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfPassword.Location = new Point(114, 408);
            LabelOfPassword.Name = "LabelOfPassword";
            LabelOfPassword.Size = new Size(138, 45);
            LabelOfPassword.TabIndex = 0;
            LabelOfPassword.Text = "Пароль";
            // 
            // TextBoxOfPassword
            // 
            TextBoxOfPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfPassword.Location = new Point(366, 408);
            TextBoxOfPassword.Name = "TextBoxOfPassword";
            TextBoxOfPassword.Size = new Size(402, 45);
            TextBoxOfPassword.TabIndex = 5;
            TextBoxOfPassword.UseSystemPasswordChar = true;
            TextBoxOfPassword.TextChanged += IsTextChanged;
            // 
            // LabelOfPasswordConfirmation
            // 
            LabelOfPasswordConfirmation.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfPasswordConfirmation.Location = new Point(114, 470);
            LabelOfPasswordConfirmation.MaximumSize = new Size(250, 0);
            LabelOfPasswordConfirmation.Name = "LabelOfPasswordConfirmation";
            LabelOfPasswordConfirmation.Size = new Size(250, 97);
            LabelOfPasswordConfirmation.TabIndex = 0;
            LabelOfPasswordConfirmation.Text = "Пароль повторно";
            // 
            // TextBoxOfPasswordConfirmation
            // 
            TextBoxOfPasswordConfirmation.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfPasswordConfirmation.Location = new Point(366, 482);
            TextBoxOfPasswordConfirmation.Name = "TextBoxOfPasswordConfirmation";
            TextBoxOfPasswordConfirmation.Size = new Size(402, 45);
            TextBoxOfPasswordConfirmation.TabIndex = 6;
            TextBoxOfPasswordConfirmation.UseSystemPasswordChar = true;
            TextBoxOfPasswordConfirmation.TextChanged += IsTextChanged;
            // 
            // ButtonOfRegistration
            // 
            ButtonOfRegistration.Enabled = false;
            ButtonOfRegistration.FlatAppearance.BorderColor = Color.Black;
            ButtonOfRegistration.FlatAppearance.BorderSize = 4;
            ButtonOfRegistration.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfRegistration.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfRegistration.FlatStyle = FlatStyle.Flat;
            ButtonOfRegistration.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfRegistration.Location = new Point(200, 671);
            ButtonOfRegistration.Name = "ButtonOfRegistration";
            ButtonOfRegistration.Size = new Size(413, 74);
            ButtonOfRegistration.TabIndex = 7;
            ButtonOfRegistration.Text = "Зарегистрироваться";
            ButtonOfRegistration.UseVisualStyleBackColor = true;
            ButtonOfRegistration.Click += ButtonOfRegistration_Click;
            ButtonOfRegistration.Enter += TabSelection_Enter;
            ButtonOfRegistration.Leave += TabSelection_Leave;
            // 
            // LabelOfAuthorization
            // 
            LabelOfAuthorization.AutoSize = true;
            LabelOfAuthorization.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            LabelOfAuthorization.Location = new Point(153, 583);
            LabelOfAuthorization.Name = "LabelOfAuthorization";
            LabelOfAuthorization.Size = new Size(565, 45);
            LabelOfAuthorization.TabIndex = 14;
            LabelOfAuthorization.Text = "Уже есть аккаунт? Авторизоваться";
            LabelOfAuthorization.Click += LabelOfAuthorization_Click;
            // 
            // LabelOfPatronymicInfo
            // 
            LabelOfPatronymicInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfPatronymicInfo.ForeColor = Color.Gray;
            LabelOfPatronymicInfo.Location = new Point(200, 641);
            LabelOfPatronymicInfo.Name = "LabelOfPatronymicInfo";
            LabelOfPatronymicInfo.Size = new Size(431, 27);
            LabelOfPatronymicInfo.TabIndex = 0;
            LabelOfPatronymicInfo.Text = "*Отчество — необязательное поле";
            // 
            // LabelOfPatronymic
            // 
            LabelOfPatronymic.AutoSize = true;
            LabelOfPatronymic.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfPatronymic.Location = new Point(114, 263);
            LabelOfPatronymic.Name = "LabelOfPatronymic";
            LabelOfPatronymic.Size = new Size(164, 45);
            LabelOfPatronymic.TabIndex = 0;
            LabelOfPatronymic.Text = "Отчество";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(828, 782);
            Controls.Add(LabelOfPatronymic);
            Controls.Add(LabelOfPatronymicInfo);
            Controls.Add(LabelOfAuthorization);
            Controls.Add(ButtonOfRegistration);
            Controls.Add(TextBoxOfPasswordConfirmation);
            Controls.Add(LabelOfPasswordConfirmation);
            Controls.Add(TextBoxOfPassword);
            Controls.Add(LabelOfPassword);
            Controls.Add(TextBoxOfLogin);
            Controls.Add(LabelOfLogin);
            Controls.Add(TextBoxOfPatronymic);
            Controls.Add(TextBoxOfSurname);
            Controls.Add(LabelOfSurname);
            Controls.Add(TextBoxOfName);
            Controls.Add(LabelOfFirstName);
            Controls.Add(LabelOfRegistration);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Регистрация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelOfRegistration;
        private Label LabelOfFirstName;
        private TextBox TextBoxOfName;
        private Label LabelOfSurname;
        private TextBox TextBoxOfSurname;
        private TextBox TextBoxOfPatronymic;
        private Label LabelOfLogin;
        private TextBox TextBoxOfLogin;
        private Label LabelOfPassword;
        private TextBox TextBoxOfPassword;
        private Label LabelOfPasswordConfirmation;
        private TextBox TextBoxOfPasswordConfirmation;
        private Button ButtonOfRegistration;
        private Label LabelOfAuthorization;
        private Label LabelOfPatronymicInfo;
        private Label LabelOfPatronymic;
    }
}