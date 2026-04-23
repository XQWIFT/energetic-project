namespace MakingShipmentForm
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
            LabelOfTitle = new Label();
            LabelOfRecipient = new Label();
            ComboBoxRecipient = new ComboBox();
            LabelOfProduct = new Label();
            ComboBoxProduct = new ComboBox();
            LabelOfQuantity = new Label();
            NumericQuantity = new NumericUpDown();
            ButtonOfAddProduct = new Button();
            DataGridOfItems = new DataGridView();
            ButtonOfMakingShipment = new Button();
            ButtonOfCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)NumericQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGridOfItems).BeginInit();
            SuspendLayout();
            // 
            // LabelOfTitle
            // 
            LabelOfTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfTitle.Location = new Point(57, 25);
            LabelOfTitle.Name = "LabelOfTitle";
            LabelOfTitle.Size = new Size(470, 60);
            LabelOfTitle.TabIndex = 0;
            LabelOfTitle.Text = "Оформление отгрузки";
            // 
            // LabelOfRecipient
            // 
            LabelOfRecipient.AutoSize = true;
            LabelOfRecipient.Font = new Font("Segoe UI", 12F);
            LabelOfRecipient.Location = new Point(12, 112);
            LabelOfRecipient.Name = "LabelOfRecipient";
            LabelOfRecipient.Size = new Size(144, 32);
            LabelOfRecipient.TabIndex = 1;
            LabelOfRecipient.Text = "Получатель";
            // 
            // ComboBoxRecipient
            // 
            ComboBoxRecipient.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxRecipient.Font = new Font("Segoe UI", 12F);
            ComboBoxRecipient.Location = new Point(160, 109);
            ComboBoxRecipient.Name = "ComboBoxRecipient";
            ComboBoxRecipient.Size = new Size(390, 40);
            ComboBoxRecipient.TabIndex = 2;
            // 
            // LabelOfProduct
            // 
            LabelOfProduct.AutoSize = true;
            LabelOfProduct.Font = new Font("Segoe UI", 12F);
            LabelOfProduct.Location = new Point(12, 157);
            LabelOfProduct.Name = "LabelOfProduct";
            LabelOfProduct.Size = new Size(80, 32);
            LabelOfProduct.TabIndex = 3;
            LabelOfProduct.Text = "Товар";
            // 
            // ComboBoxProduct
            // 
            ComboBoxProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxProduct.Font = new Font("Segoe UI", 12F);
            ComboBoxProduct.Location = new Point(160, 154);
            ComboBoxProduct.Name = "ComboBoxProduct";
            ComboBoxProduct.Size = new Size(390, 40);
            ComboBoxProduct.TabIndex = 4;
            // 
            // LabelOfQuantity
            // 
            LabelOfQuantity.AutoSize = true;
            LabelOfQuantity.Font = new Font("Segoe UI", 12F);
            LabelOfQuantity.Location = new Point(12, 202);
            LabelOfQuantity.Name = "LabelOfQuantity";
            LabelOfQuantity.Size = new Size(144, 32);
            LabelOfQuantity.TabIndex = 5;
            LabelOfQuantity.Text = "Количество";
            // 
            // NumericQuantity
            // 
            NumericQuantity.Font = new Font("Segoe UI", 12F);
            NumericQuantity.Location = new Point(160, 200);
            NumericQuantity.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            NumericQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericQuantity.Name = "NumericQuantity";
            NumericQuantity.Size = new Size(120, 39);
            NumericQuantity.TabIndex = 6;
            NumericQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ButtonOfAddProduct
            // 
            ButtonOfAddProduct.Font = new Font("Segoe UI", 12F);
            ButtonOfAddProduct.Location = new Point(160, 290);
            ButtonOfAddProduct.Name = "ButtonOfAddProduct";
            ButtonOfAddProduct.Size = new Size(220, 42);
            ButtonOfAddProduct.TabIndex = 8;
            ButtonOfAddProduct.Text = "Добавить товар";
            ButtonOfAddProduct.UseVisualStyleBackColor = true;
            ButtonOfAddProduct.Click += ButtonAddProduct_Click;
            // 
            // DataGridOfItems
            // 
            DataGridOfItems.AllowUserToAddRows = false;
            DataGridOfItems.AllowUserToDeleteRows = false;
            DataGridOfItems.AllowUserToResizeColumns = false;
            DataGridOfItems.AllowUserToResizeRows = false;
            DataGridOfItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridOfItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridOfItems.EnableHeadersVisualStyles = false;
            DataGridOfItems.Location = new Point(12, 350);
            DataGridOfItems.Name = "DataGridOfItems";
            DataGridOfItems.ReadOnly = true;
            DataGridOfItems.RowHeadersVisible = false;
            DataGridOfItems.RowHeadersWidth = 62;
            DataGridOfItems.Size = new Size(546, 220);
            DataGridOfItems.TabIndex = 0;
            // 
            // ButtonOfMakingShipment
            // 
            ButtonOfMakingShipment.Enabled = false;
            ButtonOfMakingShipment.Font = new Font("Segoe UI", 12F);
            ButtonOfMakingShipment.Location = new Point(12, 576);
            ButtonOfMakingShipment.Name = "ButtonOfMakingShipment";
            ButtonOfMakingShipment.Size = new Size(270, 45);
            ButtonOfMakingShipment.TabIndex = 9;
            ButtonOfMakingShipment.Text = "Оформить отгрузку";
            ButtonOfMakingShipment.UseVisualStyleBackColor = true;
            ButtonOfMakingShipment.Click += ButtonMakeShipment_Click;
            // 
            // ButtonOfCancel
            // 
            ButtonOfCancel.Font = new Font("Segoe UI", 12F);
            ButtonOfCancel.Location = new Point(288, 576);
            ButtonOfCancel.Name = "ButtonOfCancel";
            ButtonOfCancel.Size = new Size(270, 45);
            ButtonOfCancel.TabIndex = 10;
            ButtonOfCancel.Text = "Отмена";
            ButtonOfCancel.UseVisualStyleBackColor = true;
            ButtonOfCancel.Click += ButtonCancel_Click;
            // 
            // MakingShipment
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(590, 633);
            Controls.Add(LabelOfTitle);
            Controls.Add(LabelOfRecipient);
            Controls.Add(ComboBoxRecipient);
            Controls.Add(LabelOfProduct);
            Controls.Add(ComboBoxProduct);
            Controls.Add(LabelOfQuantity);
            Controls.Add(NumericQuantity);
            Controls.Add(ButtonOfAddProduct);
            Controls.Add(DataGridOfItems);
            Controls.Add(ButtonOfMakingShipment);
            Controls.Add(ButtonOfCancel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MakingShipment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Оформление отгрузки";
            ((System.ComponentModel.ISupportInitialize)NumericQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGridOfItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelOfTitle;
        private Label LabelOfRecipient;
        private ComboBox ComboBoxRecipient;
        private Label LabelOfProduct;
        private ComboBox ComboBoxProduct;
        private Label LabelOfQuantity;
        private NumericUpDown NumericQuantity;
        private Button ButtonOfAddProduct;
        private DataGridView DataGridOfItems;
        private Button ButtonOfMakingShipment;
        private Button ButtonOfCancel;
    }
}