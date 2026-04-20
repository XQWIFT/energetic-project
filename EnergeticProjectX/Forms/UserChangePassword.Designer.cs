namespace UserChangePasswordForm
{
    partial class UserChangePassword
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
            labelOfChangePassword = new Label();
            labelOfOldPassword = new Label();
            labelOfNewPassword = new Label();
            labelOfСonfirmation = new Label();
            ButtonOfSaveInfo = new Button();
            ButtonOfCancel = new Button();
            textBoxForOldPassword = new TextBox();
            textBoxForNewPassword = new TextBox();
            textBoxOfConfirmation = new TextBox();
            SuspendLayout();
            // 
            // labelOfChangePassword
            // 
            labelOfChangePassword.AutoSize = true;
            labelOfChangePassword.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfChangePassword.Location = new Point(238, 47);
            labelOfChangePassword.Name = "labelOfChangePassword";
            labelOfChangePassword.Size = new Size(300, 54);
            labelOfChangePassword.TabIndex = 0;
            labelOfChangePassword.Text = "Смена пароля";
            // 
            // labelOfOldPassword
            // 
            labelOfOldPassword.AutoSize = true;
            labelOfOldPassword.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfOldPassword.Location = new Point(130, 129);
            labelOfOldPassword.Name = "labelOfOldPassword";
            labelOfOldPassword.Size = new Size(270, 45);
            labelOfOldPassword.TabIndex = 2;
            labelOfOldPassword.Text = "Старый пароль:";
            // 
            // labelOfNewPassword
            // 
            labelOfNewPassword.AutoSize = true;
            labelOfNewPassword.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfNewPassword.Location = new Point(130, 257);
            labelOfNewPassword.Name = "labelOfNewPassword";
            labelOfNewPassword.Size = new Size(262, 45);
            labelOfNewPassword.TabIndex = 3;
            labelOfNewPassword.Text = "Новый пароль:";
            // 
            // labelOfСonfirmation
            // 
            labelOfСonfirmation.AutoSize = true;
            labelOfСonfirmation.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfСonfirmation.Location = new Point(130, 386);
            labelOfСonfirmation.Name = "labelOfСonfirmation";
            labelOfСonfirmation.Size = new Size(408, 45);
            labelOfСonfirmation.TabIndex = 4;
            labelOfСonfirmation.Text = "Подтверждение пароля:";
            // 
            // ButtonOfSaveInfo
            // 
            ButtonOfSaveInfo.BackColor = Color.Transparent;
            ButtonOfSaveInfo.Enabled = false;
            ButtonOfSaveInfo.FlatAppearance.BorderColor = Color.Black;
            ButtonOfSaveInfo.FlatAppearance.BorderSize = 4;
            ButtonOfSaveInfo.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfSaveInfo.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfSaveInfo.FlatStyle = FlatStyle.Flat;
            ButtonOfSaveInfo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfSaveInfo.Location = new Point(130, 522);
            ButtonOfSaveInfo.Name = "ButtonOfSaveInfo";
            ButtonOfSaveInfo.Size = new Size(263, 74);
            ButtonOfSaveInfo.TabIndex = 6;
            ButtonOfSaveInfo.Text = "Сохранить";
            ButtonOfSaveInfo.UseVisualStyleBackColor = false;
            ButtonOfSaveInfo.Click += ButtonOfSaveInfo_Click;
            // 
            // ButtonOfCancel
            // 
            ButtonOfCancel.BackColor = Color.Transparent;
            ButtonOfCancel.FlatAppearance.BorderColor = Color.Black;
            ButtonOfCancel.FlatAppearance.BorderSize = 4;
            ButtonOfCancel.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfCancel.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfCancel.FlatStyle = FlatStyle.Flat;
            ButtonOfCancel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfCancel.Location = new Point(406, 522);
            ButtonOfCancel.Name = "ButtonOfCancel";
            ButtonOfCancel.Size = new Size(263, 74);
            ButtonOfCancel.TabIndex = 7;
            ButtonOfCancel.Text = "Отменить";
            ButtonOfCancel.UseVisualStyleBackColor = false;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
            // 
            // textBoxForOldPassword
            // 
            textBoxForOldPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxForOldPassword.Location = new Point(130, 188);
            textBoxForOldPassword.Name = "textBoxForOldPassword";
            textBoxForOldPassword.Size = new Size(539, 45);
            textBoxForOldPassword.TabIndex = 8;
            textBoxForOldPassword.UseSystemPasswordChar = true;
            // 
            // textBoxForNewPassword
            // 
            textBoxForNewPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxForNewPassword.Location = new Point(130, 317);
            textBoxForNewPassword.Name = "textBoxForNewPassword";
            textBoxForNewPassword.Size = new Size(539, 45);
            textBoxForNewPassword.TabIndex = 9;
            textBoxForNewPassword.UseSystemPasswordChar = true;
            // 
            // textBoxOfConfirmation
            // 
            textBoxOfConfirmation.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfConfirmation.Location = new Point(130, 445);
            textBoxOfConfirmation.Name = "textBoxOfConfirmation";
            textBoxOfConfirmation.Size = new Size(539, 45);
            textBoxOfConfirmation.TabIndex = 10;
            textBoxOfConfirmation.UseSystemPasswordChar = true;
            // 
            // UserChangePassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(800, 698);
            Controls.Add(textBoxOfConfirmation);
            Controls.Add(textBoxForNewPassword);
            Controls.Add(textBoxForOldPassword);
            Controls.Add(ButtonOfCancel);
            Controls.Add(ButtonOfSaveInfo);
            Controls.Add(labelOfСonfirmation);
            Controls.Add(labelOfNewPassword);
            Controls.Add(labelOfOldPassword);
            Controls.Add(labelOfChangePassword);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Смена пароля";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelOfChangePassword;
        private Label labelOfOldPassword;
        private Label labelOfNewPassword;
        private Label labelOfСonfirmation;
        private Button ButtonOfSaveInfo;
        private Button ButtonOfCancel;
        private TextBox textBoxForOldPassword;
        private TextBox textBoxForNewPassword;
        private TextBox textBoxOfConfirmation;
    }
}