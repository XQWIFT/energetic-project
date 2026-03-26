namespace ClientManagementForm
{
    partial class СlientManagement
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
            buttonOfEditClient = new Button();
            buttonOfDeleteClient = new Button();
            buttonOfCancel = new Button();
            SuspendLayout();
            // 
            // buttonOfEditClient
            // 
            buttonOfEditClient.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfEditClient.Location = new Point(38, 40);
            buttonOfEditClient.Name = "buttonOfEditClient";
            buttonOfEditClient.Size = new Size(498, 68);
            buttonOfEditClient.TabIndex = 0;
            buttonOfEditClient.Text = "Редактировать данные";
            buttonOfEditClient.UseVisualStyleBackColor = true;
            buttonOfEditClient.Click += buttonOfEditClient_Click;
            // 
            // buttonOfDeleteClient
            // 
            buttonOfDeleteClient.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfDeleteClient.Location = new Point(38, 135);
            buttonOfDeleteClient.Name = "buttonOfDeleteClient";
            buttonOfDeleteClient.Size = new Size(498, 68);
            buttonOfDeleteClient.TabIndex = 1;
            buttonOfDeleteClient.Text = "Удалить клиента";
            buttonOfDeleteClient.UseVisualStyleBackColor = true;
            buttonOfDeleteClient.Click += buttonOfDeleteClient_Click;
            // 
            // buttonOfCancel
            // 
            buttonOfCancel.BackColor = Color.Coral;
            buttonOfCancel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfCancel.ForeColor = Color.Black;
            buttonOfCancel.Location = new Point(156, 255);
            buttonOfCancel.Name = "buttonOfCancel";
            buttonOfCancel.Size = new Size(237, 68);
            buttonOfCancel.TabIndex = 2;
            buttonOfCancel.Text = "Отменить";
            buttonOfCancel.UseVisualStyleBackColor = false;
            buttonOfCancel.Click += buttonOfCancel_Click;
            // 
            // СlientManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 355);
            Controls.Add(buttonOfCancel);
            Controls.Add(buttonOfDeleteClient);
            Controls.Add(buttonOfEditClient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "СlientManagement";
            Text = "Менеджер клиента";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonOfEditClient;
        private Button buttonOfDeleteClient;
        private Button buttonOfCancel;
    }
}