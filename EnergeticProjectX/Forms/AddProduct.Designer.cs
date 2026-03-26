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
            buttonOfCancel = new Button();
            buttonOfAdd = new Button();
            textBoxOfPrice = new TextBox();
            labelOfUnit = new Label();
            labelOfPrice = new Label();
            labelOfCategory = new Label();
            textBoxOfName = new TextBox();
            labelOfName = new Label();
            labelOfAddProduct = new Label();
            comboBoxOfUnit = new ComboBox();
            SuspendLayout();
            // 
            // comboBoxOfCategory
            // 
            comboBoxOfCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOfCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxOfCategory.FormattingEnabled = true;
            comboBoxOfCategory.Location = new Point(222, 150);
            comboBoxOfCategory.Name = "comboBoxOfCategory";
            comboBoxOfCategory.Size = new Size(561, 46);
            comboBoxOfCategory.TabIndex = 22;
            // 
            // buttonOfCancel
            // 
            buttonOfCancel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfCancel.Location = new Point(420, 405);
            buttonOfCancel.Name = "buttonOfCancel";
            buttonOfCancel.Size = new Size(363, 69);
            buttonOfCancel.TabIndex = 21;
            buttonOfCancel.Text = "Отменить";
            buttonOfCancel.UseVisualStyleBackColor = true;
            buttonOfCancel.Click += buttonOfCancel_Click;
            // 
            // buttonOfAdd
            // 
            buttonOfAdd.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfAdd.Location = new Point(17, 405);
            buttonOfAdd.Name = "buttonOfAdd";
            buttonOfAdd.Size = new Size(363, 68);
            buttonOfAdd.TabIndex = 20;
            buttonOfAdd.Text = "Добавить";
            buttonOfAdd.UseVisualStyleBackColor = true;
            buttonOfAdd.Click += buttonOfAdd_Click;
            // 
            // textBoxOfPrice
            // 
            textBoxOfPrice.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfPrice.Location = new Point(222, 230);
            textBoxOfPrice.Name = "textBoxOfPrice";
            textBoxOfPrice.Size = new Size(561, 45);
            textBoxOfPrice.TabIndex = 18;
            // 
            // labelOfUnit
            // 
            labelOfUnit.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfUnit.Location = new Point(17, 304);
            labelOfUnit.Name = "labelOfUnit";
            labelOfUnit.Size = new Size(183, 98);
            labelOfUnit.TabIndex = 17;
            labelOfUnit.Text = "Единица измерения";
            // 
            // labelOfPrice
            // 
            labelOfPrice.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfPrice.Location = new Point(16, 230);
            labelOfPrice.Name = "labelOfPrice";
            labelOfPrice.Size = new Size(184, 45);
            labelOfPrice.TabIndex = 16;
            labelOfPrice.Text = "Цена (руб.)";
            // 
            // labelOfCategory
            // 
            labelOfCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfCategory.Location = new Point(17, 150);
            labelOfCategory.Name = "labelOfCategory";
            labelOfCategory.Size = new Size(165, 45);
            labelOfCategory.TabIndex = 15;
            labelOfCategory.Text = "Категория";
            // 
            // textBoxOfName
            // 
            textBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfName.Location = new Point(222, 76);
            textBoxOfName.Name = "textBoxOfName";
            textBoxOfName.Size = new Size(561, 45);
            textBoxOfName.TabIndex = 14;
            // 
            // labelOfName
            // 
            labelOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfName.Location = new Point(17, 76);
            labelOfName.Name = "labelOfName";
            labelOfName.Size = new Size(151, 45);
            labelOfName.TabIndex = 13;
            labelOfName.Text = "Название";
            // 
            // labelOfAddProduct
            // 
            labelOfAddProduct.AutoSize = true;
            labelOfAddProduct.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfAddProduct.Location = new Point(222, 9);
            labelOfAddProduct.Name = "labelOfAddProduct";
            labelOfAddProduct.Size = new Size(345, 48);
            labelOfAddProduct.TabIndex = 12;
            labelOfAddProduct.Text = "Добавление товара";
            // 
            // comboBoxOfUnit
            // 
            comboBoxOfUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOfUnit.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxOfUnit.FormattingEnabled = true;
            comboBoxOfUnit.Location = new Point(222, 325);
            comboBoxOfUnit.Name = "comboBoxOfUnit";
            comboBoxOfUnit.Size = new Size(561, 46);
            comboBoxOfUnit.TabIndex = 23;
            // 
            // AddProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 491);
            Controls.Add(comboBoxOfUnit);
            Controls.Add(comboBoxOfCategory);
            Controls.Add(buttonOfCancel);
            Controls.Add(buttonOfAdd);
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
            Text = "Добавление товара";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxOfCategory;
        private Button buttonOfCancel;
        private Button buttonOfAdd;
        private TextBox textBoxOfPrice;
        private Label labelOfUnit;
        private Label labelOfPrice;
        private Label labelOfCategory;
        private TextBox textBoxOfName;
        private Label labelOfName;
        private Label labelOfAddProduct;
        private ComboBox comboBoxOfUnit;
    }
}