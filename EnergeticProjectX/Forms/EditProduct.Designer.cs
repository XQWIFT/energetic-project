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
            components = new System.ComponentModel.Container();
            comboBoxOfCategory = new ComboBox();
            buttonOfCancel = new Button();
            buttonOfSaveChanges = new Button();
            textBoxOfPrice = new TextBox();
            LabelOfUnit = new Label();
            LabelOfPrice = new Label();
            LabelOfCategory = new Label();
            textBoxOfName = new TextBox();
            LabelOfName = new Label();
            LabelOfEditProduct = new Label();
            textBoxOfUnit = new TextBox();
            ButtonOfChange = new Button();
            LabelOfStockQuantityInfo = new Label();
            LabelOfCreationDataInfo = new Label();
            LabelOfPriceForSell = new Label();
            LabelOfPriceDecreaseInfo = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            TextBoxOfCurrentStockQuantity = new TextBox();
            TextBoxOfCreationData = new TextBox();
            TextBoxOfPriceForSell = new TextBox();
            textBox4 = new TextBox();
            ButtonOfProductDelete = new Button();
            SuspendLayout();
            // 
            // comboBoxOfCategory
            // 
            comboBoxOfCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOfCategory.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxOfCategory.FormattingEnabled = true;
            comboBoxOfCategory.Location = new Point(400, 229);
            comboBoxOfCategory.Name = "comboBoxOfCategory";
            comboBoxOfCategory.Size = new Size(496, 53);
            comboBoxOfCategory.TabIndex = 33;
            // 
            // buttonOfCancel
            // 
            buttonOfCancel.FlatStyle = FlatStyle.Flat;
            buttonOfCancel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonOfCancel.Location = new Point(47, 827);
            buttonOfCancel.Name = "buttonOfCancel";
            buttonOfCancel.Size = new Size(411, 80);
            buttonOfCancel.TabIndex = 32;
            buttonOfCancel.Text = "Главное меню";
            buttonOfCancel.UseVisualStyleBackColor = true;
            buttonOfCancel.Click += buttonOfCancel_Click;
            // 
            // buttonOfSaveChanges
            // 
            buttonOfSaveChanges.FlatStyle = FlatStyle.Flat;
            buttonOfSaveChanges.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonOfSaveChanges.Location = new Point(47, 926);
            buttonOfSaveChanges.Name = "buttonOfSaveChanges";
            buttonOfSaveChanges.Size = new Size(411, 82);
            buttonOfSaveChanges.TabIndex = 31;
            buttonOfSaveChanges.Text = "Сохранить изменения";
            buttonOfSaveChanges.UseVisualStyleBackColor = true;
            buttonOfSaveChanges.Click += buttonOfSave_Click;
            // 
            // textBoxOfPrice
            // 
            textBoxOfPrice.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfPrice.Location = new Point(400, 577);
            textBoxOfPrice.Name = "textBoxOfPrice";
            textBoxOfPrice.Size = new Size(496, 45);
            textBoxOfPrice.TabIndex = 30;
            // 
            // LabelOfUnit
            // 
            LabelOfUnit.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfUnit.Location = new Point(48, 320);
            LabelOfUnit.Name = "LabelOfUnit";
            LabelOfUnit.Size = new Size(337, 50);
            LabelOfUnit.TabIndex = 29;
            LabelOfUnit.Text = "Единица измерения";
            // 
            // LabelOfPrice
            // 
            LabelOfPrice.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfPrice.Location = new Point(47, 577);
            LabelOfPrice.Name = "LabelOfPrice";
            LabelOfPrice.Size = new Size(291, 45);
            LabelOfPrice.TabIndex = 28;
            LabelOfPrice.Text = "Закупочная цена";
            // 
            // LabelOfCategory
            // 
            LabelOfCategory.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfCategory.Location = new Point(48, 232);
            LabelOfCategory.Name = "LabelOfCategory";
            LabelOfCategory.Size = new Size(300, 53);
            LabelOfCategory.TabIndex = 27;
            LabelOfCategory.Text = "Категория товара";
            // 
            // textBoxOfName
            // 
            textBoxOfName.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfName.Location = new Point(400, 144);
            textBoxOfName.Name = "textBoxOfName";
            textBoxOfName.Size = new Size(496, 50);
            textBoxOfName.TabIndex = 26;
            // 
            // LabelOfName
            // 
            LabelOfName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfName.Location = new Point(57, 144);
            LabelOfName.Name = "LabelOfName";
            LabelOfName.Size = new Size(291, 50);
            LabelOfName.TabIndex = 25;
            LabelOfName.Text = "Название товара";
            // 
            // LabelOfEditProduct
            // 
            LabelOfEditProduct.AutoSize = true;
            LabelOfEditProduct.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfEditProduct.Location = new Point(276, 41);
            LabelOfEditProduct.Name = "LabelOfEditProduct";
            LabelOfEditProduct.Size = new Size(384, 60);
            LabelOfEditProduct.TabIndex = 24;
            LabelOfEditProduct.Text = "Карточка товара";
            // 
            // textBoxOfUnit
            // 
            textBoxOfUnit.BackColor = Color.White;
            textBoxOfUnit.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfUnit.Location = new Point(400, 320);
            textBoxOfUnit.Name = "textBoxOfUnit";
            textBoxOfUnit.ReadOnly = true;
            textBoxOfUnit.Size = new Size(496, 50);
            textBoxOfUnit.TabIndex = 34;
            textBoxOfUnit.TabStop = false;
            // 
            // ButtonOfChange
            // 
            ButtonOfChange.FlatStyle = FlatStyle.Flat;
            ButtonOfChange.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfChange.Location = new Point(482, 827);
            ButtonOfChange.Name = "ButtonOfChange";
            ButtonOfChange.Size = new Size(414, 80);
            ButtonOfChange.TabIndex = 35;
            ButtonOfChange.Text = "Редактировать";
            ButtonOfChange.UseVisualStyleBackColor = true;
            // 
            // LabelOfStockQuantityInfo
            // 
            LabelOfStockQuantityInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfStockQuantityInfo.Location = new Point(48, 402);
            LabelOfStockQuantityInfo.Name = "LabelOfStockQuantityInfo";
            LabelOfStockQuantityInfo.Size = new Size(292, 50);
            LabelOfStockQuantityInfo.TabIndex = 36;
            LabelOfStockQuantityInfo.Text = "Текущий остаток";
            // 
            // LabelOfCreationDataInfo
            // 
            LabelOfCreationDataInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfCreationDataInfo.Location = new Point(48, 490);
            LabelOfCreationDataInfo.Name = "LabelOfCreationDataInfo";
            LabelOfCreationDataInfo.Size = new Size(292, 50);
            LabelOfCreationDataInfo.TabIndex = 37;
            LabelOfCreationDataInfo.Text = "Дата добавления";
            // 
            // LabelOfPriceForSell
            // 
            LabelOfPriceForSell.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfPriceForSell.Location = new Point(47, 656);
            LabelOfPriceForSell.Name = "LabelOfPriceForSell";
            LabelOfPriceForSell.Size = new Size(258, 50);
            LabelOfPriceForSell.TabIndex = 38;
            LabelOfPriceForSell.Text = "Цена продажи";
            // 
            // LabelOfPriceDecreaseInfo
            // 
            LabelOfPriceDecreaseInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfPriceDecreaseInfo.Location = new Point(47, 744);
            LabelOfPriceDecreaseInfo.Name = "LabelOfPriceDecreaseInfo";
            LabelOfPriceDecreaseInfo.Size = new Size(323, 50);
            LabelOfPriceDecreaseInfo.TabIndex = 39;
            LabelOfPriceDecreaseInfo.Text = "Снижение цены";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // TextBoxOfCurrentStockQuantity
            // 
            TextBoxOfCurrentStockQuantity.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfCurrentStockQuantity.Location = new Point(400, 402);
            TextBoxOfCurrentStockQuantity.Name = "TextBoxOfCurrentStockQuantity";
            TextBoxOfCurrentStockQuantity.Size = new Size(496, 50);
            TextBoxOfCurrentStockQuantity.TabIndex = 41;
            // 
            // TextBoxOfCreationData
            // 
            TextBoxOfCreationData.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfCreationData.Location = new Point(400, 490);
            TextBoxOfCreationData.Name = "TextBoxOfCreationData";
            TextBoxOfCreationData.Size = new Size(496, 50);
            TextBoxOfCreationData.TabIndex = 42;
            // 
            // TextBoxOfPriceForSell
            // 
            TextBoxOfPriceForSell.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfPriceForSell.Location = new Point(400, 656);
            TextBoxOfPriceForSell.Name = "TextBoxOfPriceForSell";
            TextBoxOfPriceForSell.Size = new Size(496, 50);
            TextBoxOfPriceForSell.TabIndex = 43;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox4.Location = new Point(400, 744);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(496, 50);
            textBox4.TabIndex = 44;
            // 
            // ButtonOfProductDelete
            // 
            ButtonOfProductDelete.FlatStyle = FlatStyle.Flat;
            ButtonOfProductDelete.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfProductDelete.Location = new Point(482, 926);
            ButtonOfProductDelete.Name = "ButtonOfProductDelete";
            ButtonOfProductDelete.Size = new Size(414, 82);
            ButtonOfProductDelete.TabIndex = 45;
            ButtonOfProductDelete.Text = "Удалить товар";
            ButtonOfProductDelete.UseVisualStyleBackColor = true;
            // 
            // EditProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(932, 1034);
            Controls.Add(ButtonOfProductDelete);
            Controls.Add(textBox4);
            Controls.Add(TextBoxOfPriceForSell);
            Controls.Add(TextBoxOfCreationData);
            Controls.Add(TextBoxOfCurrentStockQuantity);
            Controls.Add(LabelOfPriceDecreaseInfo);
            Controls.Add(LabelOfPriceForSell);
            Controls.Add(LabelOfCreationDataInfo);
            Controls.Add(LabelOfStockQuantityInfo);
            Controls.Add(ButtonOfChange);
            Controls.Add(textBoxOfUnit);
            Controls.Add(comboBoxOfCategory);
            Controls.Add(buttonOfCancel);
            Controls.Add(buttonOfSaveChanges);
            Controls.Add(textBoxOfPrice);
            Controls.Add(LabelOfUnit);
            Controls.Add(LabelOfPrice);
            Controls.Add(LabelOfCategory);
            Controls.Add(textBoxOfName);
            Controls.Add(LabelOfName);
            Controls.Add(LabelOfEditProduct);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактирование";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBoxOfCategory;
        private Button buttonOfCancel;
        private Button buttonOfSaveChanges;
        private TextBox textBoxOfPrice;
        private Label LabelOfUnit;
        private Label LabelOfPrice;
        private Label LabelOfCategory;
        private TextBox textBoxOfName;
        private Label LabelOfName;
        private Label LabelOfEditProduct;
        private TextBox textBoxOfUnit;
        private Button ButtonOfChange;
        private Label LabelOfStockQuantityInfo;
        private Label LabelOfCreationDataInfo;
        private Label LabelOfPriceForSell;
        private Label LabelOfPriceDecreaseInfo;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox TextBoxOfCurrentStockQuantity;
        private TextBox TextBoxOfCreationData;
        private TextBox TextBoxOfPriceForSell;
        private TextBox textBox4;
        private Button ButtonOfProductDelete;
    }
}