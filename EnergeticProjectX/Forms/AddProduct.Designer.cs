namespace EnergeticProjectX.Forms
{
    partial class AddProduct
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
            ComboBoxOfCategory = new ComboBox();
            ButtonOfCancel = new Button();
            ButtonOfAddProduct = new Button();
            TextBoxOfPurchasePrice = new TextBox();
            LabelOfUnit = new Label();
            LabelOfPrice = new Label();
            LabelOfCategory = new Label();
            TextBoxOfName = new TextBox();
            LabelOfName = new Label();
            LabelOfAddProduct = new Label();
            TextBoxOfUnit = new TextBox();
            LabelOfCurrencySymbol = new Label();
            SuspendLayout();
            // 
            // ComboBoxOfCategory
            // 
            ComboBoxOfCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOfCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ComboBoxOfCategory.FormattingEnabled = true;
            ComboBoxOfCategory.Location = new Point(416, 187);
            ComboBoxOfCategory.Name = "ComboBoxOfCategory";
            ComboBoxOfCategory.Size = new Size(402, 46);
            ComboBoxOfCategory.TabIndex = 2;
            ComboBoxOfCategory.SelectedIndexChanged += IsComboBoxOfCategoryChanged;
            ComboBoxOfCategory.TextChanged += IsTextChanged;
            // 
            // ButtonOfCancel
            // 
            ButtonOfCancel.FlatAppearance.BorderColor = Color.Black;
            ButtonOfCancel.FlatAppearance.BorderSize = 4;
            ButtonOfCancel.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfCancel.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfCancel.FlatStyle = FlatStyle.Flat;
            ButtonOfCancel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfCancel.Location = new Point(435, 412);
            ButtonOfCancel.Name = "ButtonOfCancel";
            ButtonOfCancel.Size = new Size(310, 69);
            ButtonOfCancel.TabIndex = 6;
            ButtonOfCancel.Text = "Отменить";
            ButtonOfCancel.UseVisualStyleBackColor = true;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
            ButtonOfCancel.Enter += TabSelection_Enter;
            ButtonOfCancel.Leave += TabSelection_Leave;
            // 
            // ButtonOfAddProduct
            // 
            ButtonOfAddProduct.Enabled = false;
            ButtonOfAddProduct.FlatAppearance.BorderColor = Color.Black;
            ButtonOfAddProduct.FlatAppearance.BorderSize = 4;
            ButtonOfAddProduct.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfAddProduct.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfAddProduct.FlatStyle = FlatStyle.Flat;
            ButtonOfAddProduct.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfAddProduct.Location = new Point(110, 412);
            ButtonOfAddProduct.Name = "ButtonOfAddProduct";
            ButtonOfAddProduct.Size = new Size(309, 68);
            ButtonOfAddProduct.TabIndex = 5;
            ButtonOfAddProduct.Text = "Добавить";
            ButtonOfAddProduct.UseVisualStyleBackColor = true;
            ButtonOfAddProduct.Click += ButtonOfAdd_Click;
            ButtonOfAddProduct.Enter += TabSelection_Enter;
            ButtonOfAddProduct.Leave += TabSelection_Leave;
            // 
            // TextBoxOfPurchasePrice
            // 
            TextBoxOfPurchasePrice.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfPurchasePrice.Location = new Point(416, 334);
            TextBoxOfPurchasePrice.Name = "TextBoxOfPurchasePrice";
            TextBoxOfPurchasePrice.Size = new Size(402, 45);
            TextBoxOfPurchasePrice.TabIndex = 4;
            TextBoxOfPurchasePrice.TextChanged += IsTextChanged;
            // 
            // LabelOfUnit
            // 
            LabelOfUnit.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfUnit.Location = new Point(67, 259);
            LabelOfUnit.Name = "LabelOfUnit";
            LabelOfUnit.Size = new Size(337, 45);
            LabelOfUnit.TabIndex = 0;
            LabelOfUnit.Text = "Единица измерения";
            // 
            // LabelOfPrice
            // 
            LabelOfPrice.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfPrice.Location = new Point(67, 334);
            LabelOfPrice.Name = "LabelOfPrice";
            LabelOfPrice.Size = new Size(309, 45);
            LabelOfPrice.TabIndex = 0;
            LabelOfPrice.Text = "Закупочная цена,";
            // 
            // LabelOfCategory
            // 
            LabelOfCategory.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfCategory.Location = new Point(67, 187);
            LabelOfCategory.Name = "LabelOfCategory";
            LabelOfCategory.Size = new Size(298, 45);
            LabelOfCategory.TabIndex = 0;
            LabelOfCategory.Text = "Категория товара";
            // 
            // TextBoxOfName
            // 
            TextBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfName.Location = new Point(416, 119);
            TextBoxOfName.Name = "TextBoxOfName";
            TextBoxOfName.Size = new Size(402, 45);
            TextBoxOfName.TabIndex = 1;
            TextBoxOfName.TextChanged += IsTextChanged;
            // 
            // LabelOfName
            // 
            LabelOfName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfName.Location = new Point(67, 119);
            LabelOfName.Name = "LabelOfName";
            LabelOfName.Size = new Size(294, 45);
            LabelOfName.TabIndex = 0;
            LabelOfName.Text = "Название товара";
            // 
            // LabelOfAddProduct
            // 
            LabelOfAddProduct.AutoSize = true;
            LabelOfAddProduct.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfAddProduct.Location = new Point(227, 34);
            LabelOfAddProduct.Name = "LabelOfAddProduct";
            LabelOfAddProduct.Size = new Size(408, 54);
            LabelOfAddProduct.TabIndex = 0;
            LabelOfAddProduct.Text = "Добавление товара";
            // 
            // TextBoxOfUnit
            // 
            TextBoxOfUnit.BackColor = Color.White;
            TextBoxOfUnit.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfUnit.Location = new Point(416, 261);
            TextBoxOfUnit.Name = "TextBoxOfUnit";
            TextBoxOfUnit.ReadOnly = true;
            TextBoxOfUnit.Size = new Size(402, 45);
            TextBoxOfUnit.TabIndex = 3;
            TextBoxOfUnit.TabStop = false;
            // 
            // LabelOfCurrencySymbol
            // 
            LabelOfCurrencySymbol.BackColor = Color.Lavender;
            LabelOfCurrencySymbol.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfCurrencySymbol.Location = new Point(357, 334);
            LabelOfCurrencySymbol.Name = "LabelOfCurrencySymbol";
            LabelOfCurrencySymbol.Size = new Size(38, 45);
            LabelOfCurrencySymbol.TabIndex = 0;
            // 
            // AddProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(877, 579);
            Controls.Add(LabelOfCurrencySymbol);
            Controls.Add(TextBoxOfUnit);
            Controls.Add(ComboBoxOfCategory);
            Controls.Add(ButtonOfCancel);
            Controls.Add(ButtonOfAddProduct);
            Controls.Add(TextBoxOfPurchasePrice);
            Controls.Add(LabelOfUnit);
            Controls.Add(LabelOfPrice);
            Controls.Add(LabelOfCategory);
            Controls.Add(TextBoxOfName);
            Controls.Add(LabelOfName);
            Controls.Add(LabelOfAddProduct);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление нового товара";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ComboBoxOfCategory;
        private Button ButtonOfCancel;
        private Button ButtonOfAddProduct;
        private TextBox TextBoxOfPurchasePrice;
        private Label LabelOfUnit;
        private Label LabelOfPrice;
        private Label LabelOfCategory;
        private TextBox TextBoxOfName;
        private Label LabelOfName;
        private Label LabelOfAddProduct;
        private TextBox TextBoxOfUnit;
        private Label LabelOfCurrencySymbol;
    }
}