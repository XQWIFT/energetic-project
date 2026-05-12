namespace EnergeticProjectX.Forms
{
    partial class AdministratorMainMenu
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
            LabelOfCompanyName = new Label();
            LabelOfLoginAs = new Label();
            labelOfRole = new Label();
            LabelOfUserControls = new Label();
            ButtonListOfUsers = new Button();
            ButtonOfChangePassword = new Button();
            LabelOfProducts = new Label();
            ButtonOfProductCatalog = new Button();
            ButtonOfShipmentLog = new Button();
            ShipmentsAndCustomers = new Label();
            ButtonListOfClients = new Button();
            ButtonOfLogOut = new Button();
            LabelOfFullName = new Label();
            LabelOfAccountPossibilities = new Label();
            LableOfSupplies = new Label();
            ButtonOfMakingSupply = new Button();
            ButtonOfSettings = new Button();
            LabelOfUserRole = new Label();
            SuspendLayout();
            // 
            // LabelOfCompanyName
            // 
            LabelOfCompanyName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfCompanyName.Location = new Point(26, 16);
            LabelOfCompanyName.Margin = new Padding(2, 0, 2, 0);
            LabelOfCompanyName.Name = "LabelOfCompanyName";
            LabelOfCompanyName.Size = new Size(655, 45);
            LabelOfCompanyName.TabIndex = 0;
            LabelOfCompanyName.Text = " «ООО Птички-тупички | Складская система»";
            // 
            // LabelOfLoginAs
            // 
            LabelOfLoginAs.AutoSize = true;
            LabelOfLoginAs.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfLoginAs.Location = new Point(46, 61);
            LabelOfLoginAs.Margin = new Padding(2, 0, 2, 0);
            LabelOfLoginAs.Name = "LabelOfLoginAs";
            LabelOfLoginAs.Size = new Size(212, 37);
            LabelOfLoginAs.TabIndex = 0;
            LabelOfLoginAs.Text = "Вы вошли как:";
            // 
            // labelOfRole
            // 
            labelOfRole.AutoSize = true;
            labelOfRole.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfRole.Location = new Point(246, 61);
            labelOfRole.Margin = new Padding(2, 0, 2, 0);
            labelOfRole.Name = "labelOfRole";
            labelOfRole.Size = new Size(229, 37);
            labelOfRole.TabIndex = 2;
            labelOfRole.Text = "Администратор";
            // 
            // LabelOfUserControls
            // 
            LabelOfUserControls.AutoSize = true;
            LabelOfUserControls.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfUserControls.Location = new Point(258, 162);
            LabelOfUserControls.Margin = new Padding(2, 0, 2, 0);
            LabelOfUserControls.Name = "LabelOfUserControls";
            LabelOfUserControls.Size = new Size(207, 37);
            LabelOfUserControls.TabIndex = 0;
            LabelOfUserControls.Text = "Пользователи";
            // 
            // ButtonListOfUsers
            // 
            ButtonListOfUsers.FlatAppearance.BorderColor = Color.Black;
            ButtonListOfUsers.FlatAppearance.BorderSize = 4;
            ButtonListOfUsers.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonListOfUsers.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonListOfUsers.FlatStyle = FlatStyle.Flat;
            ButtonListOfUsers.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonListOfUsers.Location = new Point(180, 200);
            ButtonListOfUsers.Margin = new Padding(2, 2, 2, 2);
            ButtonListOfUsers.Name = "ButtonListOfUsers";
            ButtonListOfUsers.Size = new Size(351, 50);
            ButtonListOfUsers.TabIndex = 1;
            ButtonListOfUsers.Text = "Список пользователей";
            ButtonListOfUsers.UseVisualStyleBackColor = true;
            ButtonListOfUsers.Click += ButtonListOfUsers_Click;
            ButtonListOfUsers.Enter += TabSelection_Enter;
            ButtonListOfUsers.Leave += TabSelection_Leave;
            // 
            // ButtonOfChangePassword
            // 
            ButtonOfChangePassword.FlatAppearance.BorderColor = Color.Black;
            ButtonOfChangePassword.FlatAppearance.BorderSize = 4;
            ButtonOfChangePassword.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfChangePassword.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfChangePassword.FlatStyle = FlatStyle.Flat;
            ButtonOfChangePassword.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfChangePassword.Location = new Point(180, 546);
            ButtonOfChangePassword.Margin = new Padding(2, 2, 2, 2);
            ButtonOfChangePassword.Name = "ButtonOfChangePassword";
            ButtonOfChangePassword.Size = new Size(351, 46);
            ButtonOfChangePassword.TabIndex = 5;
            ButtonOfChangePassword.Text = "Сменить пароль";
            ButtonOfChangePassword.UseVisualStyleBackColor = true;
            ButtonOfChangePassword.Click += ButtonOfChangePassword_Click;
            ButtonOfChangePassword.Enter += TabSelection_Enter;
            ButtonOfChangePassword.Leave += TabSelection_Leave;
            // 
            // LabelOfProducts
            // 
            LabelOfProducts.AutoSize = true;
            LabelOfProducts.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfProducts.Location = new Point(246, 252);
            LabelOfProducts.Margin = new Padding(2, 0, 2, 0);
            LabelOfProducts.Name = "LabelOfProducts";
            LabelOfProducts.Size = new Size(225, 37);
            LabelOfProducts.TabIndex = 0;
            LabelOfProducts.Text = "Товары и склад";
            // 
            // ButtonOfProductCatalog
            // 
            ButtonOfProductCatalog.FlatAppearance.BorderColor = Color.Black;
            ButtonOfProductCatalog.FlatAppearance.BorderSize = 4;
            ButtonOfProductCatalog.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfProductCatalog.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfProductCatalog.FlatStyle = FlatStyle.Flat;
            ButtonOfProductCatalog.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfProductCatalog.Location = new Point(180, 290);
            ButtonOfProductCatalog.Margin = new Padding(2, 2, 2, 2);
            ButtonOfProductCatalog.Name = "ButtonOfProductCatalog";
            ButtonOfProductCatalog.Size = new Size(351, 49);
            ButtonOfProductCatalog.TabIndex = 2;
            ButtonOfProductCatalog.Text = "Каталог товаров";
            ButtonOfProductCatalog.UseVisualStyleBackColor = true;
            ButtonOfProductCatalog.Click += ButtonOfProductCatalog_Click;
            ButtonOfProductCatalog.Enter += TabSelection_Enter;
            ButtonOfProductCatalog.Leave += TabSelection_Leave;
            // 
            // ButtonOfShipmentLog
            // 
            ButtonOfShipmentLog.FlatAppearance.BorderColor = Color.Black;
            ButtonOfShipmentLog.FlatAppearance.BorderSize = 4;
            ButtonOfShipmentLog.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfShipmentLog.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfShipmentLog.FlatStyle = FlatStyle.Flat;
            ButtonOfShipmentLog.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfShipmentLog.Location = new Point(180, 387);
            ButtonOfShipmentLog.Margin = new Padding(2, 2, 2, 2);
            ButtonOfShipmentLog.Name = "ButtonOfShipmentLog";
            ButtonOfShipmentLog.Size = new Size(351, 50);
            ButtonOfShipmentLog.TabIndex = 3;
            ButtonOfShipmentLog.Text = "Журнал отгрузок";
            ButtonOfShipmentLog.UseVisualStyleBackColor = true;
            ButtonOfShipmentLog.Click += ButtonOfShipmentLog_Click;
            ButtonOfShipmentLog.Enter += TabSelection_Enter;
            ButtonOfShipmentLog.Leave += TabSelection_Leave;
            // 
            // ShipmentsAndCustomers
            // 
            ShipmentsAndCustomers.AutoSize = true;
            ShipmentsAndCustomers.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ShipmentsAndCustomers.Location = new Point(226, 349);
            ShipmentsAndCustomers.Margin = new Padding(2, 0, 2, 0);
            ShipmentsAndCustomers.Name = "ShipmentsAndCustomers";
            ShipmentsAndCustomers.Size = new Size(282, 37);
            ShipmentsAndCustomers.TabIndex = 0;
            ShipmentsAndCustomers.Text = "Отгрузки и клиенты";
            // 
            // ButtonListOfClients
            // 
            ButtonListOfClients.FlatAppearance.BorderColor = Color.Black;
            ButtonListOfClients.FlatAppearance.BorderSize = 4;
            ButtonListOfClients.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonListOfClients.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonListOfClients.FlatStyle = FlatStyle.Flat;
            ButtonListOfClients.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonListOfClients.Location = new Point(180, 442);
            ButtonListOfClients.Margin = new Padding(2, 2, 2, 2);
            ButtonListOfClients.Name = "ButtonListOfClients";
            ButtonListOfClients.Size = new Size(351, 55);
            ButtonListOfClients.TabIndex = 4;
            ButtonListOfClients.Text = "Список клиентов";
            ButtonListOfClients.UseVisualStyleBackColor = true;
            ButtonListOfClients.Click += ButtonOfClients_Click;
            ButtonListOfClients.Enter += TabSelection_Enter;
            ButtonListOfClients.Leave += TabSelection_Leave;
            // 
            // ButtonOfLogOut
            // 
            ButtonOfLogOut.FlatAppearance.BorderColor = Color.Black;
            ButtonOfLogOut.FlatAppearance.BorderSize = 4;
            ButtonOfLogOut.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfLogOut.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfLogOut.FlatStyle = FlatStyle.Flat;
            ButtonOfLogOut.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfLogOut.Location = new Point(180, 597);
            ButtonOfLogOut.Margin = new Padding(2, 2, 2, 2);
            ButtonOfLogOut.Name = "ButtonOfLogOut";
            ButtonOfLogOut.Size = new Size(351, 49);
            ButtonOfLogOut.TabIndex = 6;
            ButtonOfLogOut.Text = "Выйти из аккаунта";
            ButtonOfLogOut.UseVisualStyleBackColor = true;
            ButtonOfLogOut.Click += ButtonOfLogOut_Click;
            ButtonOfLogOut.Enter += TabSelection_Enter;
            ButtonOfLogOut.Leave += TabSelection_Leave;
            // 
            // LabelOfFullName
            // 
            LabelOfFullName.AutoSize = true;
            LabelOfFullName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfFullName.Location = new Point(46, 104);
            LabelOfFullName.Margin = new Padding(2, 0, 2, 0);
            LabelOfFullName.Name = "LabelOfFullName";
            LabelOfFullName.Size = new Size(0, 37);
            LabelOfFullName.TabIndex = 0;
            // 
            // LabelOfAccountPossibilities
            // 
            LabelOfAccountPossibilities.AutoSize = true;
            LabelOfAccountPossibilities.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfAccountPossibilities.Location = new Point(287, 507);
            LabelOfAccountPossibilities.Margin = new Padding(2, 0, 2, 0);
            LabelOfAccountPossibilities.Name = "LabelOfAccountPossibilities";
            LabelOfAccountPossibilities.Size = new Size(125, 37);
            LabelOfAccountPossibilities.TabIndex = 0;
            LabelOfAccountPossibilities.Text = "Аккаунт";
            // 
            // LableOfSupplies
            // 
            LableOfSupplies.AutoSize = true;
            LableOfSupplies.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LableOfSupplies.Location = new Point(287, 656);
            LableOfSupplies.Margin = new Padding(2, 0, 2, 0);
            LableOfSupplies.Name = "LableOfSupplies";
            LableOfSupplies.Size = new Size(143, 37);
            LableOfSupplies.TabIndex = 0;
            LableOfSupplies.Text = "Поставки";
            // 
            // ButtonOfMakingSupply
            // 
            ButtonOfMakingSupply.FlatAppearance.BorderColor = Color.Black;
            ButtonOfMakingSupply.FlatAppearance.BorderSize = 4;
            ButtonOfMakingSupply.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfMakingSupply.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfMakingSupply.FlatStyle = FlatStyle.Flat;
            ButtonOfMakingSupply.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfMakingSupply.Location = new Point(180, 694);
            ButtonOfMakingSupply.Margin = new Padding(2, 2, 2, 2);
            ButtonOfMakingSupply.Name = "ButtonOfMakingSupply";
            ButtonOfMakingSupply.Size = new Size(351, 51);
            ButtonOfMakingSupply.TabIndex = 7;
            ButtonOfMakingSupply.Text = "Оформить поставку";
            ButtonOfMakingSupply.UseVisualStyleBackColor = true;
            ButtonOfMakingSupply.Click += ButtonOfSupply_Click;
            ButtonOfMakingSupply.Enter += TabSelection_Enter;
            ButtonOfMakingSupply.Leave += TabSelection_Leave;
            // 
            // ButtonOfSettings
            // 
            ButtonOfSettings.FlatAppearance.BorderColor = Color.Black;
            ButtonOfSettings.FlatAppearance.BorderSize = 4;
            ButtonOfSettings.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfSettings.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfSettings.FlatStyle = FlatStyle.Flat;
            ButtonOfSettings.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfSettings.Location = new Point(180, 750);
            ButtonOfSettings.Margin = new Padding(2, 2, 2, 2);
            ButtonOfSettings.Name = "ButtonOfSettings";
            ButtonOfSettings.Size = new Size(351, 49);
            ButtonOfSettings.TabIndex = 8;
            ButtonOfSettings.Text = "Настройки";
            ButtonOfSettings.UseVisualStyleBackColor = true;
            ButtonOfSettings.Click += ButtonOfSettings_Click;
            ButtonOfSettings.Enter += TabSelection_Enter;
            ButtonOfSettings.Leave += TabSelection_Leave;
            // 
            // LabelOfUserRole
            // 
            LabelOfUserRole.AutoSize = true;
            LabelOfUserRole.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfUserRole.Location = new Point(246, 61);
            LabelOfUserRole.Margin = new Padding(2, 0, 2, 0);
            LabelOfUserRole.Name = "LabelOfUserRole";
            LabelOfUserRole.Size = new Size(229, 37);
            LabelOfUserRole.TabIndex = 0;
            LabelOfUserRole.Text = "Администратор";
            // 
            // AdministratorMainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(703, 814);
            Controls.Add(ButtonOfSettings);
            Controls.Add(ButtonOfMakingSupply);
            Controls.Add(LableOfSupplies);
            Controls.Add(LabelOfAccountPossibilities);
            Controls.Add(LabelOfFullName);
            Controls.Add(ButtonOfLogOut);
            Controls.Add(ButtonListOfClients);
            Controls.Add(ShipmentsAndCustomers);
            Controls.Add(ButtonOfShipmentLog);
            Controls.Add(ButtonOfProductCatalog);
            Controls.Add(LabelOfProducts);
            Controls.Add(ButtonOfChangePassword);
            Controls.Add(ButtonListOfUsers);
            Controls.Add(LabelOfUserControls);
            Controls.Add(LabelOfUserRole);
            Controls.Add(labelOfRole);
            Controls.Add(LabelOfLoginAs);
            Controls.Add(LabelOfCompanyName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            Name = "AdministratorMainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Панель управления (Администратор)";
            ResumeLayout(false);
            PerformLayout();

        }

        private Label LabelOfCompanyName;
        private Label LabelOfLoginAs;
        private Label LabelOfUserControls;
        private Button ButtonListOfUsers;
        private Button ButtonOfChangePassword;
        private Label LabelOfProducts;
        private Button ButtonOfProductCatalog;
        private Button ButtonOfShipmentLog;
        private Label ShipmentsAndCustomers;
        private Button ButtonListOfClients;
        private Button ButtonOfLogOut;
        private Label labelOfRole;
        private Label LabelOfFullName;
        private Label LabelOfAccountPossibilities;
        private Label LableOfSupplies;
        private Button ButtonOfMakingSupply;
        private Button ButtonOfSettings;
        private Label LabelOfUserRole;
    }

        #endregion
 }