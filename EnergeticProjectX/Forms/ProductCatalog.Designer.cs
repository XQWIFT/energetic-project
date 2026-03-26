namespace ProductCatalogForm
{
    partial class ProductCatalog
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
            buttonOfCategories = new Button();
            buttonAddProduct = new Button();
            buttonOfMainMenu = new Button();
            buttonOfProductCards = new Button();
            dataGridOfProducts = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridOfProducts).BeginInit();
            SuspendLayout();
            // 
            // buttonOfCategories
            // 
            buttonOfCategories.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfCategories.Location = new Point(733, 629);
            buttonOfCategories.Name = "buttonOfCategories";
            buttonOfCategories.Size = new Size(231, 51);
            buttonOfCategories.TabIndex = 6;
            buttonOfCategories.Text = "Категории";
            buttonOfCategories.UseVisualStyleBackColor = true;
            buttonOfCategories.Click += buttonOfCategories_Click;
            // 
            // buttonAddProduct
            // 
            buttonAddProduct.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAddProduct.Location = new Point(487, 628);
            buttonAddProduct.Name = "buttonAddProduct";
            buttonAddProduct.Size = new Size(231, 53);
            buttonAddProduct.TabIndex = 5;
            buttonAddProduct.Text = "Добавить товар";
            buttonAddProduct.UseVisualStyleBackColor = true;
            buttonAddProduct.Click += buttonAddProduct_Click;
            // 
            // buttonOfMainMenu
            // 
            buttonOfMainMenu.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfMainMenu.Location = new Point(13, 627);
            buttonOfMainMenu.Name = "buttonOfMainMenu";
            buttonOfMainMenu.Size = new Size(231, 53);
            buttonOfMainMenu.TabIndex = 4;
            buttonOfMainMenu.Text = "Главное меню";
            buttonOfMainMenu.UseVisualStyleBackColor = true;
            buttonOfMainMenu.Click += buttonOfMainMenu_Click;
            // 
            // buttonOfProductCards
            // 
            buttonOfProductCards.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfProductCards.Location = new Point(250, 627);
            buttonOfProductCards.Name = "buttonOfProductCards";
            buttonOfProductCards.Size = new Size(231, 53);
            buttonOfProductCards.TabIndex = 7;
            buttonOfProductCards.Text = "Карточка товара";
            buttonOfProductCards.UseVisualStyleBackColor = true;
            buttonOfProductCards.Click += buttonOfProductCards_Click;
            // 
            // dataGridOfProducts
            // 
            dataGridOfProducts.AllowUserToAddRows = false;
            dataGridOfProducts.AllowUserToDeleteRows = false;
            dataGridOfProducts.AllowUserToResizeColumns = false;
            dataGridOfProducts.AllowUserToResizeRows = false;
            dataGridOfProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOfProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridOfProducts.Location = new Point(13, 55);
            dataGridOfProducts.Name = "dataGridOfProducts";
            dataGridOfProducts.ReadOnly = true;
            dataGridOfProducts.RowHeadersVisible = false;
            dataGridOfProducts.RowHeadersWidth = 62;
            dataGridOfProducts.Size = new Size(941, 546);
            dataGridOfProducts.TabIndex = 8;
            // 
            // ProductCatalog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 690);
            Controls.Add(dataGridOfProducts);
            Controls.Add(buttonOfProductCards);
            Controls.Add(buttonOfCategories);
            Controls.Add(buttonAddProduct);
            Controls.Add(buttonOfMainMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ProductCatalog";
            Text = "Каталог товаров";
            ((System.ComponentModel.ISupportInitialize)dataGridOfProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonOfCategories;
        private Button buttonAddProduct;
        private Button buttonOfMainMenu;
        private Button buttonOfProductCards;
        private DataGridView dataGridOfProducts;
    }
}