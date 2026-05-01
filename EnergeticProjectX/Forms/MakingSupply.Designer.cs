namespace EnergeticProjectX.Forms
{
    partial class MakingSupply
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewOfSupply = new DataGridView();
            LabelOfMakingSupply = new Label();
            LabelOfCategory = new Label();
            LabelOfProduct = new Label();
            LabelOfQuantity = new Label();
            LabelOfPurchasePrice = new Label();
            LabelOfUnit = new Label();
            LabelOfStockQuantity = new Label();
            ButtonOfAddProduct = new Button();
            ButtonOfUploadingByFile = new Button();
            ButtonOfDeleteProduct = new Button();
            ButtonOfMakingSupply = new Button();
            ComboBoxOfCategory = new ComboBox();
            ComboBoxOfProduct = new ComboBox();
            TextBoxOfUnit = new TextBox();
            TextBoxOfStockQuantity = new TextBox();
            TextBoxOfQuantity = new TextBox();
            TextBoxOfPurchaseAll = new TextBox();
            ButtonOfCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGridViewOfSupply).BeginInit();
            SuspendLayout();
            // 
            // DataGridViewOfSupply
            // 
            DataGridViewOfSupply.AllowUserToAddRows = false;
            DataGridViewOfSupply.AllowUserToDeleteRows = false;
            DataGridViewOfSupply.AllowUserToResizeColumns = false;
            DataGridViewOfSupply.AllowUserToResizeRows = false;
            DataGridViewOfSupply.BackgroundColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DataGridViewOfSupply.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DataGridViewOfSupply.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DataGridViewOfSupply.DefaultCellStyle = dataGridViewCellStyle2;
            DataGridViewOfSupply.EnableHeadersVisualStyles = false;
            DataGridViewOfSupply.Location = new Point(561, 12);
            DataGridViewOfSupply.MultiSelect = false;
            DataGridViewOfSupply.Name = "DataGridViewOfSupply";
            DataGridViewOfSupply.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DataGridViewOfSupply.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DataGridViewOfSupply.RowHeadersVisible = false;
            DataGridViewOfSupply.RowHeadersWidth = 62;
            DataGridViewOfSupply.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewOfSupply.Size = new Size(650, 707);
            DataGridViewOfSupply.TabIndex = 0;
            // 
            // LabelOfMakingSupply
            // 
            LabelOfMakingSupply.AutoSize = true;
            LabelOfMakingSupply.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfMakingSupply.Location = new Point(43, 78);
            LabelOfMakingSupply.Name = "LabelOfMakingSupply";
            LabelOfMakingSupply.Size = new Size(469, 54);
            LabelOfMakingSupply.TabIndex = 0;
            LabelOfMakingSupply.Text = "Оформление поставки";
            // 
            // LabelOfCategory
            // 
            LabelOfCategory.AutoSize = true;
            LabelOfCategory.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfCategory.Location = new Point(12, 171);
            LabelOfCategory.Name = "LabelOfCategory";
            LabelOfCategory.Size = new Size(181, 45);
            LabelOfCategory.TabIndex = 0;
            LabelOfCategory.Text = "Категория";
            // 
            // LabelOfProduct
            // 
            LabelOfProduct.AutoSize = true;
            LabelOfProduct.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfProduct.Location = new Point(12, 239);
            LabelOfProduct.Name = "LabelOfProduct";
            LabelOfProduct.Size = new Size(112, 45);
            LabelOfProduct.TabIndex = 0;
            LabelOfProduct.Text = "Товар";
            // 
            // LabelOfQuantity
            // 
            LabelOfQuantity.AutoSize = true;
            LabelOfQuantity.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfQuantity.Location = new Point(12, 441);
            LabelOfQuantity.Name = "LabelOfQuantity";
            LabelOfQuantity.Size = new Size(205, 45);
            LabelOfQuantity.TabIndex = 0;
            LabelOfQuantity.Text = "Количество";
            // 
            // LabelOfPurchasePrice
            // 
            LabelOfPurchasePrice.AutoSize = true;
            LabelOfPurchasePrice.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfPurchasePrice.Location = new Point(709, 747);
            LabelOfPurchasePrice.Name = "LabelOfPurchasePrice";
            LabelOfPurchasePrice.Size = new Size(371, 45);
            LabelOfPurchasePrice.TabIndex = 0;
            LabelOfPurchasePrice.Text = "Суммарная стоимость";
            // 
            // LabelOfUnit
            // 
            LabelOfUnit.AutoSize = true;
            LabelOfUnit.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfUnit.Location = new Point(12, 304);
            LabelOfUnit.Name = "LabelOfUnit";
            LabelOfUnit.Size = new Size(155, 45);
            LabelOfUnit.TabIndex = 0;
            LabelOfUnit.Text = "Единица";
            // 
            // LabelOfStockQuantity
            // 
            LabelOfStockQuantity.AutoSize = true;
            LabelOfStockQuantity.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfStockQuantity.Location = new Point(12, 374);
            LabelOfStockQuantity.Name = "LabelOfStockQuantity";
            LabelOfStockQuantity.Size = new Size(144, 45);
            LabelOfStockQuantity.TabIndex = 0;
            LabelOfStockQuantity.Text = "Остаток";
            // 
            // ButtonOfAddProduct
            // 
            ButtonOfAddProduct.FlatAppearance.BorderSize = 4;
            ButtonOfAddProduct.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfAddProduct.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfAddProduct.FlatStyle = FlatStyle.Flat;
            ButtonOfAddProduct.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            ButtonOfAddProduct.Location = new Point(114, 524);
            ButtonOfAddProduct.Name = "ButtonOfAddProduct";
            ButtonOfAddProduct.Size = new Size(368, 63);
            ButtonOfAddProduct.TabIndex = 6;
            ButtonOfAddProduct.Text = "Добавить товар";
            ButtonOfAddProduct.UseVisualStyleBackColor = true;
            ButtonOfAddProduct.Enter += TabSelection_Enter;
            ButtonOfAddProduct.Leave += TabSelection_Leave;
            // 
            // ButtonOfUploadingByFile
            // 
            ButtonOfUploadingByFile.FlatAppearance.BorderSize = 4;
            ButtonOfUploadingByFile.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfUploadingByFile.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfUploadingByFile.FlatStyle = FlatStyle.Flat;
            ButtonOfUploadingByFile.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            ButtonOfUploadingByFile.Location = new Point(114, 593);
            ButtonOfUploadingByFile.Name = "ButtonOfUploadingByFile";
            ButtonOfUploadingByFile.Size = new Size(368, 80);
            ButtonOfUploadingByFile.TabIndex = 7;
            ButtonOfUploadingByFile.Text = "Загрузить из файла";
            ButtonOfUploadingByFile.UseVisualStyleBackColor = true;
            ButtonOfUploadingByFile.Enter += TabSelection_Enter;
            ButtonOfUploadingByFile.Leave += TabSelection_Leave;
            // 
            // ButtonOfDeleteProduct
            // 
            ButtonOfDeleteProduct.FlatAppearance.BorderSize = 4;
            ButtonOfDeleteProduct.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfDeleteProduct.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfDeleteProduct.FlatStyle = FlatStyle.Flat;
            ButtonOfDeleteProduct.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            ButtonOfDeleteProduct.Location = new Point(114, 679);
            ButtonOfDeleteProduct.Name = "ButtonOfDeleteProduct";
            ButtonOfDeleteProduct.Size = new Size(368, 71);
            ButtonOfDeleteProduct.TabIndex = 8;
            ButtonOfDeleteProduct.Text = "Удалить товар";
            ButtonOfDeleteProduct.UseVisualStyleBackColor = true;
            ButtonOfDeleteProduct.Enter += TabSelection_Enter;
            ButtonOfDeleteProduct.Leave += TabSelection_Leave;
            // 
            // ButtonOfMakingSupply
            // 
            ButtonOfMakingSupply.FlatAppearance.BorderSize = 4;
            ButtonOfMakingSupply.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfMakingSupply.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfMakingSupply.FlatStyle = FlatStyle.Flat;
            ButtonOfMakingSupply.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            ButtonOfMakingSupply.Location = new Point(114, 756);
            ButtonOfMakingSupply.Name = "ButtonOfMakingSupply";
            ButtonOfMakingSupply.Size = new Size(368, 70);
            ButtonOfMakingSupply.TabIndex = 9;
            ButtonOfMakingSupply.Text = "Оформить поставку";
            ButtonOfMakingSupply.UseVisualStyleBackColor = true;
            ButtonOfMakingSupply.Enter += TabSelection_Enter;
            ButtonOfMakingSupply.Leave += TabSelection_Leave;
            // 
            // ComboBoxOfCategory
            // 
            ComboBoxOfCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOfCategory.Font = new Font("Segoe UI", 14F);
            ComboBoxOfCategory.FormattingEnabled = true;
            ComboBoxOfCategory.Location = new Point(222, 173);
            ComboBoxOfCategory.Name = "ComboBoxOfCategory";
            ComboBoxOfCategory.Size = new Size(309, 46);
            ComboBoxOfCategory.TabIndex = 1;
            // 
            // ComboBoxOfProduct
            // 
            ComboBoxOfProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOfProduct.Enabled = false;
            ComboBoxOfProduct.Font = new Font("Segoe UI", 14F);
            ComboBoxOfProduct.FormattingEnabled = true;
            ComboBoxOfProduct.Location = new Point(222, 238);
            ComboBoxOfProduct.Name = "ComboBoxOfProduct";
            ComboBoxOfProduct.Size = new Size(309, 46);
            ComboBoxOfProduct.TabIndex = 2;
            // 
            // TextBoxOfUnit
            // 
            TextBoxOfUnit.BackColor = SystemColors.Window;
            TextBoxOfUnit.Font = new Font("Segoe UI", 14F);
            TextBoxOfUnit.Location = new Point(222, 306);
            TextBoxOfUnit.Name = "TextBoxOfUnit";
            TextBoxOfUnit.ReadOnly = true;
            TextBoxOfUnit.Size = new Size(309, 45);
            TextBoxOfUnit.TabIndex = 3;
            // 
            // TextBoxOfStockQuantity
            // 
            TextBoxOfStockQuantity.BackColor = SystemColors.Window;
            TextBoxOfStockQuantity.Font = new Font("Segoe UI", 14F);
            TextBoxOfStockQuantity.Location = new Point(222, 376);
            TextBoxOfStockQuantity.Name = "TextBoxOfStockQuantity";
            TextBoxOfStockQuantity.ReadOnly = true;
            TextBoxOfStockQuantity.Size = new Size(309, 45);
            TextBoxOfStockQuantity.TabIndex = 4;
            // 
            // TextBoxOfQuantity
            // 
            TextBoxOfQuantity.BackColor = SystemColors.Window;
            TextBoxOfQuantity.Font = new Font("Segoe UI", 14F);
            TextBoxOfQuantity.Location = new Point(223, 443);
            TextBoxOfQuantity.Name = "TextBoxOfQuantity";
            TextBoxOfQuantity.Size = new Size(308, 45);
            TextBoxOfQuantity.TabIndex = 5;
            // 
            // TextBoxOfPurchaseAll
            // 
            TextBoxOfPurchaseAll.BackColor = SystemColors.Window;
            TextBoxOfPurchaseAll.Font = new Font("Segoe UI", 14F);
            TextBoxOfPurchaseAll.Location = new Point(718, 808);
            TextBoxOfPurchaseAll.Name = "TextBoxOfPurchaseAll";
            TextBoxOfPurchaseAll.ReadOnly = true;
            TextBoxOfPurchaseAll.Size = new Size(353, 45);
            TextBoxOfPurchaseAll.TabIndex = 11;
            TextBoxOfPurchaseAll.TextAlign = HorizontalAlignment.Center;
            // 
            // ButtonOfCancel
            // 
            ButtonOfCancel.FlatAppearance.BorderSize = 4;
            ButtonOfCancel.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfCancel.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfCancel.FlatStyle = FlatStyle.Flat;
            ButtonOfCancel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            ButtonOfCancel.Location = new Point(114, 829);
            ButtonOfCancel.Name = "ButtonOfCancel";
            ButtonOfCancel.Size = new Size(368, 71);
            ButtonOfCancel.TabIndex = 10;
            ButtonOfCancel.Text = "Отмена";
            ButtonOfCancel.UseVisualStyleBackColor = true;
            ButtonOfCancel.Enter += TabSelection_Enter;
            ButtonOfCancel.Leave += TabSelection_Leave;
            // 
            // MakingSupply
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(1223, 912);
            Controls.Add(ButtonOfCancel);
            Controls.Add(TextBoxOfPurchaseAll);
            Controls.Add(TextBoxOfQuantity);
            Controls.Add(TextBoxOfStockQuantity);
            Controls.Add(TextBoxOfUnit);
            Controls.Add(ComboBoxOfProduct);
            Controls.Add(ComboBoxOfCategory);
            Controls.Add(ButtonOfMakingSupply);
            Controls.Add(ButtonOfDeleteProduct);
            Controls.Add(ButtonOfUploadingByFile);
            Controls.Add(ButtonOfAddProduct);
            Controls.Add(LabelOfStockQuantity);
            Controls.Add(LabelOfUnit);
            Controls.Add(LabelOfPurchasePrice);
            Controls.Add(LabelOfQuantity);
            Controls.Add(LabelOfProduct);
            Controls.Add(LabelOfCategory);
            Controls.Add(LabelOfMakingSupply);
            Controls.Add(DataGridViewOfSupply);
            Name = "MakingSupply";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Оформление поставки";
            ((System.ComponentModel.ISupportInitialize)DataGridViewOfSupply).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DataGridViewOfSupply;
        private Label LabelOfMakingSupply;
        private Label LabelOfCategory;
        private Label LabelOfProduct;
        private Label LabelOfQuantity;
        private Label LabelOfPurchasePrice;
        private Label LabelOfUnit;
        private Label LabelOfStockQuantity;
        private Button ButtonOfAddProduct;
        private Button ButtonOfUploadingByFile;
        private Button ButtonOfDeleteProduct;
        private Button ButtonOfMakingSupply;
        private ComboBox ComboBoxOfCategory;
        private ComboBox ComboBoxOfProduct;
        private TextBox TextBoxOfUnit;
        private TextBox TextBoxOfStockQuantity;
        private TextBox TextBoxOfQuantity;
        private TextBox TextBoxOfPurchaseAll;
        private Button ButtonOfCancel;
    }
}