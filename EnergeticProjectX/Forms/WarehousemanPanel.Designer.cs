namespace EnergeticProjectX.Forms
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
            LabelOfProducts = new Label();
            LabelOfRole = new Label();
            LabelOfLoginAs = new Label();
            LabelOfCompanyName = new Label();
            ButtonOfChangePassword = new Button();
            ButtonOfMakingShipment = new Button();
            LabelOfAccount = new Label();
            LabelOfSupplies = new Label();
            ButtonOfSupply = new Button();
            ButtonOfSettings = new Button();
            LabelOfFullName = new Label();
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
            ButtonOfLogOut.TabIndex = 4;
            ButtonOfLogOut.Text = "Выйти из аккаунта";
            ButtonOfLogOut.UseVisualStyleBackColor = true;
            ButtonOfLogOut.Click += ButtonOfLogOut_Click;
            ButtonOfLogOut.Enter += TabSelection_Enter;
            ButtonOfLogOut.Leave += TabSelection_Leave;
            // 
            // ShipmentsAndCustomers
            // 
            ShipmentsAndCustomers.AutoSize = true;
            ShipmentsAndCustomers.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ShipmentsAndCustomers.Location = new Point(310, 291);
            ShipmentsAndCustomers.Name = "ShipmentsAndCustomers";
            ShipmentsAndCustomers.Size = new Size(162, 45);
            ShipmentsAndCustomers.TabIndex = 0;
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
            ButtonOfProductCatalog.TabIndex = 1;
            ButtonOfProductCatalog.Text = "Каталог товаров";
            ButtonOfProductCatalog.UseVisualStyleBackColor = true;
            ButtonOfProductCatalog.Click += ButtonOfProductCatalog_Click;
            ButtonOfProductCatalog.Enter += TabSelection_Enter;
            ButtonOfProductCatalog.Leave += TabSelection_Leave;
            // 
            // LabelOfProducts
            // 
            LabelOfProducts.AutoSize = true;
            LabelOfProducts.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfProducts.Location = new Point(256, 183);
            LabelOfProducts.Name = "LabelOfProducts";
            LabelOfProducts.Size = new Size(266, 45);
            LabelOfProducts.TabIndex = 0;
            LabelOfProducts.Text = "Товары и склад";
            // 
            // LabelOfRole
            // 
            LabelOfRole.AutoSize = true;
            LabelOfRole.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfRole.Location = new Point(310, 68);
            LabelOfRole.Name = "LabelOfRole";
            LabelOfRole.Size = new Size(204, 45);
            LabelOfRole.TabIndex = 0;
            LabelOfRole.Text = "Кладовщик";
            // 
            // LabelOfLoginAs
            // 
            LabelOfLoginAs.AutoSize = true;
            LabelOfLoginAs.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfLoginAs.Location = new Point(58, 68);
            LabelOfLoginAs.Name = "LabelOfLoginAs";
            LabelOfLoginAs.Size = new Size(254, 45);
            LabelOfLoginAs.TabIndex = 0;
            LabelOfLoginAs.Text = "Вы вошли как:";
            // 
            // LabelOfCompanyName
            // 
            LabelOfCompanyName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfCompanyName.Location = new Point(29, 21);
            LabelOfCompanyName.Name = "LabelOfCompanyName";
            LabelOfCompanyName.Size = new Size(738, 56);
            LabelOfCompanyName.TabIndex = 0;
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
            ButtonOfChangePassword.TabIndex = 3;
            ButtonOfChangePassword.Text = "Сменить пароль";
            ButtonOfChangePassword.UseVisualStyleBackColor = true;
            ButtonOfChangePassword.Click += ButtonOfChangePassword_Click;
            ButtonOfChangePassword.Enter += TabSelection_Enter;
            ButtonOfChangePassword.Leave += TabSelection_Leave;
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
            ButtonOfMakingShipment.TabIndex = 2;
            ButtonOfMakingShipment.Text = "Оформление отгрузки";
            ButtonOfMakingShipment.UseVisualStyleBackColor = true;
            ButtonOfMakingShipment.Click += ButtonOfMakingShipment_Click;
            ButtonOfMakingShipment.Enter += TabSelection_Enter;
            ButtonOfMakingShipment.Leave += TabSelection_Leave;
            // 
            // LabelOfAccount
            // 
            LabelOfAccount.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfAccount.Location = new Point(310, 400);
            LabelOfAccount.Name = "LabelOfAccount";
            LabelOfAccount.Size = new Size(152, 51);
            LabelOfAccount.TabIndex = 0;
            LabelOfAccount.Text = "Аккаунт";
            // 
            // LabelOfSupplies
            // 
            LabelOfSupplies.AutoSize = true;
            LabelOfSupplies.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfSupplies.Location = new Point(294, 580);
            LabelOfSupplies.Name = "LabelOfSupplies";
            LabelOfSupplies.Size = new Size(168, 45);
            LabelOfSupplies.TabIndex = 0;
            LabelOfSupplies.Text = "Поставки";
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
            ButtonOfSupply.TabIndex = 5;
            ButtonOfSupply.Text = "Оформить поставку";
            ButtonOfSupply.UseVisualStyleBackColor = true;
            ButtonOfSupply.Click += ButtonOfSupply_Click;
            ButtonOfSupply.Enter += TabSelection_Enter;
            ButtonOfSupply.Leave += TabSelection_Leave;
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
            ButtonOfSettings.TabIndex = 6;
            ButtonOfSettings.Text = "Настройки";
            ButtonOfSettings.UseVisualStyleBackColor = true;
            ButtonOfSettings.Click += ButtonOfSettings_Click;
            ButtonOfSettings.Enter += TabSelection_Enter;
            ButtonOfSettings.Leave += TabSelection_Leave;
            // 
            // LabelOfFullName
            // 
            LabelOfFullName.AutoSize = true;
            LabelOfFullName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfFullName.Location = new Point(58, 113);
            LabelOfFullName.Name = "LabelOfFullName";
            LabelOfFullName.Size = new Size(20, 90);
            LabelOfFullName.TabIndex = 0;
            LabelOfFullName.Text = "\r\n\r\n";
            // 
            // WarehousemanPanel
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(802, 793);
            Controls.Add(LabelOfFullName);
            Controls.Add(ButtonOfSettings);
            Controls.Add(ButtonOfSupply);
            Controls.Add(LabelOfSupplies);
            Controls.Add(LabelOfAccount);
            Controls.Add(ButtonOfMakingShipment);
            Controls.Add(ButtonOfChangePassword);
            Controls.Add(ButtonOfLogOut);
            Controls.Add(ShipmentsAndCustomers);
            Controls.Add(ButtonOfProductCatalog);
            Controls.Add(LabelOfProducts);
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
        private Label LabelOfProducts;
        private Label LabelOfRole;
        private Label LabelOfLoginAs;
        private Label LabelOfCompanyName;
        private Button ButtonOfChangePassword;
        private Button ButtonOfMakingShipment;
        private Label LabelOfAccount;
        private Label LabelOfSupplies;
        private Button ButtonOfSupply;
        private Button ButtonOfSettings;
        private Label LabelOfFullName;
    }
}