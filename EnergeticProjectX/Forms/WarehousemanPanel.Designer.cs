namespace WarehousemanPanelForm
{
    partial class WarehousemanPanel
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
            ButtonOfLogOut = new Button();
            ShipmentsAndCustomers = new Label();
            ButtonOfProductCatalog = new Button();
            labelOfProducts = new Label();
            LabelOfRole = new Label();
            LabelOfLoginAs = new Label();
            LabelOfCompanyName = new Label();
            ButtonOfChangePassword = new Button();
            ButtonOfMakingShipment = new Button();
            labelOfAccount = new Label();
            label1 = new Label();
            ButtonOfSupply = new Button();
            ButtonOfSettings = new Button();
            labelOfFullName = new Label();
            SuspendLayout();
            // 
            // ButtonOfLogOut
            // 
            ButtonOfLogOut.FlatAppearance.BorderColor = Color.Black;
            ButtonOfLogOut.FlatAppearance.BorderSize = 4;
            ButtonOfLogOut.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfLogOut.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfLogOut.FlatStyle = FlatStyle.Flat;
            ButtonOfLogOut.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfLogOut.Location = new Point(150, 518);
            ButtonOfLogOut.Name = "ButtonOfLogOut";
            ButtonOfLogOut.Size = new Size(470, 59);
            ButtonOfLogOut.TabIndex = 25;
            ButtonOfLogOut.Text = "Выйти из аккаунта";
            ButtonOfLogOut.UseVisualStyleBackColor = true;
            ButtonOfLogOut.Click += ButtonOfLogOut_Click;
            // 
            // ShipmentsAndCustomers
            // 
            ShipmentsAndCustomers.AutoSize = true;
            ShipmentsAndCustomers.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ShipmentsAndCustomers.Location = new Point(310, 291);
            ShipmentsAndCustomers.Name = "ShipmentsAndCustomers";
            ShipmentsAndCustomers.Size = new Size(162, 45);
            ShipmentsAndCustomers.TabIndex = 22;
            ShipmentsAndCustomers.Text = "Отгрузки";
            // 
            // ButtonOfProductCatalog
            // 
            ButtonOfProductCatalog.FlatAppearance.BorderColor = Color.Black;
            ButtonOfProductCatalog.FlatAppearance.BorderSize = 4;
            ButtonOfProductCatalog.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfProductCatalog.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfProductCatalog.FlatStyle = FlatStyle.Flat;
            ButtonOfProductCatalog.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfProductCatalog.Location = new Point(150, 231);
            ButtonOfProductCatalog.Name = "ButtonOfProductCatalog";
            ButtonOfProductCatalog.Size = new Size(470, 57);
            ButtonOfProductCatalog.TabIndex = 20;
            ButtonOfProductCatalog.Text = "Каталог товаров";
            ButtonOfProductCatalog.UseVisualStyleBackColor = true;
            ButtonOfProductCatalog.Click += ButtonOfProductCatalog_Click;
            // 
            // labelOfProducts
            // 
            labelOfProducts.AutoSize = true;
            labelOfProducts.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfProducts.Location = new Point(256, 183);
            labelOfProducts.Name = "labelOfProducts";
            labelOfProducts.Size = new Size(266, 45);
            labelOfProducts.TabIndex = 19;
            labelOfProducts.Text = "Товары и склад";
            // 
            // LabelOfRole
            // 
            LabelOfRole.AutoSize = true;
            LabelOfRole.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfRole.Location = new Point(310, 68);
            LabelOfRole.Name = "LabelOfRole";
            LabelOfRole.Size = new Size(204, 45);
            LabelOfRole.TabIndex = 15;
            LabelOfRole.Text = "Кладовщик";
            // 
            // LabelOfLoginAs
            // 
            LabelOfLoginAs.AutoSize = true;
            LabelOfLoginAs.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfLoginAs.Location = new Point(58, 68);
            LabelOfLoginAs.Name = "LabelOfLoginAs";
            LabelOfLoginAs.Size = new Size(254, 45);
            LabelOfLoginAs.TabIndex = 14;
            LabelOfLoginAs.Text = "Вы вошли как:";
            // 
            // LabelOfCompanyName
            // 
            LabelOfCompanyName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfCompanyName.Location = new Point(29, 21);
            LabelOfCompanyName.Name = "LabelOfCompanyName";
            LabelOfCompanyName.Size = new Size(738, 56);
            LabelOfCompanyName.TabIndex = 13;
            LabelOfCompanyName.Text = " «ООО Птички-тупички | Складская система»";
            // 
            // ButtonOfChangePassword
            // 
            ButtonOfChangePassword.FlatAppearance.BorderColor = Color.Black;
            ButtonOfChangePassword.FlatAppearance.BorderSize = 4;
            ButtonOfChangePassword.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfChangePassword.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfChangePassword.FlatStyle = FlatStyle.Flat;
            ButtonOfChangePassword.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfChangePassword.Location = new Point(150, 454);
            ButtonOfChangePassword.Name = "ButtonOfChangePassword";
            ButtonOfChangePassword.Size = new Size(470, 58);
            ButtonOfChangePassword.TabIndex = 26;
            ButtonOfChangePassword.Text = "Сменить пароль";
            ButtonOfChangePassword.UseVisualStyleBackColor = true;
            ButtonOfChangePassword.Click += ButtonOfChangePassword_Click;
            // 
            // ButtonOfMakingShipment
            // 
            ButtonOfMakingShipment.FlatAppearance.BorderColor = Color.Black;
            ButtonOfMakingShipment.FlatAppearance.BorderSize = 4;
            ButtonOfMakingShipment.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfMakingShipment.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfMakingShipment.FlatStyle = FlatStyle.Flat;
            ButtonOfMakingShipment.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfMakingShipment.Location = new Point(150, 339);
            ButtonOfMakingShipment.Name = "ButtonOfMakingShipment";
            ButtonOfMakingShipment.Size = new Size(470, 58);
            ButtonOfMakingShipment.TabIndex = 27;
            ButtonOfMakingShipment.Text = "Оформление отгрузки";
            ButtonOfMakingShipment.UseVisualStyleBackColor = true;
            ButtonOfMakingShipment.Click += ButtonOfMakingShipment_Click;
            // 
            // labelOfAccount
            // 
            labelOfAccount.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfAccount.Location = new Point(310, 400);
            labelOfAccount.Name = "labelOfAccount";
            labelOfAccount.Size = new Size(152, 51);
            labelOfAccount.TabIndex = 28;
            labelOfAccount.Text = "Аккаунт";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(294, 580);
            label1.Name = "label1";
            label1.Size = new Size(168, 45);
            label1.TabIndex = 29;
            label1.Text = "Поставки";
            // 
            // ButtonOfSupply
            // 
            ButtonOfSupply.FlatAppearance.BorderColor = Color.Black;
            ButtonOfSupply.FlatAppearance.BorderSize = 4;
            ButtonOfSupply.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfSupply.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfSupply.FlatStyle = FlatStyle.Flat;
            ButtonOfSupply.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfSupply.Location = new Point(150, 628);
            ButtonOfSupply.Name = "ButtonOfSupply";
            ButtonOfSupply.Size = new Size(470, 58);
            ButtonOfSupply.TabIndex = 30;
            ButtonOfSupply.Text = "Оформить поставку";
            ButtonOfSupply.UseVisualStyleBackColor = true;
            // 
            // ButtonOfSettings
            // 
            ButtonOfSettings.FlatAppearance.BorderColor = Color.Black;
            ButtonOfSettings.FlatAppearance.BorderSize = 4;
            ButtonOfSettings.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfSettings.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfSettings.FlatStyle = FlatStyle.Flat;
            ButtonOfSettings.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfSettings.Location = new Point(150, 692);
            ButtonOfSettings.Name = "ButtonOfSettings";
            ButtonOfSettings.Size = new Size(470, 58);
            ButtonOfSettings.TabIndex = 31;
            ButtonOfSettings.Text = "Настройки";
            ButtonOfSettings.UseVisualStyleBackColor = true;
            // 
            // labelOfFullName
            // 
            labelOfFullName.AutoSize = true;
            labelOfFullName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfFullName.Location = new Point(58, 113);
            labelOfFullName.Name = "labelOfFullName";
            labelOfFullName.Size = new Size(20, 90);
            labelOfFullName.TabIndex = 32;
            labelOfFullName.Text = "\r\n\r\n";
            // 
            // WarehousemanPanel
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(802, 793);
            Controls.Add(labelOfFullName);
            Controls.Add(ButtonOfSettings);
            Controls.Add(ButtonOfSupply);
            Controls.Add(label1);
            Controls.Add(labelOfAccount);
            Controls.Add(ButtonOfMakingShipment);
            Controls.Add(ButtonOfChangePassword);
            Controls.Add(ButtonOfLogOut);
            Controls.Add(ShipmentsAndCustomers);
            Controls.Add(ButtonOfProductCatalog);
            Controls.Add(labelOfProducts);
            Controls.Add(LabelOfRole);
            Controls.Add(LabelOfLoginAs);
            Controls.Add(LabelOfCompanyName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "WarehousemanPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Панель управления (Кладовщик)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonOfLogOut;
        private Label ShipmentsAndCustomers;
        private Button ButtonOfProductCatalog;
        private Label labelOfProducts;
        private Label LabelOfRole;
        private Label LabelOfLoginAs;
        private Label LabelOfCompanyName;
        private Button ButtonOfChangePassword;
        private Button ButtonOfMakingShipment;
        private Label labelOfAccount;
        private Label label1;
        private Button ButtonOfSupply;
        private Button ButtonOfSettings;
        private Label labelOfFullName;
    }
}