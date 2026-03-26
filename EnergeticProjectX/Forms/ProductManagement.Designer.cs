namespace ProductManagementForms
{
    partial class ProductManagement
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
            buttonOfCancel = new Button();
            buttonOfDeleteProduct = new Button();
            buttonOfEditProduct = new Button();
            SuspendLayout();
            // 
            // buttonOfCancel
            // 
            buttonOfCancel.BackColor = Color.Coral;
            buttonOfCancel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfCancel.ForeColor = Color.Black;
            buttonOfCancel.Location = new Point(155, 251);
            buttonOfCancel.Name = "buttonOfCancel";
            buttonOfCancel.Size = new Size(237, 68);
            buttonOfCancel.TabIndex = 5;
            buttonOfCancel.Text = "Отменить";
            buttonOfCancel.UseVisualStyleBackColor = false;
            buttonOfCancel.Click += buttonOfCancel_Click;
            // 
            // buttonOfDeleteProduct
            // 
            buttonOfDeleteProduct.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfDeleteProduct.Location = new Point(37, 131);
            buttonOfDeleteProduct.Name = "buttonOfDeleteProduct";
            buttonOfDeleteProduct.Size = new Size(498, 68);
            buttonOfDeleteProduct.TabIndex = 4;
            buttonOfDeleteProduct.Text = "Удалить товар";
            buttonOfDeleteProduct.UseVisualStyleBackColor = true;
            buttonOfDeleteProduct.Click += buttonOfDeleteProduct_Click;
            // 
            // buttonOfEditProduct
            // 
            buttonOfEditProduct.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfEditProduct.Location = new Point(37, 36);
            buttonOfEditProduct.Name = "buttonOfEditProduct";
            buttonOfEditProduct.Size = new Size(498, 68);
            buttonOfEditProduct.TabIndex = 3;
            buttonOfEditProduct.Text = "Редактировать товар";
            buttonOfEditProduct.UseVisualStyleBackColor = true;
            buttonOfEditProduct.Click += buttonOfEditProduct_Click;
            // 
            // ProductManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 354);
            Controls.Add(buttonOfCancel);
            Controls.Add(buttonOfDeleteProduct);
            Controls.Add(buttonOfEditProduct);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ProductManagement";
            Text = "Менеджер товара";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonOfCancel;
        private Button buttonOfDeleteProduct;
        private Button buttonOfEditProduct;
    }
}