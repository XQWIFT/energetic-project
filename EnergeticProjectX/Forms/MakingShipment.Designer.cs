namespace EnergeticProjectX.Forms
{
    partial class MakingShipment
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
            LabelOfTitle = new Label();
            LabelOfClient = new Label();
            ComboBoxOfClient = new ComboBox();
            LabelOfProduct = new Label();
            ComboBoxOfProduct = new ComboBox();
            LabelOfQuantity = new Label();
            NumericQuantity = new NumericUpDown();
            ButtonOfAddProduct = new Button();
            DGVOfItems = new DataGridView();
            ButtonOfMakingShipment = new Button();
            ButtonOfCancel = new Button();
            LabelOfStockQuantity = new Label();
            TextBoxOfStockQuantity = new TextBox();
            ButtonOfProductDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)NumericQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGVOfItems).BeginInit();
            SuspendLayout();
            // 
            // LabelOfTitle
            // 
            LabelOfTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfTitle.Location = new Point(76, 32);
            LabelOfTitle.Name = "LabelOfTitle";
            LabelOfTitle.Size = new Size(393, 60);
            LabelOfTitle.TabIndex = 0;
            LabelOfTitle.Text = "Создание отгрузки";
            // 
            // LabelOfClient
            // 
            LabelOfClient.AutoSize = true;
            LabelOfClient.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            LabelOfClient.Location = new Point(10, 117);
            LabelOfClient.Name = "LabelOfClient";
            LabelOfClient.Size = new Size(180, 38);
            LabelOfClient.TabIndex = 0;
            LabelOfClient.Text = "Получатель";
            // 
            // ComboBoxOfClient
            // 
            ComboBoxOfClient.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOfClient.Font = new Font("Segoe UI", 14F);
            ComboBoxOfClient.Location = new Point(198, 114);
            ComboBoxOfClient.Name = "ComboBoxOfClient";
            ComboBoxOfClient.Size = new Size(352, 46);
            ComboBoxOfClient.TabIndex = 1;
            ComboBoxOfClient.SelectedIndexChanged += ValidateFields;
            // 
            // LabelOfProduct
            // 
            LabelOfProduct.AutoSize = true;
            LabelOfProduct.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            LabelOfProduct.Location = new Point(12, 176);
            LabelOfProduct.Name = "LabelOfProduct";
            LabelOfProduct.Size = new Size(96, 38);
            LabelOfProduct.TabIndex = 0;
            LabelOfProduct.Text = "Товар";
            // 
            // ComboBoxOfProduct
            // 
            ComboBoxOfProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOfProduct.Font = new Font("Segoe UI", 14F);
            ComboBoxOfProduct.Location = new Point(198, 178);
            ComboBoxOfProduct.Name = "ComboBoxOfProduct";
            ComboBoxOfProduct.Size = new Size(352, 46);
            ComboBoxOfProduct.TabIndex = 2;
            ComboBoxOfProduct.SelectedIndexChanged += ComboBoxOfProducts_SelectedIndexChanged;
            // 
            // LabelOfQuantity
            // 
            LabelOfQuantity.AutoSize = true;
            LabelOfQuantity.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            LabelOfQuantity.Location = new Point(12, 304);
            LabelOfQuantity.Name = "LabelOfQuantity";
            LabelOfQuantity.Size = new Size(178, 38);
            LabelOfQuantity.TabIndex = 0;
            LabelOfQuantity.Text = "Количество";
            // 
            // NumericQuantity
            // 
            NumericQuantity.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            NumericQuantity.Location = new Point(198, 302);
            NumericQuantity.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            NumericQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericQuantity.Name = "NumericQuantity";
            NumericQuantity.Size = new Size(352, 45);
            NumericQuantity.TabIndex = 4;
            NumericQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumericQuantity.ValueChanged += NumericQuantity_ValueChanged;
            // 
            // ButtonOfAddProduct
            // 
            ButtonOfAddProduct.Enabled = false;
            ButtonOfAddProduct.FlatAppearance.BorderSize = 4;
            ButtonOfAddProduct.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfAddProduct.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfAddProduct.FlatStyle = FlatStyle.Flat;
            ButtonOfAddProduct.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfAddProduct.Location = new Point(76, 389);
            ButtonOfAddProduct.Name = "ButtonOfAddProduct";
            ButtonOfAddProduct.Size = new Size(393, 62);
            ButtonOfAddProduct.TabIndex = 5;
            ButtonOfAddProduct.Text = "Добавить товар";
            ButtonOfAddProduct.UseVisualStyleBackColor = true;
            ButtonOfAddProduct.Click += ButtonOfAddProduct_Click;
            ButtonOfAddProduct.Enter += TabSelection_Enter;
            ButtonOfAddProduct.Leave += TabSelection_Leave;
            // 
            // DGVOfItems
            // 
            DGVOfItems.AllowUserToAddRows = false;
            DGVOfItems.AllowUserToDeleteRows = false;
            DGVOfItems.AllowUserToResizeColumns = false;
            DGVOfItems.AllowUserToResizeRows = false;
            DGVOfItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVOfItems.BackgroundColor = SystemColors.ControlLight;
            DGVOfItems.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGVOfItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGVOfItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVOfItems.EnableHeadersVisualStyles = false;
            DGVOfItems.Location = new Point(564, 0);
            DGVOfItems.Name = "DGVOfItems";
            DGVOfItems.ReadOnly = true;
            DGVOfItems.RowHeadersVisible = false;
            DGVOfItems.RowHeadersWidth = 62;
            DGVOfItems.Size = new Size(598, 766);
            DGVOfItems.TabIndex = 0;
            DGVOfItems.CellMouseClick += DGVOfItems_CellMouseClick;
            DGVOfItems.CellMouseDoubleClick += DGVOfItems_CellMouseClick;
            DGVOfItems.CellMouseEnter += DGVItems_CellMouseEnter;
            // 
            // ButtonOfMakingShipment
            // 
            ButtonOfMakingShipment.Enabled = false;
            ButtonOfMakingShipment.FlatAppearance.BorderSize = 4;
            ButtonOfMakingShipment.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfMakingShipment.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfMakingShipment.FlatStyle = FlatStyle.Flat;
            ButtonOfMakingShipment.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfMakingShipment.Location = new Point(76, 538);
            ButtonOfMakingShipment.Name = "ButtonOfMakingShipment";
            ButtonOfMakingShipment.Size = new Size(393, 56);
            ButtonOfMakingShipment.TabIndex = 7;
            ButtonOfMakingShipment.Text = "Оформить отгрузку";
            ButtonOfMakingShipment.UseVisualStyleBackColor = true;
            ButtonOfMakingShipment.Click += ButtonOfMakingShipment_Click;
            // 
            // ButtonOfCancel
            // 
            ButtonOfCancel.FlatAppearance.BorderSize = 4;
            ButtonOfCancel.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfCancel.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfCancel.FlatStyle = FlatStyle.Flat;
            ButtonOfCancel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfCancel.Location = new Point(76, 609);
            ButtonOfCancel.Name = "ButtonOfCancel";
            ButtonOfCancel.Size = new Size(393, 58);
            ButtonOfCancel.TabIndex = 8;
            ButtonOfCancel.Text = "Отмена";
            ButtonOfCancel.UseVisualStyleBackColor = true;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
            // 
            // LabelOfStockQuantity
            // 
            LabelOfStockQuantity.AutoSize = true;
            LabelOfStockQuantity.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfStockQuantity.Location = new Point(12, 240);
            LabelOfStockQuantity.Name = "LabelOfStockQuantity";
            LabelOfStockQuantity.Size = new Size(125, 38);
            LabelOfStockQuantity.TabIndex = 0;
            LabelOfStockQuantity.Text = "Остаток";
            // 
            // TextBoxOfStockQuantity
            // 
            TextBoxOfStockQuantity.BackColor = Color.White;
            TextBoxOfStockQuantity.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfStockQuantity.Location = new Point(198, 240);
            TextBoxOfStockQuantity.Name = "TextBoxOfStockQuantity";
            TextBoxOfStockQuantity.ReadOnly = true;
            TextBoxOfStockQuantity.Size = new Size(352, 45);
            TextBoxOfStockQuantity.TabIndex = 3;
            // 
            // ButtonOfProductDelete
            // 
            ButtonOfProductDelete.Enabled = false;
            ButtonOfProductDelete.FlatAppearance.BorderSize = 4;
            ButtonOfProductDelete.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfProductDelete.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfProductDelete.FlatStyle = FlatStyle.Flat;
            ButtonOfProductDelete.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfProductDelete.Location = new Point(76, 466);
            ButtonOfProductDelete.Name = "ButtonOfProductDelete";
            ButtonOfProductDelete.Size = new Size(393, 57);
            ButtonOfProductDelete.TabIndex = 6;
            ButtonOfProductDelete.Text = "Удалить товар";
            ButtonOfProductDelete.UseVisualStyleBackColor = true;
            ButtonOfProductDelete.Click += ButtonOfProductDelete_Click;
            // 
            // MakingShipment
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(1164, 768);
            Controls.Add(ButtonOfProductDelete);
            Controls.Add(TextBoxOfStockQuantity);
            Controls.Add(LabelOfStockQuantity);
            Controls.Add(LabelOfTitle);
            Controls.Add(LabelOfClient);
            Controls.Add(ComboBoxOfClient);
            Controls.Add(LabelOfProduct);
            Controls.Add(ComboBoxOfProduct);
            Controls.Add(LabelOfQuantity);
            Controls.Add(NumericQuantity);
            Controls.Add(ButtonOfAddProduct);
            Controls.Add(DGVOfItems);
            Controls.Add(ButtonOfMakingShipment);
            Controls.Add(ButtonOfCancel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MakingShipment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Оформление отгрузки";
            ((System.ComponentModel.ISupportInitialize)NumericQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGVOfItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelOfTitle;
        private Label LabelOfClient;
        private ComboBox ComboBoxOfClient;
        private Label LabelOfProduct;
        private ComboBox ComboBoxOfProduct;
        private Label LabelOfQuantity;
        private NumericUpDown NumericQuantity;
        private Button ButtonOfAddProduct;
        private DataGridView DGVOfItems;
        private Button ButtonOfMakingShipment;
        private Button ButtonOfCancel;
        private Label LabelOfStockQuantity;
        private TextBox TextBoxOfStockQuantity;
        private Button ButtonOfProductDelete;
    }
}