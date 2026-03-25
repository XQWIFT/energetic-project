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
            labelOfRegistration = new Label();
            labelOfName = new Label();
            textBoxOfName = new TextBox();
            labelOfSurname = new Label();
            textBoxOfSurname = new TextBox();
            labelOfPatronymic = new Label();
            textBoxOfPatronymic = new TextBox();
            labelOfLogin = new Label();
            textBoxOfLogin = new TextBox();
            labelOfPassword = new Label();
            textBoxOfPassword = new TextBox();
            labelOfPasswordToo = new Label();
            textBoxOfPasswordToo = new TextBox();
            buttonOfRegistration = new Button();
            buttonOfAuthorization = new Button();
            SuspendLayout();
            // 
            // labelOfRegistration
            // 
            labelOfRegistration.AutoSize = true;
            labelOfRegistration.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfRegistration.Location = new Point(269, 9);
            labelOfRegistration.Name = "labelOfRegistration";
            labelOfRegistration.Size = new Size(276, 60);
            labelOfRegistration.TabIndex = 0;
            labelOfRegistration.Text = "Регистрация";
            // 
            // labelOfName
            // 
            labelOfName.AutoSize = true;
            labelOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfName.Location = new Point(1, 101);
            labelOfName.Name = "labelOfName";
            labelOfName.Size = new Size(72, 38);
            labelOfName.TabIndex = 1;
            labelOfName.Text = "Имя";
            // 
            // textBoxOfName
            // 
            textBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfName.Location = new Point(193, 98);
            textBoxOfName.Name = "textBoxOfName";
            textBoxOfName.Size = new Size(603, 45);
            textBoxOfName.TabIndex = 2;
            // 
            // labelOfSurname
            // 
            labelOfSurname.AutoSize = true;
            labelOfSurname.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfSurname.Location = new Point(1, 194);
            labelOfSurname.Name = "labelOfSurname";
            labelOfSurname.Size = new Size(132, 38);
            labelOfSurname.TabIndex = 3;
            labelOfSurname.Text = "Фамилия";
            // 
            // textBoxOfSurname
            // 
            textBoxOfSurname.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfSurname.Location = new Point(193, 191);
            textBoxOfSurname.Name = "textBoxOfSurname";
            textBoxOfSurname.Size = new Size(603, 45);
            textBoxOfSurname.TabIndex = 4;
            // 
            // labelOfPatronymic
            // 
            labelOfPatronymic.AutoSize = true;
            labelOfPatronymic.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfPatronymic.Location = new Point(1, 284);
            labelOfPatronymic.Name = "labelOfPatronymic";
            labelOfPatronymic.Size = new Size(135, 38);
            labelOfPatronymic.TabIndex = 5;
            labelOfPatronymic.Text = "Отчество";
            // 
            // textBoxOfPatronymic
            // 
            textBoxOfPatronymic.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfPatronymic.Location = new Point(193, 284);
            textBoxOfPatronymic.Name = "textBoxOfPatronymic";
            textBoxOfPatronymic.Size = new Size(603, 45);
            textBoxOfPatronymic.TabIndex = 6;
            // 
            // labelOfLogin
            // 
            labelOfLogin.AutoSize = true;
            labelOfLogin.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfLogin.Location = new Point(1, 370);
            labelOfLogin.Name = "labelOfLogin";
            labelOfLogin.Size = new Size(95, 38);
            labelOfLogin.TabIndex = 7;
            labelOfLogin.Text = "Логин";
            // 
            // textBoxOfLogin
            // 
            textBoxOfLogin.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfLogin.Location = new Point(191, 370);
            textBoxOfLogin.Name = "textBoxOfLogin";
            textBoxOfLogin.Size = new Size(605, 45);
            textBoxOfLogin.TabIndex = 8;
            // 
            // labelOfPassword
            // 
            labelOfPassword.AutoSize = true;
            labelOfPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfPassword.Location = new Point(1, 448);
            labelOfPassword.Name = "labelOfPassword";
            labelOfPassword.Size = new Size(112, 38);
            labelOfPassword.TabIndex = 9;
            labelOfPassword.Text = "Пароль";
            // 
            // textBoxOfPassword
            // 
            textBoxOfPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfPassword.Location = new Point(191, 448);
            textBoxOfPassword.Name = "textBoxOfPassword";
            textBoxOfPassword.Size = new Size(605, 45);
            textBoxOfPassword.TabIndex = 10;
            textBoxOfPassword.UseSystemPasswordChar = true;
            // 
            // labelOfPasswordToo
            // 
            labelOfPasswordToo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfPasswordToo.Location = new Point(1, 524);
            labelOfPasswordToo.MaximumSize = new Size(250, 0);
            labelOfPasswordToo.Name = "labelOfPasswordToo";
            labelOfPasswordToo.Size = new Size(184, 81);
            labelOfPasswordToo.TabIndex = 11;
            labelOfPasswordToo.Text = "Подтвердите пароль";
            // 
            // textBoxOfPasswordToo
            // 
            textBoxOfPasswordToo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfPasswordToo.Location = new Point(191, 540);
            textBoxOfPasswordToo.Name = "textBoxOfPasswordToo";
            textBoxOfPasswordToo.Size = new Size(605, 45);
            textBoxOfPasswordToo.TabIndex = 12;
            textBoxOfPasswordToo.UseSystemPasswordChar = true;
            // 
            // buttonOfRegistration
            // 
            buttonOfRegistration.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfRegistration.Location = new Point(247, 722);
            buttonOfRegistration.Name = "buttonOfRegistration";
            buttonOfRegistration.Size = new Size(328, 74);
            buttonOfRegistration.TabIndex = 13;
            buttonOfRegistration.Text = "Зарегистрироваться";
            buttonOfRegistration.UseVisualStyleBackColor = true;
            buttonOfRegistration.Click += buttonOfRegistration_Click;
            // 
            // buttonOfAuthorization
            // 
            buttonOfAuthorization.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfAuthorization.Location = new Point(12, 650);
            buttonOfAuthorization.Name = "buttonOfAuthorization";
            buttonOfAuthorization.Size = new Size(804, 47);
            buttonOfAuthorization.TabIndex = 14;
            buttonOfAuthorization.Text = "Есть аккаунт? Пройти авторизацию";
            buttonOfAuthorization.UseVisualStyleBackColor = true;
            buttonOfAuthorization.Click += buttonOfAuthorization_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 825);
            Controls.Add(buttonOfAuthorization);
            Controls.Add(buttonOfRegistration);
            Controls.Add(textBoxOfPasswordToo);
            Controls.Add(labelOfPasswordToo);
            Controls.Add(textBoxOfPassword);
            Controls.Add(labelOfPassword);
            Controls.Add(textBoxOfLogin);
            Controls.Add(labelOfLogin);
            Controls.Add(textBoxOfPatronymic);
            Controls.Add(labelOfPatronymic);
            Controls.Add(textBoxOfSurname);
            Controls.Add(labelOfSurname);
            Controls.Add(textBoxOfName);
            Controls.Add(labelOfName);
            Controls.Add(labelOfRegistration);
            MaximizeBox = false;
            Name = "RegistrationForm";
            Text = "Регистрация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelOfRegistration;
        private Label labelOfName;
        private TextBox textBoxOfName;
        private Label labelOfSurname;
        private TextBox textBoxOfSurname;
        private Label labelOfPatronymic;
        private TextBox textBoxOfPatronymic;
        private Label labelOfLogin;
        private TextBox textBoxOfLogin;
        private Label labelOfPassword;
        private TextBox textBoxOfPassword;
        private Label labelOfPasswordToo;
        private TextBox textBoxOfPasswordToo;
        private Button buttonOfRegistration;
        private Button buttonOfAuthorization;
    }
}