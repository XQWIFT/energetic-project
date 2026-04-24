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
            ComboBoxOfCategory = new ComboBox();
            ButtonOfCancel = new Button();
            ButtonOfSaveChanges = new Button();
            LabelOfUnit = new Label();
            LabelOfCategory = new Label();
            TextBoxOfName = new TextBox();
            LabelOfName = new Label();
            LabelOfEditProduct = new Label();
            TextBoxOfUnit = new TextBox();
            ButtonOfChange = new Button();
            LabelOfStockQuantityInfo = new Label();
            LabelOfCreationDataInfo = new Label();
            LabelOfPriceForSell = new Label();
            LabelOfPriceDecreaseInfo = new Label();
            TextBoxOfCurrentStockQuantity = new TextBox();
            TextBoxOfCreationDate = new TextBox();
            TextBoxOfPriceForSell = new TextBox();
            TextBoxOfDiscountDate = new TextBox();
            ButtonOfProductDelete = new Button();
            TextBoxOfPurchasePrice = new TextBox();
            LabelOfPurchasePrice = new Label();
            LabelOfCurrencySymbolFirst = new Label();
            LabelOfCurrencySymbolSecond = new Label();
            SuspendLayout();
            // 
            // ComboBoxOfCategory
            // 
            ComboBoxOfCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOfCategory.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ComboBoxOfCategory.FormattingEnabled = true;
            ComboBoxOfCategory.Location = new Point(400, 229);
            ComboBoxOfCategory.Name = "ComboBoxOfCategory";
            ComboBoxOfCategory.Size = new Size(496, 53);
            ComboBoxOfCategory.TabIndex = 33;
            // 
            // ButtonOfCancel
            // 
            ButtonOfCancel.FlatAppearance.BorderSize = 4;
            ButtonOfCancel.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfCancel.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfCancel.FlatStyle = FlatStyle.Flat;
            ButtonOfCancel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfCancel.Location = new Point(48, 828);
            ButtonOfCancel.Name = "ButtonOfCancel";
            ButtonOfCancel.Size = new Size(413, 80);
            ButtonOfCancel.TabIndex = 32;
            ButtonOfCancel.Text = "Каталог товаров";
            ButtonOfCancel.UseVisualStyleBackColor = true;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
            // 
            // ButtonOfSaveChanges
            // 
            ButtonOfSaveChanges.Enabled = false;
            ButtonOfSaveChanges.FlatAppearance.BorderSize = 4;
            ButtonOfSaveChanges.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfSaveChanges.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfSaveChanges.FlatStyle = FlatStyle.Flat;
            ButtonOfSaveChanges.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfSaveChanges.Location = new Point(48, 927);
            ButtonOfSaveChanges.Name = "ButtonOfSaveChanges";
            ButtonOfSaveChanges.Size = new Size(413, 82);
            ButtonOfSaveChanges.TabIndex = 31;
            ButtonOfSaveChanges.Text = "Сохранить изменения";
            ButtonOfSaveChanges.UseVisualStyleBackColor = false;
            ButtonOfSaveChanges.Click += ButtonOfSave_Click;
            // 
            // LabelOfUnit
            // 
            LabelOfUnit.AutoSize = true;
            LabelOfUnit.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfUnit.Location = new Point(47, 323);
            LabelOfUnit.Name = "LabelOfUnit";
            LabelOfUnit.Size = new Size(336, 45);
            LabelOfUnit.TabIndex = 29;
            LabelOfUnit.Text = "Единица измерения";
            // 
            // LabelOfCategory
            // 
            LabelOfCategory.AutoSize = true;
            LabelOfCategory.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfCategory.Location = new Point(47, 232);
            LabelOfCategory.Name = "LabelOfCategory";
            LabelOfCategory.Size = new Size(298, 45);
            LabelOfCategory.TabIndex = 27;
            LabelOfCategory.Text = "Категория товара";
            // 
            // TextBoxOfName
            // 
            TextBoxOfName.BackColor = Color.White;
            TextBoxOfName.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfName.Location = new Point(400, 144);
            TextBoxOfName.Name = "TextBoxOfName";
            TextBoxOfName.ReadOnly = true;
            TextBoxOfName.Size = new Size(496, 50);
            TextBoxOfName.TabIndex = 26;
            // 
            // LabelOfName
            // 
            LabelOfName.AutoSize = true;
            LabelOfName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfName.Location = new Point(47, 144);
            LabelOfName.Name = "LabelOfName";
            LabelOfName.Size = new Size(287, 45);
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
            // TextBoxOfUnit
            // 
            TextBoxOfUnit.BackColor = Color.White;
            TextBoxOfUnit.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfUnit.Location = new Point(400, 320);
            TextBoxOfUnit.Name = "TextBoxOfUnit";
            TextBoxOfUnit.ReadOnly = true;
            TextBoxOfUnit.Size = new Size(496, 50);
            TextBoxOfUnit.TabIndex = 34;
            TextBoxOfUnit.TabStop = false;
            // 
            // ButtonOfChange
            // 
            ButtonOfChange.FlatAppearance.BorderSize = 4;
            ButtonOfChange.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfChange.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfChange.FlatStyle = FlatStyle.Flat;
            ButtonOfChange.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfChange.Location = new Point(473, 828);
            ButtonOfChange.Name = "ButtonOfChange";
            ButtonOfChange.Size = new Size(400, 80);
            ButtonOfChange.TabIndex = 35;
            ButtonOfChange.Text = "Редактировать";
            ButtonOfChange.UseVisualStyleBackColor = true;
            ButtonOfChange.Click += ButtonOfChange_Click;
            // 
            // LabelOfStockQuantityInfo
            // 
            LabelOfStockQuantityInfo.AutoSize = true;
            LabelOfStockQuantityInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfStockQuantityInfo.Location = new Point(47, 402);
            LabelOfStockQuantityInfo.Name = "LabelOfStockQuantityInfo";
            LabelOfStockQuantityInfo.Size = new Size(286, 45);
            LabelOfStockQuantityInfo.TabIndex = 36;
            LabelOfStockQuantityInfo.Text = "Текущий остаток";
            // 
            // LabelOfCreationDataInfo
            // 
            LabelOfCreationDataInfo.AutoSize = true;
            LabelOfCreationDataInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfCreationDataInfo.Location = new Point(47, 656);
            LabelOfCreationDataInfo.Name = "LabelOfCreationDataInfo";
            LabelOfCreationDataInfo.Size = new Size(292, 45);
            LabelOfCreationDataInfo.TabIndex = 37;
            LabelOfCreationDataInfo.Text = "Дата добавления";
            // 
            // LabelOfPriceForSell
            // 
            LabelOfPriceForSell.AutoSize = true;
            LabelOfPriceForSell.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfPriceForSell.Location = new Point(47, 572);
            LabelOfPriceForSell.Name = "LabelOfPriceForSell";
            LabelOfPriceForSell.Size = new Size(262, 45);
            LabelOfPriceForSell.TabIndex = 38;
            LabelOfPriceForSell.Text = "Цена продажи,";
            // 
            // LabelOfPriceDecreaseInfo
            // 
            LabelOfPriceDecreaseInfo.AutoSize = true;
            LabelOfPriceDecreaseInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfPriceDecreaseInfo.Location = new Point(47, 739);
            LabelOfPriceDecreaseInfo.Name = "LabelOfPriceDecreaseInfo";
            LabelOfPriceDecreaseInfo.Size = new Size(273, 45);
            LabelOfPriceDecreaseInfo.TabIndex = 39;
            LabelOfPriceDecreaseInfo.Text = "Снижение цены";
            // 
            // TextBoxOfCurrentStockQuantity
            // 
            TextBoxOfCurrentStockQuantity.BackColor = Color.White;
            TextBoxOfCurrentStockQuantity.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfCurrentStockQuantity.Location = new Point(400, 402);
            TextBoxOfCurrentStockQuantity.Name = "TextBoxOfCurrentStockQuantity";
            TextBoxOfCurrentStockQuantity.ReadOnly = true;
            TextBoxOfCurrentStockQuantity.Size = new Size(496, 50);
            TextBoxOfCurrentStockQuantity.TabIndex = 41;
            // 
            // TextBoxOfCreationDate
            // 
            TextBoxOfCreationDate.BackColor = Color.White;
            TextBoxOfCreationDate.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfCreationDate.Location = new Point(400, 653);
            TextBoxOfCreationDate.Name = "TextBoxOfCreationDate";
            TextBoxOfCreationDate.ReadOnly = true;
            TextBoxOfCreationDate.Size = new Size(496, 50);
            TextBoxOfCreationDate.TabIndex = 42;
            // 
            // TextBoxOfPriceForSell
            // 
            TextBoxOfPriceForSell.BackColor = Color.White;
            TextBoxOfPriceForSell.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfPriceForSell.Location = new Point(400, 569);
            TextBoxOfPriceForSell.Name = "TextBoxOfPriceForSell";
            TextBoxOfPriceForSell.ReadOnly = true;
            TextBoxOfPriceForSell.Size = new Size(496, 50);
            TextBoxOfPriceForSell.TabIndex = 43;
            // 
            // TextBoxOfDiscountDate
            // 
            TextBoxOfDiscountDate.BackColor = Color.White;
            TextBoxOfDiscountDate.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfDiscountDate.Location = new Point(400, 739);
            TextBoxOfDiscountDate.Name = "TextBoxOfDiscountDate";
            TextBoxOfDiscountDate.ReadOnly = true;
            TextBoxOfDiscountDate.Size = new Size(496, 50);
            TextBoxOfDiscountDate.TabIndex = 44;
            // 
            // ButtonOfProductDelete
            // 
            ButtonOfProductDelete.FlatAppearance.BorderSize = 4;
            ButtonOfProductDelete.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfProductDelete.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfProductDelete.FlatStyle = FlatStyle.Flat;
            ButtonOfProductDelete.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfProductDelete.Location = new Point(473, 927);
            ButtonOfProductDelete.Name = "ButtonOfProductDelete";
            ButtonOfProductDelete.Size = new Size(400, 82);
            ButtonOfProductDelete.TabIndex = 45;
            ButtonOfProductDelete.Text = "Удалить товар";
            ButtonOfProductDelete.UseVisualStyleBackColor = true;
            ButtonOfProductDelete.Click += ButtonOfProductDelete_Click;
            // 
            // TextBoxOfPurchasePrice
            // 
            TextBoxOfPurchasePrice.BackColor = Color.White;
            TextBoxOfPurchasePrice.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfPurchasePrice.Location = new Point(400, 485);
            TextBoxOfPurchasePrice.Name = "TextBoxOfPurchasePrice";
            TextBoxOfPurchasePrice.ReadOnly = true;
            TextBoxOfPurchasePrice.Size = new Size(496, 50);
            TextBoxOfPurchasePrice.TabIndex = 46;
            // 
            // LabelOfPurchasePrice
            // 
            LabelOfPurchasePrice.AutoSize = true;
            LabelOfPurchasePrice.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfPurchasePrice.Location = new Point(47, 488);
            LabelOfPurchasePrice.Name = "LabelOfPurchasePrice";
            LabelOfPurchasePrice.Size = new Size(243, 45);
            LabelOfPurchasePrice.TabIndex = 47;
            LabelOfPurchasePrice.Text = "Цена закупки,";
            // 
            // LabelOfCurrencySymbolFirst
            // 
            LabelOfCurrencySymbolFirst.AutoSize = true;
            LabelOfCurrencySymbolFirst.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfCurrencySymbolFirst.Location = new Point(276, 488);
            LabelOfCurrencySymbolFirst.Name = "LabelOfCurrencySymbolFirst";
            LabelOfCurrencySymbolFirst.Size = new Size(0, 45);
            LabelOfCurrencySymbolFirst.TabIndex = 48;
            // 
            // LabelOfCurrencySymbolSecond
            // 
            LabelOfCurrencySymbolSecond.AutoSize = true;
            LabelOfCurrencySymbolSecond.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfCurrencySymbolSecond.Location = new Point(290, 572);
            LabelOfCurrencySymbolSecond.Name = "LabelOfCurrencySymbolSecond";
            LabelOfCurrencySymbolSecond.Size = new Size(0, 45);
            LabelOfCurrencySymbolSecond.TabIndex = 49;
            // 
            // EditProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(932, 1034);
            Controls.Add(LabelOfCurrencySymbolSecond);
            Controls.Add(LabelOfCurrencySymbolFirst);
            Controls.Add(LabelOfPurchasePrice);
            Controls.Add(TextBoxOfPurchasePrice);
            Controls.Add(ButtonOfProductDelete);
            Controls.Add(TextBoxOfDiscountDate);
            Controls.Add(TextBoxOfPriceForSell);
            Controls.Add(TextBoxOfCreationDate);
            Controls.Add(TextBoxOfCurrentStockQuantity);
            Controls.Add(LabelOfPriceDecreaseInfo);
            Controls.Add(LabelOfPriceForSell);
            Controls.Add(LabelOfCreationDataInfo);
            Controls.Add(LabelOfStockQuantityInfo);
            Controls.Add(ButtonOfChange);
            Controls.Add(TextBoxOfUnit);
            Controls.Add(ComboBoxOfCategory);
            Controls.Add(ButtonOfCancel);
            Controls.Add(ButtonOfSaveChanges);
            Controls.Add(LabelOfUnit);
            Controls.Add(LabelOfCategory);
            Controls.Add(TextBoxOfName);
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
        private ComboBox ComboBoxOfCategory;
        private Button ButtonOfCancel;
        private Button ButtonOfSaveChanges;
        private Label LabelOfUnit;
        private Label LabelOfCategory;
        private TextBox TextBoxOfName;
        private Label LabelOfName;
        private Label LabelOfEditProduct;
        private TextBox TextBoxOfUnit;
        private Button ButtonOfChange;
        private Label LabelOfStockQuantityInfo;
        private Label LabelOfCreationDataInfo;
        private Label LabelOfPriceForSell;
        private Label LabelOfPriceDecreaseInfo;
        private TextBox TextBoxOfCurrentStockQuantity;
        private TextBox TextBoxOfCreationDate;
        private TextBox TextBoxOfPriceForSell;
        private TextBox TextBoxOfDiscountDate;
        private Button ButtonOfProductDelete;
        private TextBox TextBoxOfPurchasePrice;
        private Label LabelOfPurchasePrice;
        private Label LabelOfCurrencySymbolFirst;
        private Label LabelOfCurrencySymbolSecond;
    }
}