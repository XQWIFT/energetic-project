namespace EnergeticProjectX.Forms
{
    partial class Settings
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
            LabelOfSettings = new Label();
            LabelOfCurrency = new Label();
            LabelOfUploadDate = new Label();
            LabelOfEquivalentInRUB = new Label();
            TextBoxOfExchangeRate = new TextBox();
            TextBoxOfCurrenciesUpload = new TextBox();
            ButtonOfSaveChanges = new Button();
            ButtonOfCancel = new Button();
            ComboBoxOfCurrency = new ComboBox();
            SuspendLayout();
            // 
            // LabelOfSettings
            // 
            LabelOfSettings.AutoSize = true;
            LabelOfSettings.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfSettings.Location = new Point(247, 138);
            LabelOfSettings.Name = "LabelOfSettings";
            LabelOfSettings.Size = new Size(513, 54);
            LabelOfSettings.TabIndex = 0;
            LabelOfSettings.Text = "Настройки пользователя";
            // 
            // LabelOfCurrency
            // 
            LabelOfCurrency.AutoSize = true;
            LabelOfCurrency.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfCurrency.Location = new Point(89, 237);
            LabelOfCurrency.Name = "LabelOfCurrency";
            LabelOfCurrency.Size = new Size(305, 48);
            LabelOfCurrency.TabIndex = 0;
            LabelOfCurrency.Text = "Текущая валюта";
            // 
            // LabelOfUploadDate
            // 
            LabelOfUploadDate.AutoSize = true;
            LabelOfUploadDate.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfUploadDate.Location = new Point(89, 420);
            LabelOfUploadDate.Name = "LabelOfUploadDate";
            LabelOfUploadDate.Size = new Size(346, 48);
            LabelOfUploadDate.TabIndex = 0;
            LabelOfUploadDate.Text = "Обновление курса";
            // 
            // LabelOfEquivalentInRUB
            // 
            LabelOfEquivalentInRUB.AutoSize = true;
            LabelOfEquivalentInRUB.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfEquivalentInRUB.Location = new Point(89, 331);
            LabelOfEquivalentInRUB.Name = "LabelOfEquivalentInRUB";
            LabelOfEquivalentInRUB.Size = new Size(293, 48);
            LabelOfEquivalentInRUB.TabIndex = 0;
            LabelOfEquivalentInRUB.Text = "Валютный курс";
            // 
            // TextBoxOfExchangeRate
            // 
            TextBoxOfExchangeRate.BackColor = SystemColors.Window;
            TextBoxOfExchangeRate.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfExchangeRate.Location = new Point(458, 331);
            TextBoxOfExchangeRate.Name = "TextBoxOfExchangeRate";
            TextBoxOfExchangeRate.ReadOnly = true;
            TextBoxOfExchangeRate.Size = new Size(446, 50);
            TextBoxOfExchangeRate.TabIndex = 2;
            // 
            // TextBoxOfCurrenciesUpload
            // 
            TextBoxOfCurrenciesUpload.BackColor = SystemColors.Window;
            TextBoxOfCurrenciesUpload.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfCurrenciesUpload.Location = new Point(458, 420);
            TextBoxOfCurrenciesUpload.Name = "TextBoxOfCurrenciesUpload";
            TextBoxOfCurrenciesUpload.ReadOnly = true;
            TextBoxOfCurrenciesUpload.Size = new Size(446, 50);
            TextBoxOfCurrenciesUpload.TabIndex = 3;
            // 
            // ButtonOfSaveChanges
            // 
            ButtonOfSaveChanges.Enabled = false;
            ButtonOfSaveChanges.FlatAppearance.BorderColor = Color.Black;
            ButtonOfSaveChanges.FlatAppearance.BorderSize = 4;
            ButtonOfSaveChanges.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfSaveChanges.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfSaveChanges.FlatStyle = FlatStyle.Flat;
            ButtonOfSaveChanges.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfSaveChanges.Location = new Point(128, 528);
            ButtonOfSaveChanges.Name = "ButtonOfSaveChanges";
            ButtonOfSaveChanges.Size = new Size(333, 77);
            ButtonOfSaveChanges.TabIndex = 4;
            ButtonOfSaveChanges.Text = "Сохранить";
            ButtonOfSaveChanges.UseVisualStyleBackColor = true;
            ButtonOfSaveChanges.Click += ButtonOfSaveChanges_Click;
            ButtonOfSaveChanges.Enter += TabSelection_Enter;
            ButtonOfSaveChanges.Leave += TabSelection_Leave;
            // 
            // ButtonOfCancel
            // 
            ButtonOfCancel.FlatAppearance.BorderColor = Color.Black;
            ButtonOfCancel.FlatAppearance.BorderSize = 4;
            ButtonOfCancel.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfCancel.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfCancel.FlatStyle = FlatStyle.Flat;
            ButtonOfCancel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfCancel.Location = new Point(483, 528);
            ButtonOfCancel.Name = "ButtonOfCancel";
            ButtonOfCancel.Size = new Size(349, 77);
            ButtonOfCancel.TabIndex = 5;
            ButtonOfCancel.Text = "Отменить";
            ButtonOfCancel.UseVisualStyleBackColor = true;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
            ButtonOfCancel.Enter += TabSelection_Enter;
            ButtonOfCancel.Leave += TabSelection_Leave;
            // 
            // ComboBoxOfCurrency
            // 
            ComboBoxOfCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOfCurrency.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ComboBoxOfCurrency.FormattingEnabled = true;
            ComboBoxOfCurrency.Location = new Point(458, 237);
            ComboBoxOfCurrency.Name = "ComboBoxOfCurrency";
            ComboBoxOfCurrency.Size = new Size(446, 53);
            ComboBoxOfCurrency.TabIndex = 1;
            ComboBoxOfCurrency.SelectedIndexChanged += ComboBoxOfCurrency_SelectedIndexChanged;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(972, 790);
            Controls.Add(ComboBoxOfCurrency);
            Controls.Add(ButtonOfCancel);
            Controls.Add(ButtonOfSaveChanges);
            Controls.Add(TextBoxOfCurrenciesUpload);
            Controls.Add(TextBoxOfExchangeRate);
            Controls.Add(LabelOfEquivalentInRUB);
            Controls.Add(LabelOfUploadDate);
            Controls.Add(LabelOfCurrency);
            Controls.Add(LabelOfSettings);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Settings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Настройки пользователя";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelOfSettings;
        private Label LabelOfCurrency;
        private Label LabelOfUploadDate;
        private Label LabelOfEquivalentInRUB;
        private TextBox TextBoxOfExchangeRate;
        private TextBox TextBoxOfCurrenciesUpload;
        private Button ButtonOfSaveChanges;
        private Button ButtonOfCancel;
        private ComboBox ComboBoxOfCurrency;
    }
}