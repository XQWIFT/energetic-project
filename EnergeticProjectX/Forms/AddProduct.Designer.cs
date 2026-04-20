namespace AddProductForm
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
            comboBoxOfCategory = new ComboBox();
            ButtonOfCancel = new Button();
            ButtonOfAdd = new Button();
            textBoxOfPrice = new TextBox();
            labelOfUnit = new Label();
            labelOfPrice = new Label();
            labelOfCategory = new Label();
            textBoxOfName = new TextBox();
            labelOfName = new Label();
            labelOfAddProduct = new Label();
            textBoxOfUnit = new TextBox();
            SuspendLayout();
            // 
            // comboBoxOfCategory
            // 
            comboBoxOfCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOfCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxOfCategory.FormattingEnabled = true;
            comboBoxOfCategory.Location = new Point(416, 187);
            comboBoxOfCategory.Name = "comboBoxOfCategory";
            comboBoxOfCategory.Size = new Size(402, 46);
            comboBoxOfCategory.TabIndex = 22;
            // 
            // ButtonOfCancel
            // 
            ButtonOfCancel.FlatStyle = FlatStyle.Flat;
            ButtonOfCancel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfCancel.Location = new Point(435, 412);
            ButtonOfCancel.Name = "ButtonOfCancel";
            ButtonOfCancel.Size = new Size(310, 69);
            ButtonOfCancel.TabIndex = 21;
            ButtonOfCancel.Text = "Отменить";
            ButtonOfCancel.UseVisualStyleBackColor = true;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
            // 
            // ButtonOfAdd
            // 
            ButtonOfAdd.FlatStyle = FlatStyle.Flat;
            ButtonOfAdd.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfAdd.Location = new Point(110, 412);
            ButtonOfAdd.Name = "ButtonOfAdd";
            ButtonOfAdd.Size = new Size(309, 68);
            ButtonOfAdd.TabIndex = 20;
            ButtonOfAdd.Text = "Добавить";
            ButtonOfAdd.UseVisualStyleBackColor = true;
            ButtonOfAdd.Click += ButtonOfAdd_Click;
            // 
            // textBoxOfPrice
            // 
            textBoxOfPrice.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfPrice.Location = new Point(416, 334);
            textBoxOfPrice.Name = "textBoxOfPrice";
            textBoxOfPrice.Size = new Size(402, 45);
            textBoxOfPrice.TabIndex = 18;
            // 
            // labelOfUnit
            // 
            labelOfUnit.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfUnit.Location = new Point(67, 259);
            labelOfUnit.Name = "labelOfUnit";
            labelOfUnit.Size = new Size(337, 45);
            labelOfUnit.TabIndex = 17;
            labelOfUnit.Text = "Единица измерения";
            // 
            // labelOfPrice
            // 
            labelOfPrice.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfPrice.Location = new Point(67, 334);
            labelOfPrice.Name = "labelOfPrice";
            labelOfPrice.Size = new Size(309, 45);
            labelOfPrice.TabIndex = 16;
            labelOfPrice.Text = "Закупочная цена";
            // 
            // labelOfCategory
            // 
            labelOfCategory.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfCategory.Location = new Point(67, 187);
            labelOfCategory.Name = "labelOfCategory";
            labelOfCategory.Size = new Size(298, 45);
            labelOfCategory.TabIndex = 15;
            labelOfCategory.Text = "Категория товара";
            // 
            // textBoxOfName
            // 
            textBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfName.Location = new Point(416, 119);
            textBoxOfName.Name = "textBoxOfName";
            textBoxOfName.Size = new Size(402, 45);
            textBoxOfName.TabIndex = 14;
            // 
            // labelOfName
            // 
            labelOfName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfName.Location = new Point(67, 119);
            labelOfName.Name = "labelOfName";
            labelOfName.Size = new Size(294, 45);
            labelOfName.TabIndex = 13;
            labelOfName.Text = "Название товара";
            // 
            // labelOfAddProduct
            // 
            labelOfAddProduct.AutoSize = true;
            labelOfAddProduct.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfAddProduct.Location = new Point(227, 34);
            labelOfAddProduct.Name = "labelOfAddProduct";
            labelOfAddProduct.Size = new Size(408, 54);
            labelOfAddProduct.TabIndex = 12;
            labelOfAddProduct.Text = "Добавление товара";
            // 
            // textBoxOfUnit
            // 
            textBoxOfUnit.BackColor = Color.White;
            textBoxOfUnit.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfUnit.Location = new Point(416, 259);
            textBoxOfUnit.Name = "textBoxOfUnit";
            textBoxOfUnit.ReadOnly = true;
            textBoxOfUnit.Size = new Size(402, 45);
            textBoxOfUnit.TabIndex = 23;
            textBoxOfUnit.TabStop = false;
            // 
            // AddProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(877, 579);
            Controls.Add(textBoxOfUnit);
            Controls.Add(comboBoxOfCategory);
            Controls.Add(ButtonOfCancel);
            Controls.Add(ButtonOfAdd);
            Controls.Add(textBoxOfPrice);
            Controls.Add(labelOfUnit);
            Controls.Add(labelOfPrice);
            Controls.Add(labelOfCategory);
            Controls.Add(textBoxOfName);
            Controls.Add(labelOfName);
            Controls.Add(labelOfAddProduct);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление товара";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxOfCategory;
        private Button ButtonOfCancel;
        private Button ButtonOfAdd;
        private TextBox textBoxOfPrice;
        private Label labelOfUnit;
        private Label labelOfPrice;
        private Label labelOfCategory;
        private TextBox textBoxOfName;
        private Label labelOfName;
        private Label labelOfAddProduct;
        private TextBox textBoxOfUnit;
    }
}