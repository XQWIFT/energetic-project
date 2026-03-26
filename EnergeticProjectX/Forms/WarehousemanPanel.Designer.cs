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
            buttonOfLogOut = new Button();
            labelOfLine = new Label();
            ShipmentsAndCustomers = new Label();
            buttonOfProductCatalog = new Button();
            labelOfProducts = new Label();
            labelOfRole = new Label();
            labelOfLoginAs = new Label();
            labelOfCompanyName = new Label();
            buttonOfChangePassword = new Button();
            MakingShipment = new Button();
            labelOfAccount = new Label();
            SuspendLayout();
            // 
            // buttonOfLogOut
            // 
            buttonOfLogOut.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfLogOut.Location = new Point(165, 527);
            buttonOfLogOut.Name = "buttonOfLogOut";
            buttonOfLogOut.Size = new Size(470, 44);
            buttonOfLogOut.TabIndex = 25;
            buttonOfLogOut.Text = "Выйти из аккаунта";
            buttonOfLogOut.UseVisualStyleBackColor = true;
            buttonOfLogOut.Click += buttonOfLogOut_Click;
            // 
            // labelOfLine
            // 
            labelOfLine.AutoSize = true;
            labelOfLine.Location = new Point(207, 371);
            labelOfLine.Name = "labelOfLine";
            labelOfLine.Size = new Size(383, 25);
            labelOfLine.TabIndex = 24;
            labelOfLine.Text = "_____________________________________________________";
            // 
            // ShipmentsAndCustomers
            // 
            ShipmentsAndCustomers.AutoSize = true;
            ShipmentsAndCustomers.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ShipmentsAndCustomers.Location = new Point(325, 257);
            ShipmentsAndCustomers.Name = "ShipmentsAndCustomers";
            ShipmentsAndCustomers.Size = new Size(152, 45);
            ShipmentsAndCustomers.TabIndex = 22;
            ShipmentsAndCustomers.Text = "Отгрузки";
            // 
            // buttonOfProductCatalog
            // 
            buttonOfProductCatalog.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfProductCatalog.Location = new Point(165, 188);
            buttonOfProductCatalog.Name = "buttonOfProductCatalog";
            buttonOfProductCatalog.Size = new Size(470, 55);
            buttonOfProductCatalog.TabIndex = 20;
            buttonOfProductCatalog.Text = "Каталог товаров";
            buttonOfProductCatalog.UseVisualStyleBackColor = true;
            // 
            // labelOfProducts
            // 
            labelOfProducts.AutoSize = true;
            labelOfProducts.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfProducts.Location = new Point(283, 130);
            labelOfProducts.Name = "labelOfProducts";
            labelOfProducts.Size = new Size(250, 45);
            labelOfProducts.TabIndex = 19;
            labelOfProducts.Text = "Товары и склад";
            // 
            // labelOfRole
            // 
            labelOfRole.AutoSize = true;
            labelOfRole.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfRole.Location = new Point(207, 77);
            labelOfRole.Name = "labelOfRole";
            labelOfRole.Size = new Size(161, 38);
            labelOfRole.TabIndex = 15;
            labelOfRole.Text = "Кладовщик";
            // 
            // labelOfLoginAs
            // 
            labelOfLoginAs.AutoSize = true;
            labelOfLoginAs.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfLoginAs.Location = new Point(12, 77);
            labelOfLoginAs.Name = "labelOfLoginAs";
            labelOfLoginAs.Size = new Size(201, 38);
            labelOfLoginAs.TabIndex = 14;
            labelOfLoginAs.Text = "Вы вошли как:";
            // 
            // labelOfCompanyName
            // 
            labelOfCompanyName.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfCompanyName.Location = new Point(52, 9);
            labelOfCompanyName.Name = "labelOfCompanyName";
            labelOfCompanyName.Size = new Size(689, 56);
            labelOfCompanyName.TabIndex = 13;
            labelOfCompanyName.Text = " «ООО Птички-тупички | Складская система»";
            // 
            // buttonOfChangePassword
            // 
            buttonOfChangePassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfChangePassword.Location = new Point(165, 463);
            buttonOfChangePassword.Name = "buttonOfChangePassword";
            buttonOfChangePassword.Size = new Size(470, 46);
            buttonOfChangePassword.TabIndex = 26;
            buttonOfChangePassword.Text = "Изменить мой пароль";
            buttonOfChangePassword.UseVisualStyleBackColor = true;
            buttonOfChangePassword.Click += buttonOfChangePassword_Click;
            // 
            // MakingShipment
            // 
            MakingShipment.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            MakingShipment.Location = new Point(165, 315);
            MakingShipment.Name = "MakingShipment";
            MakingShipment.Size = new Size(470, 53);
            MakingShipment.TabIndex = 27;
            MakingShipment.Text = "Оформление отгрузки";
            MakingShipment.UseVisualStyleBackColor = true;
            // 
            // labelOfAccount
            // 
            labelOfAccount.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfAccount.Location = new Point(325, 409);
            labelOfAccount.Name = "labelOfAccount";
            labelOfAccount.Size = new Size(152, 51);
            labelOfAccount.TabIndex = 28;
            labelOfAccount.Text = "Аккаунт";
            // 
            // WarehousemanPanel
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 598);
            Controls.Add(labelOfAccount);
            Controls.Add(MakingShipment);
            Controls.Add(buttonOfChangePassword);
            Controls.Add(buttonOfLogOut);
            Controls.Add(labelOfLine);
            Controls.Add(ShipmentsAndCustomers);
            Controls.Add(buttonOfProductCatalog);
            Controls.Add(labelOfProducts);
            Controls.Add(labelOfRole);
            Controls.Add(labelOfLoginAs);
            Controls.Add(labelOfCompanyName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "WarehousemanPanel";
            Text = "Панель управления (кладовщик)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonOfLogOut;
        private Label labelOfLine;
        private Label ShipmentsAndCustomers;
        private Button buttonOfProductCatalog;
        private Label labelOfProducts;
        private Label labelOfRole;
        private Label labelOfLoginAs;
        private Label labelOfCompanyName;
        private Button buttonOfChangePassword;
        private Button MakingShipment;
        private Label labelOfAccount;
    }
}