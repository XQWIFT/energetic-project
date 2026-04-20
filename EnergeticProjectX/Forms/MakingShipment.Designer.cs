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
            labelTitle = new Label();
            labelRecipient = new Label();
            comboBoxRecipient = new ComboBox();
            labelProduct = new Label();
            comboBoxProduct = new ComboBox();
            labelQuantity = new Label();
            numericQuantity = new NumericUpDown();
            labelNote = new Label();
            buttonAddProduct = new Button();
            dataGridOfItems = new DataGridView();
            buttonMakeShipment = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridOfItems).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTitle.Location = new Point(57, 25);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(470, 60);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Оформление отгрузки";
            // 
            // labelRecipient
            // 
            labelRecipient.AutoSize = true;
            labelRecipient.Font = new Font("Segoe UI", 12F);
            labelRecipient.Location = new Point(12, 112);
            labelRecipient.Name = "labelRecipient";
            labelRecipient.Size = new Size(144, 32);
            labelRecipient.TabIndex = 1;
            labelRecipient.Text = "Получатель";
            // 
            // comboBoxRecipient
            // 
            comboBoxRecipient.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRecipient.Font = new Font("Segoe UI", 12F);
            comboBoxRecipient.Location = new Point(160, 109);
            comboBoxRecipient.Name = "comboBoxRecipient";
            comboBoxRecipient.Size = new Size(390, 40);
            comboBoxRecipient.TabIndex = 2;
            // 
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Font = new Font("Segoe UI", 12F);
            labelProduct.Location = new Point(12, 157);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(80, 32);
            labelProduct.TabIndex = 3;
            labelProduct.Text = "Товар";
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProduct.Font = new Font("Segoe UI", 12F);
            comboBoxProduct.Location = new Point(160, 154);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(390, 40);
            comboBoxProduct.TabIndex = 4;
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Font = new Font("Segoe UI", 12F);
            labelQuantity.Location = new Point(12, 202);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(144, 32);
            labelQuantity.TabIndex = 5;
            labelQuantity.Text = "Количество";
            // 
            // numericQuantity
            // 
            numericQuantity.Font = new Font("Segoe UI", 12F);
            numericQuantity.Location = new Point(160, 200);
            numericQuantity.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericQuantity.Name = "numericQuantity";
            numericQuantity.Size = new Size(120, 39);
            numericQuantity.TabIndex = 6;
            numericQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelNote
            // 
            labelNote.AutoSize = true;
            labelNote.Font = new Font("Segoe UI", 9F);
            labelNote.ForeColor = Color.Gray;
            labelNote.Location = new Point(12, 250);
            labelNote.Name = "labelNote";
            labelNote.Size = new Size(296, 25);
            labelNote.TabIndex = 7;
            labelNote.Text = "Все поля являются обязательными";
            // 
            // buttonAddProduct
            // 
            buttonAddProduct.Font = new Font("Segoe UI", 12F);
            buttonAddProduct.Location = new Point(160, 290);
            buttonAddProduct.Name = "buttonAddProduct";
            buttonAddProduct.Size = new Size(220, 42);
            buttonAddProduct.TabIndex = 8;
            buttonAddProduct.Text = "Добавить товар";
            buttonAddProduct.UseVisualStyleBackColor = true;
            buttonAddProduct.Click += buttonAddProduct_Click;
            // 
            // dataGridOfItems
            // 
            dataGridOfItems.AllowUserToAddRows = false;
            dataGridOfItems.AllowUserToDeleteRows = false;
            dataGridOfItems.AllowUserToResizeColumns = false;
            dataGridOfItems.AllowUserToResizeRows = false;
            dataGridOfItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOfItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridOfItems.Location = new Point(12, 350);
            dataGridOfItems.Name = "dataGridOfItems";
            dataGridOfItems.ReadOnly = true;
            dataGridOfItems.RowHeadersVisible = false;
            dataGridOfItems.RowHeadersWidth = 62;
            dataGridOfItems.Size = new Size(546, 220);
            dataGridOfItems.TabIndex = 0;
            // 
            // buttonMakeShipment
            // 
            buttonMakeShipment.Font = new Font("Segoe UI", 12F);
            buttonMakeShipment.Location = new Point(12, 576);
            buttonMakeShipment.Name = "buttonMakeShipment";
            buttonMakeShipment.Size = new Size(270, 45);
            buttonMakeShipment.TabIndex = 9;
            buttonMakeShipment.Text = "Оформить отгрузку";
            buttonMakeShipment.UseVisualStyleBackColor = true;
            buttonMakeShipment.Click += buttonMakeShipment_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 12F);
            buttonCancel.Location = new Point(288, 576);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(270, 45);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // MakingShipment
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(590, 633);
            Controls.Add(labelTitle);
            Controls.Add(labelRecipient);
            Controls.Add(comboBoxRecipient);
            Controls.Add(labelProduct);
            Controls.Add(comboBoxProduct);
            Controls.Add(labelQuantity);
            Controls.Add(numericQuantity);
            Controls.Add(labelNote);
            Controls.Add(buttonAddProduct);
            Controls.Add(dataGridOfItems);
            Controls.Add(buttonMakeShipment);
            Controls.Add(buttonCancel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MakingShipment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Оформление отгрузки";
            ((System.ComponentModel.ISupportInitialize)numericQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridOfItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelRecipient;
        private ComboBox comboBoxRecipient;
        private Label labelProduct;
        private ComboBox comboBoxProduct;
        private Label labelQuantity;
        private NumericUpDown numericQuantity;
        private Label labelNote;
        private Button buttonAddProduct;
        private DataGridView dataGridOfItems;
        private Button buttonMakeShipment;
        private Button buttonCancel;
    }
}