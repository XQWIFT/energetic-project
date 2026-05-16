namespace EnergeticProjectX.Forms
{
    partial class HeatMapForm
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
            PanelSearch = new Panel();
            LabelOfSearch = new Label();
            TextBoxOfSearch = new TextBox();
            ButtonOfSearch = new Button();
            DGVOfProducts = new DataGridView();
            ButtonOfMainMenu = new Button();
            labelOfInformationQuantity = new Label();
            labelOfPriceAlreadyLowered = new Label();
            labelOfPriceWillLowered = new Label();
            ButtonOfTableOfProducts = new Button();
            PanelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVOfProducts).BeginInit();
            SuspendLayout();
            // 
            // PanelSearch
            // 
            PanelSearch.Controls.Add(LabelOfSearch);
            PanelSearch.Controls.Add(TextBoxOfSearch);
            PanelSearch.Controls.Add(ButtonOfSearch);
            PanelSearch.Location = new Point(13, -2);
            PanelSearch.Name = "PanelSearch";
            PanelSearch.Size = new Size(967, 63);
            PanelSearch.TabIndex = 1;
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
            ButtonOfSearch.TabIndex = 1;
            ButtonOfSearch.Text = "Найти";
            ButtonOfSearch.UseVisualStyleBackColor = true;
            ButtonOfSearch.Click += ButtonOfSearch_Click;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGVOfProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGVOfProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVOfProducts.EnableHeadersVisualStyles = false;
            DGVOfProducts.GridColor = SystemColors.WindowText;
            DGVOfProducts.Location = new Point(12, 67);
            DGVOfProducts.MultiSelect = false;
            DGVOfProducts.Name = "DGVOfProducts";
            DGVOfProducts.ReadOnly = true;
            DGVOfProducts.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DGVOfProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DGVOfProducts.RowHeadersVisible = false;
            DGVOfProducts.RowHeadersWidth = 62;
            DGVOfProducts.Size = new Size(968, 539);
            DGVOfProducts.TabIndex = 0;
            DGVOfProducts.TabStop = false;
            DGVOfProducts.CellFormatting += DGVProducts_CellFormatting;
            DGVOfProducts.CellMouseClick += DGVProducts_CellMouseClick;
            DGVOfProducts.CellMouseDoubleClick += DGVProducts_CellMouseClick;
            DGVOfProducts.CellMouseEnter += DGVProducts_CellMouseEnter;
            // 
            // ButtonOfMainMenu
            // 
            ButtonOfMainMenu.FlatAppearance.BorderColor = Color.Black;
            ButtonOfMainMenu.FlatAppearance.BorderSize = 4;
            ButtonOfMainMenu.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfMainMenu.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfMainMenu.FlatStyle = FlatStyle.Flat;
            ButtonOfMainMenu.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfMainMenu.Location = new Point(138, 625);
            ButtonOfMainMenu.Name = "ButtonOfMainMenu";
            ButtonOfMainMenu.Size = new Size(362, 66);
            ButtonOfMainMenu.TabIndex = 2;
            ButtonOfMainMenu.Text = "Главное меню";
            ButtonOfMainMenu.UseVisualStyleBackColor = true;
            ButtonOfMainMenu.Click += ButtonOfMainMenu_Click;
            ButtonOfMainMenu.Enter += TabSelection_Enter;
            ButtonOfMainMenu.Leave += TabSelection_Leave;
            // 
            // labelOfInformationQuantity
            // 
            labelOfInformationQuantity.BackColor = Color.LightCoral;
            labelOfInformationQuantity.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfInformationQuantity.Location = new Point(12, 709);
            labelOfInformationQuantity.Name = "labelOfInformationQuantity";
            labelOfInformationQuantity.Size = new Size(310, 76);
            labelOfInformationQuantity.TabIndex = 4;
            labelOfInformationQuantity.Text = "Критический остаток";
            labelOfInformationQuantity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelOfPriceAlreadyLowered
            // 
            labelOfPriceAlreadyLowered.BackColor = Color.LightSalmon;
            labelOfPriceAlreadyLowered.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfPriceAlreadyLowered.Location = new Point(328, 709);
            labelOfPriceAlreadyLowered.Name = "labelOfPriceAlreadyLowered";
            labelOfPriceAlreadyLowered.Size = new Size(319, 76);
            labelOfPriceAlreadyLowered.TabIndex = 5;
            labelOfPriceAlreadyLowered.Text = "Цена уже снижена";
            labelOfPriceAlreadyLowered.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelOfPriceWillLowered
            // 
            labelOfPriceWillLowered.BackColor = Color.LemonChiffon;
            labelOfPriceWillLowered.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfPriceWillLowered.Location = new Point(653, 709);
            labelOfPriceWillLowered.Name = "labelOfPriceWillLowered";
            labelOfPriceWillLowered.Size = new Size(327, 76);
            labelOfPriceWillLowered.TabIndex = 6;
            labelOfPriceWillLowered.Text = "Скоро снижение цены";
            labelOfPriceWillLowered.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ButtonOfTableOfProducts
            // 
            ButtonOfTableOfProducts.FlatAppearance.BorderColor = Color.Black;
            ButtonOfTableOfProducts.FlatAppearance.BorderSize = 4;
            ButtonOfTableOfProducts.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfTableOfProducts.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfTableOfProducts.FlatStyle = FlatStyle.Flat;
            ButtonOfTableOfProducts.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfTableOfProducts.Location = new Point(506, 624);
            ButtonOfTableOfProducts.Name = "ButtonOfTableOfProducts";
            ButtonOfTableOfProducts.Size = new Size(344, 67);
            ButtonOfTableOfProducts.TabIndex = 3;
            ButtonOfTableOfProducts.Text = "Каталог товаров";
            ButtonOfTableOfProducts.UseVisualStyleBackColor = true;
            ButtonOfTableOfProducts.Click += ButtonOfTableOfProducts_Click;
            ButtonOfTableOfProducts.Enter += TabSelection_Enter;
            ButtonOfTableOfProducts.Leave += TabSelection_Leave;
            // 
            // HeatMapForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 794);
            Controls.Add(ButtonOfTableOfProducts);
            Controls.Add(labelOfPriceWillLowered);
            Controls.Add(labelOfPriceAlreadyLowered);
            Controls.Add(labelOfInformationQuantity);
            Controls.Add(ButtonOfMainMenu);
            Controls.Add(PanelSearch);
            Controls.Add(DGVOfProducts);
            Name = "HeatMapForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Тепловая карта склада";
            PanelSearch.ResumeLayout(false);
            PanelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVOfProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelSearch;
        private Label LabelOfSearch;
        private TextBox TextBoxOfSearch;
        private Button ButtonOfSearch;
        private DataGridView DGVOfProducts;
        private Button ButtonOfMainMenu;
        private Label labelOfInformationQuantity;
        private Label labelOfPriceAlreadyLowered;
        private Label labelOfPriceWillLowered;
        private Button ButtonOfTableOfProducts;
    }
}