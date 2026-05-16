namespace EnergeticProjectX.Forms
{
    partial class TableOfProducts
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            ButtonOfAddCategory = new Button();
            ButtonOfAddProduct = new Button();
            ButtonOfMainMenu = new Button();
            ButtonOfProductCard = new Button();
            DGVOfProducts = new DataGridView();
            ButtonOfMakingShipment = new Button();
            PanelSearch = new Panel();
            LabelOfSearch = new Label();
            TextBoxOfSearch = new TextBox();
            ButtonOfSearch = new Button();
            ButtonOfChangeCaterogies = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVOfProducts).BeginInit();
            PanelSearch.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonOfAddCategory
            // 
            ButtonOfAddCategory.FlatAppearance.BorderColor = Color.Black;
            ButtonOfAddCategory.FlatAppearance.BorderSize = 4;
            ButtonOfAddCategory.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfAddCategory.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfAddCategory.FlatStyle = FlatStyle.Flat;
            ButtonOfAddCategory.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            ButtonOfAddCategory.ForeColor = SystemColors.ControlText;
            ButtonOfAddCategory.Location = new Point(89, 718);
            ButtonOfAddCategory.Name = "ButtonOfAddCategory";
            ButtonOfAddCategory.Size = new Size(384, 69);
            ButtonOfAddCategory.TabIndex = 5;
            ButtonOfAddCategory.Text = "Добавить категорию";
            ButtonOfAddCategory.UseVisualStyleBackColor = true;
            ButtonOfAddCategory.Click += ButtonOfAddCategory_Click;
            ButtonOfAddCategory.Enter += TabSelection_Enter;
            ButtonOfAddCategory.Leave += TabSelection_Leave;
            // 
            // ButtonOfAddProduct
            // 
            ButtonOfAddProduct.FlatAppearance.BorderColor = Color.Black;
            ButtonOfAddProduct.FlatAppearance.BorderSize = 4;
            ButtonOfAddProduct.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfAddProduct.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfAddProduct.FlatStyle = FlatStyle.Flat;
            ButtonOfAddProduct.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfAddProduct.Location = new Point(308, 636);
            ButtonOfAddProduct.Name = "ButtonOfAddProduct";
            ButtonOfAddProduct.Size = new Size(369, 66);
            ButtonOfAddProduct.TabIndex = 5;
            ButtonOfAddProduct.Text = "Добавить товар";
            ButtonOfAddProduct.UseVisualStyleBackColor = true;
            ButtonOfAddProduct.Click += ButtonAddProduct_Click;
            ButtonOfAddProduct.Enter += TabSelection_Enter;
            ButtonOfAddProduct.Leave += TabSelection_Leave;
            // 
            // ButtonOfMainMenu
            // 
            ButtonOfMainMenu.FlatAppearance.BorderColor = Color.Black;
            ButtonOfMainMenu.FlatAppearance.BorderSize = 4;
            ButtonOfMainMenu.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfMainMenu.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfMainMenu.FlatStyle = FlatStyle.Flat;
            ButtonOfMainMenu.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfMainMenu.Location = new Point(16, 636);
            ButtonOfMainMenu.Name = "ButtonOfMainMenu";
            ButtonOfMainMenu.Size = new Size(286, 66);
            ButtonOfMainMenu.TabIndex = 2;
            ButtonOfMainMenu.Text = "Главное меню";
            ButtonOfMainMenu.UseVisualStyleBackColor = true;
            ButtonOfMainMenu.Click += ButtonOfMainMenu_Click;
            ButtonOfMainMenu.Enter += TabSelection_Enter;
            ButtonOfMainMenu.Leave += TabSelection_Leave;
            // 
            // ButtonOfProductCard
            // 
            ButtonOfProductCard.Enabled = false;
            ButtonOfProductCard.FlatAppearance.BorderColor = Color.Black;
            ButtonOfProductCard.FlatAppearance.BorderSize = 4;
            ButtonOfProductCard.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfProductCard.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfProductCard.FlatStyle = FlatStyle.Flat;
            ButtonOfProductCard.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            ButtonOfProductCard.Location = new Point(683, 636);
            ButtonOfProductCard.Name = "ButtonOfProductCard";
            ButtonOfProductCard.Size = new Size(297, 66);
            ButtonOfProductCard.TabIndex = 4;
            ButtonOfProductCard.Text = "Карточка товара";
            ButtonOfProductCard.UseVisualStyleBackColor = true;
            ButtonOfProductCard.Click += ButtonOfProductCard_Click;
            ButtonOfProductCard.Enter += TabSelection_Enter;
            ButtonOfProductCard.Leave += TabSelection_Leave;
            // 
            // DGVOfProducts
            // 
            DGVOfProducts.AllowUserToAddRows = false;
            DGVOfProducts.AllowUserToDeleteRows = false;
            DGVOfProducts.AllowUserToResizeColumns = false;
            DGVOfProducts.AllowUserToResizeRows = false;
            DGVOfProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVOfProducts.BackgroundColor = SystemColors.ControlLight;
            DGVOfProducts.BorderStyle = BorderStyle.Fixed3D;
            DGVOfProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DGVOfProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DGVOfProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVOfProducts.EnableHeadersVisualStyles = false;
            DGVOfProducts.GridColor = SystemColors.WindowText;
            DGVOfProducts.Location = new Point(16, 81);
            DGVOfProducts.MultiSelect = false;
            DGVOfProducts.Name = "DGVOfProducts";
            DGVOfProducts.ReadOnly = true;
            DGVOfProducts.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            DGVOfProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DGVOfProducts.RowHeadersVisible = false;
            DGVOfProducts.RowHeadersWidth = 62;
            DGVOfProducts.Size = new Size(964, 540);
            DGVOfProducts.TabIndex = 0;
            DGVOfProducts.CellMouseClick += DGVProducts_CellMouseClick;
            DGVOfProducts.CellMouseDoubleClick += DGVProducts_CellMouseClick;
            DGVOfProducts.CellMouseEnter += DGVProducts_CellMouseEnter;
            DGVOfProducts.SelectionChanged += DGVProducts_SelectionChanged;
            // 
            // ButtonOfMakingShipment
            // 
            ButtonOfMakingShipment.FlatAppearance.BorderColor = Color.Black;
            ButtonOfMakingShipment.FlatAppearance.BorderSize = 4;
            ButtonOfMakingShipment.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfMakingShipment.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfMakingShipment.FlatStyle = FlatStyle.Flat;
            ButtonOfMakingShipment.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            ButtonOfMakingShipment.Location = new Point(308, 636);
            ButtonOfMakingShipment.Name = "ButtonOfMakingShipment";
            ButtonOfMakingShipment.Size = new Size(369, 66);
            ButtonOfMakingShipment.TabIndex = 3;
            ButtonOfMakingShipment.Text = "Оформление отгрузки";
            ButtonOfMakingShipment.UseVisualStyleBackColor = true;
            ButtonOfMakingShipment.Click += ButtonOfMakingShipment_Click;
            ButtonOfMakingShipment.Enter += TabSelection_Enter;
            ButtonOfMakingShipment.Leave += TabSelection_Leave;
            // 
            // PanelSearch
            // 
            PanelSearch.Controls.Add(LabelOfSearch);
            PanelSearch.Controls.Add(TextBoxOfSearch);
            PanelSearch.Controls.Add(ButtonOfSearch);
            PanelSearch.Location = new Point(13, 12);
            PanelSearch.Name = "PanelSearch";
            PanelSearch.Size = new Size(967, 63);
            PanelSearch.TabIndex = 0;
            PanelSearch.Visible = false;
            // 
            // LabelOfSearch
            // 
            LabelOfSearch.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfSearch.Location = new Point(3, 7);
            LabelOfSearch.Name = "LabelOfSearch";
            LabelOfSearch.Size = new Size(150, 46);
            LabelOfSearch.TabIndex = 0;
            LabelOfSearch.Text = "Поиск:";
            LabelOfSearch.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TextBoxOfSearch
            // 
            TextBoxOfSearch.Font = new Font("Segoe UI", 12F);
            TextBoxOfSearch.Location = new Point(149, 14);
            TextBoxOfSearch.Name = "TextBoxOfSearch";
            TextBoxOfSearch.Size = new Size(622, 39);
            TextBoxOfSearch.TabIndex = 1;
            // 
            // ButtonOfSearch
            // 
            ButtonOfSearch.FlatAppearance.BorderSize = 4;
            ButtonOfSearch.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfSearch.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfSearch.FlatStyle = FlatStyle.Flat;
            ButtonOfSearch.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfSearch.Location = new Point(793, 3);
            ButtonOfSearch.Name = "ButtonOfSearch";
            ButtonOfSearch.Size = new Size(171, 60);
            ButtonOfSearch.TabIndex = 2;
            ButtonOfSearch.Text = "Найти";
            ButtonOfSearch.UseVisualStyleBackColor = true;
            ButtonOfSearch.Click += ButtonOfSearch_Click;
            // 
            // ButtonOfChangeCaterogies
            // 
            ButtonOfChangeCaterogies.FlatAppearance.BorderColor = Color.Black;
            ButtonOfChangeCaterogies.FlatAppearance.BorderSize = 4;
            ButtonOfChangeCaterogies.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfChangeCaterogies.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfChangeCaterogies.FlatStyle = FlatStyle.Flat;
            ButtonOfChangeCaterogies.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            ButtonOfChangeCaterogies.Location = new Point(479, 718);
            ButtonOfChangeCaterogies.Name = "ButtonOfChangeCaterogies";
            ButtonOfChangeCaterogies.Size = new Size(422, 69);
            ButtonOfChangeCaterogies.TabIndex = 6;
            ButtonOfChangeCaterogies.Text = "Редактировать категории";
            ButtonOfChangeCaterogies.UseVisualStyleBackColor = true;
            ButtonOfChangeCaterogies.Click += ButtonOfChangeCaterogies_Click;
            ButtonOfChangeCaterogies.Enter += TabSelection_Enter;
            ButtonOfChangeCaterogies.Leave += TabSelection_Leave;
            // 
            // TableOfProducts
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(992, 794);
            Controls.Add(ButtonOfChangeCaterogies);
            Controls.Add(PanelSearch);
            Controls.Add(ButtonOfMakingShipment);
            Controls.Add(DGVOfProducts);
            Controls.Add(ButtonOfProductCard);
            Controls.Add(ButtonOfAddCategory);
            Controls.Add(ButtonOfAddProduct);
            Controls.Add(ButtonOfMainMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "TableOfProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Информация о товаре";
            ((System.ComponentModel.ISupportInitialize)DGVOfProducts).EndInit();
            PanelSearch.ResumeLayout(false);
            PanelSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonOfAddCategory;
        private Button ButtonOfAddProduct;
        private Button ButtonOfMainMenu;
        private Button ButtonOfProductCard;
        private DataGridView DGVOfProducts;
        private Button ButtonOfMakingShipment;
        private Panel PanelSearch;
        private TextBox TextBoxOfSearch;
        private Label LabelOfSearch;
        private Button ButtonOfSearch;
        private Button ButtonOfChangeCaterogies;
    }
}