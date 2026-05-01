namespace EnergeticProjectX.Forms
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
            LabelOfChangePassword = new Label();
            LabelOfOldPassword = new Label();
            LabelOfNewPassword = new Label();
            LabelOfСonfirmation = new Label();
            ButtonOfSaveInfo = new Button();
            ButtonOfCancel = new Button();
            TextBoxForOldPassword = new TextBox();
            TextBoxForNewPassword = new TextBox();
            TextBoxOfConfirmation = new TextBox();
            SuspendLayout();
            // 
            // LabelOfChangePassword
            // 
            LabelOfChangePassword.AutoSize = true;
            LabelOfChangePassword.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfChangePassword.Location = new Point(249, 57);
            LabelOfChangePassword.Name = "LabelOfChangePassword";
            LabelOfChangePassword.Size = new Size(300, 54);
            LabelOfChangePassword.TabIndex = 0;
            LabelOfChangePassword.Text = "Смена пароля";
            // 
            // LabelOfOldPassword
            // 
            LabelOfOldPassword.AutoSize = true;
            LabelOfOldPassword.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfOldPassword.Location = new Point(130, 129);
            LabelOfOldPassword.Name = "LabelOfOldPassword";
            LabelOfOldPassword.Size = new Size(270, 45);
            LabelOfOldPassword.TabIndex = 0;
            LabelOfOldPassword.Text = "Старый пароль:";
            // 
            // LabelOfNewPassword
            // 
            LabelOfNewPassword.AutoSize = true;
            LabelOfNewPassword.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfNewPassword.Location = new Point(130, 257);
            LabelOfNewPassword.Name = "LabelOfNewPassword";
            LabelOfNewPassword.Size = new Size(262, 45);
            LabelOfNewPassword.TabIndex = 0;
            LabelOfNewPassword.Text = "Новый пароль:";
            // 
            // LabelOfСonfirmation
            // 
            LabelOfСonfirmation.AutoSize = true;
            LabelOfСonfirmation.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfСonfirmation.Location = new Point(130, 386);
            LabelOfСonfirmation.Name = "LabelOfСonfirmation";
            LabelOfСonfirmation.Size = new Size(408, 45);
            LabelOfСonfirmation.TabIndex = 0;
            LabelOfСonfirmation.Text = "Подтверждение пароля:";
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
            ButtonOfSaveInfo.TabIndex = 4;
            ButtonOfSaveInfo.Text = "Сохранить";
            ButtonOfSaveInfo.UseVisualStyleBackColor = false;
            ButtonOfSaveInfo.Click += ButtonOfSaveInfo_Click;
            ButtonOfSaveInfo.Enter += TabSelection_Enter;
            ButtonOfSaveInfo.Leave += TabSelection_Leave;
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
            ButtonOfCancel.TabIndex = 5;
            ButtonOfCancel.Text = "Отменить";
            ButtonOfCancel.UseVisualStyleBackColor = false;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
            ButtonOfCancel.Enter += TabSelection_Enter;
            ButtonOfCancel.Leave += TabSelection_Leave;
            // 
            // TextBoxForOldPassword
            // 
            TextBoxForOldPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxForOldPassword.Location = new Point(130, 188);
            TextBoxForOldPassword.Name = "TextBoxForOldPassword";
            TextBoxForOldPassword.Size = new Size(539, 45);
            TextBoxForOldPassword.TabIndex = 1;
            TextBoxForOldPassword.UseSystemPasswordChar = true;
            TextBoxForOldPassword.TextChanged += IsTextChanged;
            // 
            // TextBoxForNewPassword
            // 
            TextBoxForNewPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxForNewPassword.Location = new Point(130, 317);
            TextBoxForNewPassword.Name = "TextBoxForNewPassword";
            TextBoxForNewPassword.Size = new Size(539, 45);
            TextBoxForNewPassword.TabIndex = 2;
            TextBoxForNewPassword.UseSystemPasswordChar = true;
            TextBoxForNewPassword.TextChanged += IsTextChanged;
            // 
            // TextBoxOfConfirmation
            // 
            TextBoxOfConfirmation.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfConfirmation.Location = new Point(130, 445);
            TextBoxOfConfirmation.Name = "TextBoxOfConfirmation";
            TextBoxOfConfirmation.Size = new Size(539, 45);
            TextBoxOfConfirmation.TabIndex = 3;
            TextBoxOfConfirmation.UseSystemPasswordChar = true;
            TextBoxOfConfirmation.TextChanged += IsTextChanged;
            // 
            // UserChangePassword
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(800, 698);
            Controls.Add(TextBoxOfConfirmation);
            Controls.Add(TextBoxForNewPassword);
            Controls.Add(TextBoxForOldPassword);
            Controls.Add(ButtonOfCancel);
            Controls.Add(ButtonOfSaveInfo);
            Controls.Add(LabelOfСonfirmation);
            Controls.Add(LabelOfNewPassword);
            Controls.Add(LabelOfOldPassword);
            Controls.Add(LabelOfChangePassword);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Смена пароля";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelOfChangePassword;
        private Label LabelOfOldPassword;
        private Label LabelOfNewPassword;
        private Label LabelOfСonfirmation;
        private Button ButtonOfSaveInfo;
        private Button ButtonOfCancel;
        private TextBox TextBoxForOldPassword;
        private TextBox TextBoxForNewPassword;
        private TextBox TextBoxOfConfirmation;
    }
}