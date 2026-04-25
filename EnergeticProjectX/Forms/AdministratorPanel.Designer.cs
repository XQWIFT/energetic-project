namespace AdministratorPanelForm
{
    partial class AdministratorPanel
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
            labelOfCompanyName = new Label();
            labelOfLoginAs = new Label();
            labelOfRole = new Label();
            labelOfUserControls = new Label();
            ButtonListOfUsers = new Button();
            ButtonOfChangePassword = new Button();
            labelOfProducts = new Label();
            ButtonOfProductCatalog = new Button();
            ButtonOfShipmentLog = new Button();
            ShipmentsAndCustomers = new Label();
            ButtonOfClients = new Button();
            ButtonOfLogOut = new Button();
            LabelOfFullName = new Label();
            AccountPossibilities = new Label();
            Supplies = new Label();
            ButtonOfSupply = new Button();
            ButtonOfSettings = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // labelOfCompanyName
            // 
            labelOfCompanyName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfCompanyName.Location = new Point(33, 20);
            labelOfCompanyName.Name = "labelOfCompanyName";
            labelOfCompanyName.Size = new Size(819, 56);
            labelOfCompanyName.TabIndex = 0;
            labelOfCompanyName.Text = " «ООО Птички-тупички | Складская система»";
            // 
            // labelOfLoginAs
            // 
            labelOfLoginAs.AutoSize = true;
            labelOfLoginAs.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfLoginAs.Location = new Point(58, 76);
            labelOfLoginAs.Name = "labelOfLoginAs";
            labelOfLoginAs.Size = new Size(254, 45);
            labelOfLoginAs.TabIndex = 1;
            labelOfLoginAs.Text = "Вы вошли как:";
            // 
            // labelOfRole
            // 
            labelOfRole.AutoSize = true;
            labelOfRole.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfRole.Location = new Point(307, 76);
            labelOfRole.Name = "labelOfRole";
            labelOfRole.Size = new Size(271, 45);
            labelOfRole.TabIndex = 2;
            labelOfRole.Text = "Администратор";
            // 
            // labelOfUserControls
            // 
            labelOfUserControls.AutoSize = true;
            labelOfUserControls.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfUserControls.Location = new Point(323, 202);
            labelOfUserControls.Name = "labelOfUserControls";
            labelOfUserControls.Size = new Size(243, 45);
            labelOfUserControls.TabIndex = 3;
            labelOfUserControls.Text = "Пользователи";
            // 
            // ButtonListOfUsers
            // 
            ButtonListOfUsers.FlatAppearance.BorderColor = Color.Black;
            ButtonListOfUsers.FlatAppearance.BorderSize = 3;
            ButtonListOfUsers.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonListOfUsers.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonListOfUsers.FlatStyle = FlatStyle.Flat;
            ButtonListOfUsers.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonListOfUsers.Location = new Point(225, 250);
            ButtonListOfUsers.Name = "ButtonListOfUsers";
            ButtonListOfUsers.Size = new Size(439, 62);
            ButtonListOfUsers.TabIndex = 4;
            ButtonListOfUsers.Text = "Список пользователей";
            ButtonListOfUsers.UseVisualStyleBackColor = true;
            ButtonListOfUsers.Click += ButtonListOfUsers_Click;
            // 
            // ButtonOfChangePassword
            // 
            ButtonOfChangePassword.FlatAppearance.BorderColor = Color.Black;
            ButtonOfChangePassword.FlatAppearance.BorderSize = 4;
            ButtonOfChangePassword.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfChangePassword.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfChangePassword.FlatStyle = FlatStyle.Flat;
            ButtonOfChangePassword.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfChangePassword.Location = new Point(225, 682);
            ButtonOfChangePassword.Name = "ButtonOfChangePassword";
            ButtonOfChangePassword.Size = new Size(439, 58);
            ButtonOfChangePassword.TabIndex = 5;
            ButtonOfChangePassword.Text = "Сменить пароль";
            ButtonOfChangePassword.UseVisualStyleBackColor = true;
            ButtonOfChangePassword.Click += ButtonOfChangePassword_Click;
            // 
            // labelOfProducts
            // 
            labelOfProducts.AutoSize = true;
            labelOfProducts.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfProducts.Location = new Point(307, 315);
            labelOfProducts.Name = "labelOfProducts";
            labelOfProducts.Size = new Size(266, 45);
            labelOfProducts.TabIndex = 6;
            labelOfProducts.Text = "Товары и склад";
            // 
            // ButtonOfProductCatalog
            // 
            ButtonOfProductCatalog.FlatAppearance.BorderColor = Color.Black;
            ButtonOfProductCatalog.FlatAppearance.BorderSize = 4;
            ButtonOfProductCatalog.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfProductCatalog.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfProductCatalog.FlatStyle = FlatStyle.Flat;
            ButtonOfProductCatalog.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfProductCatalog.Location = new Point(225, 363);
            ButtonOfProductCatalog.Name = "ButtonOfProductCatalog";
            ButtonOfProductCatalog.Size = new Size(439, 61);
            ButtonOfProductCatalog.TabIndex = 7;
            ButtonOfProductCatalog.Text = "Каталог товаров";
            ButtonOfProductCatalog.UseVisualStyleBackColor = true;
            ButtonOfProductCatalog.Click += ButtonOfProductCatalog_Click;
            // 
            // ButtonOfShipmentLog
            // 
            ButtonOfShipmentLog.FlatAppearance.BorderColor = Color.Black;
            ButtonOfShipmentLog.FlatAppearance.BorderSize = 4;
            ButtonOfShipmentLog.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfShipmentLog.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfShipmentLog.FlatStyle = FlatStyle.Flat;
            ButtonOfShipmentLog.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfShipmentLog.Location = new Point(225, 484);
            ButtonOfShipmentLog.Name = "ButtonOfShipmentLog";
            ButtonOfShipmentLog.Size = new Size(439, 62);
            ButtonOfShipmentLog.TabIndex = 8;
            ButtonOfShipmentLog.Text = "Журнал отгрузок";
            ButtonOfShipmentLog.UseVisualStyleBackColor = true;
            ButtonOfShipmentLog.Click += ButtonOfShipmentLog_Click;
            // 
            // ShipmentsAndCustomers
            // 
            ShipmentsAndCustomers.AutoSize = true;
            ShipmentsAndCustomers.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ShipmentsAndCustomers.Location = new Point(283, 436);
            ShipmentsAndCustomers.Name = "ShipmentsAndCustomers";
            ShipmentsAndCustomers.Size = new Size(336, 45);
            ShipmentsAndCustomers.TabIndex = 9;
            ShipmentsAndCustomers.Text = "Отгрузки и клиенты";
            // 
            // ButtonOfClients
            // 
            ButtonOfClients.FlatAppearance.BorderColor = Color.Black;
            ButtonOfClients.FlatAppearance.BorderSize = 4;
            ButtonOfClients.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfClients.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfClients.FlatStyle = FlatStyle.Flat;
            ButtonOfClients.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfClients.Location = new Point(225, 552);
            ButtonOfClients.Name = "ButtonOfClients";
            ButtonOfClients.Size = new Size(439, 69);
            ButtonOfClients.TabIndex = 10;
            ButtonOfClients.Text = "Список клиентов";
            ButtonOfClients.UseVisualStyleBackColor = true;
            ButtonOfClients.Click += ButtonOfClients_Click;
            // 
            // ButtonOfLogOut
            // 
            ButtonOfLogOut.FlatAppearance.BorderColor = Color.Black;
            ButtonOfLogOut.FlatAppearance.BorderSize = 4;
            ButtonOfLogOut.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfLogOut.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfLogOut.FlatStyle = FlatStyle.Flat;
            ButtonOfLogOut.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfLogOut.Location = new Point(225, 746);
            ButtonOfLogOut.Name = "ButtonOfLogOut";
            ButtonOfLogOut.Size = new Size(439, 61);
            ButtonOfLogOut.TabIndex = 12;
            ButtonOfLogOut.Text = "Выйти из аккаунта";
            ButtonOfLogOut.UseVisualStyleBackColor = true;
            ButtonOfLogOut.Click += ButtonOfLogOut_Click;
            // 
            // LabelOfFullName
            // 
            LabelOfFullName.AutoSize = true;
            LabelOfFullName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfFullName.Location = new Point(58, 130);
            LabelOfFullName.Name = "LabelOfFullName";
            LabelOfFullName.Size = new Size(0, 45);
            LabelOfFullName.TabIndex = 13;
            // 
            // AccountPossibilities
            // 
            AccountPossibilities.AutoSize = true;
            AccountPossibilities.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AccountPossibilities.Location = new Point(359, 634);
            AccountPossibilities.Name = "AccountPossibilities";
            AccountPossibilities.Size = new Size(148, 45);
            AccountPossibilities.TabIndex = 14;
            AccountPossibilities.Text = "Аккаунт";
            // 
            // Supplies
            // 
            Supplies.AutoSize = true;
            Supplies.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Supplies.Location = new Point(359, 820);
            Supplies.Name = "Supplies";
            Supplies.Size = new Size(168, 45);
            Supplies.TabIndex = 15;
            Supplies.Text = "Поставки";
            // 
            // ButtonOfSupply
            // 
            ButtonOfSupply.FlatAppearance.BorderColor = Color.Black;
            ButtonOfSupply.FlatAppearance.BorderSize = 4;
            ButtonOfSupply.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfSupply.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfSupply.FlatStyle = FlatStyle.Flat;
            ButtonOfSupply.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfSupply.Location = new Point(225, 868);
            ButtonOfSupply.Name = "ButtonOfSupply";
            ButtonOfSupply.Size = new Size(439, 64);
            ButtonOfSupply.TabIndex = 16;
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
            ButtonOfSettings.Location = new Point(225, 938);
            ButtonOfSettings.Name = "ButtonOfSettings";
            ButtonOfSettings.Size = new Size(439, 61);
            ButtonOfSettings.TabIndex = 17;
            ButtonOfSettings.Text = "Настройки";
            ButtonOfSettings.UseVisualStyleBackColor = true;
            ButtonOfSettings.Click += ButtonOfSettings_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(307, 76);
            label1.Name = "label1";
            label1.Size = new Size(271, 45);
            label1.TabIndex = 2;
            label1.Text = "Администратор";
            // 
            // AdministratorPanel
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(879, 1018);
            Controls.Add(ButtonOfSettings);
            Controls.Add(ButtonOfSupply);
            Controls.Add(Supplies);
            Controls.Add(AccountPossibilities);
            Controls.Add(LabelOfFullName);
            Controls.Add(ButtonOfLogOut);
            Controls.Add(ButtonOfClients);
            Controls.Add(ShipmentsAndCustomers);
            Controls.Add(ButtonOfShipmentLog);
            Controls.Add(ButtonOfProductCatalog);
            Controls.Add(labelOfProducts);
            Controls.Add(ButtonOfChangePassword);
            Controls.Add(ButtonListOfUsers);
            Controls.Add(labelOfUserControls);
            Controls.Add(label1);
            Controls.Add(labelOfRole);
            Controls.Add(labelOfLoginAs);
            Controls.Add(labelOfCompanyName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AdministratorPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Панель управления (Администратор)";
            ResumeLayout(false);
            PerformLayout();

        }

        private Label labelOfCompanyName;
        private Label labelOfLoginAs;
        private Label labelOfUserControls;
        private Button ButtonListOfUsers;
        private Button ButtonOfChangePassword;
        private Label labelOfProducts;
        private Button ButtonOfProductCatalog;
        private Button ButtonOfShipmentLog;
        private Label ShipmentsAndCustomers;
        private Button ButtonOfClients;
        private Button ButtonOfLogOut;
        private Label labelOfRole;
        private Label LabelOfFullName;
        private Label AccountPossibilities;
        private Label Supplies;
        private Button ButtonOfSupply;
        private Button ButtonOfSettings;
        private Label label1;
    }

        #endregion
 }