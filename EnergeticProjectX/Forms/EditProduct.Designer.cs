namespace EditProductForms
{
    partial class EditProduct
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
            comboBoxOfUnit = new ComboBox();
            comboBoxOfCategory = new ComboBox();
            buttonOfCancel = new Button();
            this.buttonOfSaveChanges = new Button();
            textBoxOfPrice = new TextBox();
            labelOfUnit = new Label();
            labelOfPrice = new Label();
            labelOfCategory = new Label();
            textBoxOfName = new TextBox();
            labelOfName = new Label();
            labelOfEditProduct = new Label();
            SuspendLayout();
            // 
            // comboBoxOfUnit
            // 
            comboBoxOfUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOfUnit.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxOfUnit.FormattingEnabled = true;
            comboBoxOfUnit.Location = new Point(223, 309);
            comboBoxOfUnit.Name = "comboBoxOfUnit";
            comboBoxOfUnit.Size = new Size(561, 46);
            comboBoxOfUnit.TabIndex = 34;
            // 
            // comboBoxOfCategory
            // 
            comboBoxOfCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOfCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxOfCategory.FormattingEnabled = true;
            comboBoxOfCategory.Location = new Point(223, 143);
            comboBoxOfCategory.Name = "comboBoxOfCategory";
            comboBoxOfCategory.Size = new Size(561, 46);
            comboBoxOfCategory.TabIndex = 33;
            // 
            // buttonOfCancel
            // 
            buttonOfCancel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfCancel.Location = new Point(421, 389);
            buttonOfCancel.Name = "buttonOfCancel";
            buttonOfCancel.Size = new Size(363, 69);
            buttonOfCancel.TabIndex = 32;
            buttonOfCancel.Text = "Отменить";
            buttonOfCancel.UseVisualStyleBackColor = true;
            this.buttonOfCancel.Click += new EventHandler(this.buttonOfCancel_Click);
            // 
            // buttonOfSaveChanges
            // 
            this.buttonOfSaveChanges.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            this.buttonOfSaveChanges.Location = new Point(18, 389);
            this.buttonOfSaveChanges.Name = "buttonOfSaveChanges";
            this.buttonOfSaveChanges.Size = new Size(363, 68);
            this.buttonOfSaveChanges.TabIndex = 31;
            this.buttonOfSaveChanges.Text = "Сохранить";
            this.buttonOfSaveChanges.UseVisualStyleBackColor = true;
            this.buttonOfSaveChanges.Click += new EventHandler(this.buttonOfSave_Click);
            // 
            // textBoxOfPrice
            // 
            textBoxOfPrice.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfPrice.Location = new Point(223, 224);
            textBoxOfPrice.Name = "textBoxOfPrice";
            textBoxOfPrice.Size = new Size(561, 45);
            textBoxOfPrice.TabIndex = 30;
            // 
            // labelOfUnit
            // 
            labelOfUnit.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfUnit.Location = new Point(18, 288);
            labelOfUnit.Name = "labelOfUnit";
            labelOfUnit.Size = new Size(183, 98);
            labelOfUnit.TabIndex = 29;
            labelOfUnit.Text = "Единица измерения";
            // 
            // labelOfPrice
            // 
            labelOfPrice.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfPrice.Location = new Point(18, 224);
            labelOfPrice.Name = "labelOfPrice";
            labelOfPrice.Size = new Size(184, 45);
            labelOfPrice.TabIndex = 28;
            labelOfPrice.Text = "Цена (руб.)";
            // 
            // labelOfCategory
            // 
            labelOfCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfCategory.Location = new Point(18, 143);
            labelOfCategory.Name = "labelOfCategory";
            labelOfCategory.Size = new Size(165, 45);
            labelOfCategory.TabIndex = 27;
            labelOfCategory.Text = "Категория";
            // 
            // textBoxOfName
            // 
            textBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfName.Location = new Point(223, 70);
            textBoxOfName.Name = "textBoxOfName";
            textBoxOfName.Size = new Size(561, 45);
            textBoxOfName.TabIndex = 26;
            // 
            // labelOfName
            // 
            labelOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfName.Location = new Point(18, 70);
            labelOfName.Name = "labelOfName";
            labelOfName.Size = new Size(151, 45);
            labelOfName.TabIndex = 25;
            labelOfName.Text = "Название";
            // 
            // labelOfEditProduct
            // 
            labelOfEditProduct.AutoSize = true;
            labelOfEditProduct.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfEditProduct.Location = new Point(223, 9);
            labelOfEditProduct.Name = "labelOfEditProduct";
            labelOfEditProduct.Size = new Size(413, 48);
            labelOfEditProduct.TabIndex = 24;
            labelOfEditProduct.Text = "Редактирование товара";
            // 
            // EditProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(809, 481);
            Controls.Add(comboBoxOfUnit);
            Controls.Add(comboBoxOfCategory);
            Controls.Add(buttonOfCancel);
            Controls.Add(this.buttonOfSaveChanges);
            Controls.Add(textBoxOfPrice);
            Controls.Add(labelOfUnit);
            Controls.Add(labelOfPrice);
            Controls.Add(labelOfCategory);
            Controls.Add(textBoxOfName);
            Controls.Add(labelOfName);
            Controls.Add(labelOfEditProduct);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditProduct";
            Text = "Редактирование";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxOfUnit;
        private ComboBox comboBoxOfCategory;
        private Button buttonOfCancel;
        private Button buttonOfSaveChanges;
        private TextBox textBoxOfPrice;
        private Label labelOfUnit;
        private Label labelOfPrice;
        private Label labelOfCategory;
        private TextBox textBoxOfName;
        private Label labelOfName;
        private Label labelOfEditProduct;
    }
}