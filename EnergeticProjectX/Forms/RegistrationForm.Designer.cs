using EnergeticProjectX;

namespace Registration
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
            textBoxOfName = new TextBox();
            LabelOfSurname = new Label();
            textBoxOfSurname = new TextBox();
            textBoxOfPatronymic = new TextBox();
            LabelOfLogin = new Label();
            textBoxOfLogin = new TextBox();
            LabelOfPassword = new Label();
            textBoxOfPassword = new TextBox();
            LabelOfPasswordConfirmation = new Label();
            textBoxOfPasswordConfirmation = new TextBox();
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
            LabelOfRegistration.Location = new Point(271, 35);
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
            LabelOfFirstName.TabIndex = 1;
            LabelOfFirstName.Text = "Имя";
            // 
            // textBoxOfName
            // 
            textBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfName.Location = new Point(366, 128);
            textBoxOfName.Name = "textBoxOfName";
            textBoxOfName.Size = new Size(402, 45);
            textBoxOfName.TabIndex = 2;
            // 
            // LabelOfSurname
            // 
            LabelOfSurname.AutoSize = true;
            LabelOfSurname.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfSurname.Location = new Point(114, 193);
            LabelOfSurname.Name = "LabelOfSurname";
            LabelOfSurname.Size = new Size(166, 45);
            LabelOfSurname.TabIndex = 3;
            LabelOfSurname.Text = "Фамилия";
            // 
            // textBoxOfSurname
            // 
            textBoxOfSurname.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfSurname.Location = new Point(366, 193);
            textBoxOfSurname.Name = "textBoxOfSurname";
            textBoxOfSurname.Size = new Size(402, 45);
            textBoxOfSurname.TabIndex = 4;
            // 
            // textBoxOfPatronymic
            // 
            textBoxOfPatronymic.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfPatronymic.Location = new Point(366, 263);
            textBoxOfPatronymic.Name = "textBoxOfPatronymic";
            textBoxOfPatronymic.Size = new Size(402, 45);
            textBoxOfPatronymic.TabIndex = 6;
            // 
            // LabelOfLogin
            // 
            LabelOfLogin.AutoSize = true;
            LabelOfLogin.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfLogin.Location = new Point(114, 334);
            LabelOfLogin.Name = "LabelOfLogin";
            LabelOfLogin.Size = new Size(116, 45);
            LabelOfLogin.TabIndex = 7;
            LabelOfLogin.Text = "Логин";
            // 
            // textBoxOfLogin
            // 
            textBoxOfLogin.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfLogin.Location = new Point(366, 334);
            textBoxOfLogin.Name = "textBoxOfLogin";
            textBoxOfLogin.Size = new Size(402, 45);
            textBoxOfLogin.TabIndex = 8;
            // 
            // LabelOfPassword
            // 
            LabelOfPassword.AutoSize = true;
            LabelOfPassword.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfPassword.Location = new Point(114, 408);
            LabelOfPassword.Name = "LabelOfPassword";
            LabelOfPassword.Size = new Size(138, 45);
            LabelOfPassword.TabIndex = 9;
            LabelOfPassword.Text = "Пароль";
            // 
            // textBoxOfPassword
            // 
            textBoxOfPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfPassword.Location = new Point(366, 408);
            textBoxOfPassword.Name = "textBoxOfPassword";
            textBoxOfPassword.Size = new Size(402, 45);
            textBoxOfPassword.TabIndex = 10;
            textBoxOfPassword.UseSystemPasswordChar = true;
            // 
            // LabelOfPasswordConfirmation
            // 
            LabelOfPasswordConfirmation.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfPasswordConfirmation.Location = new Point(114, 470);
            LabelOfPasswordConfirmation.MaximumSize = new Size(250, 0);
            LabelOfPasswordConfirmation.Name = "LabelOfPasswordConfirmation";
            LabelOfPasswordConfirmation.Size = new Size(250, 97);
            LabelOfPasswordConfirmation.TabIndex = 11;
            LabelOfPasswordConfirmation.Text = "Пароль повторно";
            // 
            // textBoxOfPasswordConfirmation
            // 
            textBoxOfPasswordConfirmation.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfPasswordConfirmation.Location = new Point(366, 482);
            textBoxOfPasswordConfirmation.Name = "textBoxOfPasswordConfirmation";
            textBoxOfPasswordConfirmation.Size = new Size(402, 45);
            textBoxOfPasswordConfirmation.TabIndex = 12;
            textBoxOfPasswordConfirmation.UseSystemPasswordChar = true;
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
            ButtonOfRegistration.TabIndex = 13;
            ButtonOfRegistration.Text = "Зарегистрироваться";
            ButtonOfRegistration.UseVisualStyleBackColor = true;
            ButtonOfRegistration.Click += ButtonOfRegistration_Click;
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
            LabelOfPatronymicInfo.TabIndex = 15;
            LabelOfPatronymicInfo.Text = "*Отчество — необязательное поле";
            // 
            // LabelOfPatronymic
            // 
            LabelOfPatronymic.AutoSize = true;
            LabelOfPatronymic.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfPatronymic.Location = new Point(114, 263);
            LabelOfPatronymic.Name = "LabelOfPatronymic";
            LabelOfPatronymic.Size = new Size(164, 45);
            LabelOfPatronymic.TabIndex = 16;
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
            Controls.Add(textBoxOfPasswordConfirmation);
            Controls.Add(LabelOfPasswordConfirmation);
            Controls.Add(textBoxOfPassword);
            Controls.Add(LabelOfPassword);
            Controls.Add(textBoxOfLogin);
            Controls.Add(LabelOfLogin);
            Controls.Add(textBoxOfPatronymic);
            Controls.Add(textBoxOfSurname);
            Controls.Add(LabelOfSurname);
            Controls.Add(textBoxOfName);
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
        private TextBox textBoxOfName;
        private Label LabelOfSurname;
        private TextBox textBoxOfSurname;
        private TextBox textBoxOfPatronymic;
        private Label LabelOfLogin;
        private TextBox textBoxOfLogin;
        private Label LabelOfPassword;
        private TextBox textBoxOfPassword;
        private Label LabelOfPasswordConfirmation;
        private TextBox textBoxOfPasswordConfirmation;
        private Button ButtonOfRegistration;
        private Label LabelOfAuthorization;
        private Label LabelOfPatronymicInfo;
        private Label LabelOfPatronymic;
    }
}