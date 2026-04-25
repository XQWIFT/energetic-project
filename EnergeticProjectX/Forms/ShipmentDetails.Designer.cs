namespace EnergeticProjectX.Forms
{
    partial class ShipmentDetails
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
            DataGridViewOfShipmentProducts = new DataGridView();
            LabelOfContent = new Label();
            LabelOfUserData = new Label();
            LabelOfClient = new Label();
            LabelOfRevenue = new Label();
            LabelOfProfit = new Label();
            LabelOfDate = new Label();
            TextBoxOfUserData = new TextBox();
            TextBoxOfClient = new TextBox();
            TextBoxOfRevenue = new TextBox();
            TextBoxOfProfit = new TextBox();
            TextBoxOfDate = new TextBox();
            ButtonOfGoingBack = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGridViewOfShipmentProducts).BeginInit();
            SuspendLayout();
            // 
            // DataGridViewOfShipmentProducts
            // 
            DataGridViewOfShipmentProducts.AllowUserToAddRows = false;
            DataGridViewOfShipmentProducts.AllowUserToDeleteRows = false;
            DataGridViewOfShipmentProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewOfShipmentProducts.BackgroundColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DataGridViewOfShipmentProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DataGridViewOfShipmentProducts.ColumnHeadersHeight = 34;
            DataGridViewOfShipmentProducts.EnableHeadersVisualStyles = false;
            DataGridViewOfShipmentProducts.Location = new Point(562, 12);
            DataGridViewOfShipmentProducts.MultiSelect = false;
            DataGridViewOfShipmentProducts.Name = "DataGridViewOfShipmentProducts";
            DataGridViewOfShipmentProducts.ReadOnly = true;
            DataGridViewOfShipmentProducts.RowHeadersVisible = false;
            DataGridViewOfShipmentProducts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            DataGridViewOfShipmentProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewOfShipmentProducts.Size = new Size(604, 809);
            DataGridViewOfShipmentProducts.TabIndex = 0;
            // 
            // LabelOfContent
            // 
            LabelOfContent.AutoSize = true;
            LabelOfContent.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfContent.Location = new Point(125, 87);
            LabelOfContent.Name = "LabelOfContent";
            LabelOfContent.Size = new Size(296, 60);
            LabelOfContent.TabIndex = 1;
            LabelOfContent.Text = "Содержание";
            // 
            // LabelOfUserData
            // 
            LabelOfUserData.AutoSize = true;
            LabelOfUserData.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfUserData.Location = new Point(26, 199);
            LabelOfUserData.Name = "LabelOfUserData";
            LabelOfUserData.Size = new Size(173, 45);
            LabelOfUserData.TabIndex = 2;
            LabelOfUserData.Text = "Оформил";
            // 
            // LabelOfClient
            // 
            LabelOfClient.AutoSize = true;
            LabelOfClient.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfClient.Location = new Point(26, 272);
            LabelOfClient.Name = "LabelOfClient";
            LabelOfClient.Size = new Size(205, 45);
            LabelOfClient.TabIndex = 3;
            LabelOfClient.Text = "Получатель";
            // 
            // LabelOfRevenue
            // 
            LabelOfRevenue.AutoSize = true;
            LabelOfRevenue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfRevenue.Location = new Point(26, 342);
            LabelOfRevenue.Name = "LabelOfRevenue";
            LabelOfRevenue.Size = new Size(158, 45);
            LabelOfRevenue.TabIndex = 4;
            LabelOfRevenue.Text = "Выручка";
            // 
            // LabelOfProfit
            // 
            LabelOfProfit.AutoSize = true;
            LabelOfProfit.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfProfit.Location = new Point(26, 418);
            LabelOfProfit.Name = "LabelOfProfit";
            LabelOfProfit.Size = new Size(166, 45);
            LabelOfProfit.TabIndex = 5;
            LabelOfProfit.Text = "Прибыль";
            // 
            // LabelOfDate
            // 
            LabelOfDate.AutoSize = true;
            LabelOfDate.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LabelOfDate.Location = new Point(26, 495);
            LabelOfDate.Name = "LabelOfDate";
            LabelOfDate.Size = new Size(94, 45);
            LabelOfDate.TabIndex = 6;
            LabelOfDate.Text = "Дата";
            // 
            // TextBoxOfUserData
            // 
            TextBoxOfUserData.BackColor = SystemColors.Window;
            TextBoxOfUserData.Font = new Font("Segoe UI", 16F);
            TextBoxOfUserData.Location = new Point(256, 199);
            TextBoxOfUserData.Name = "TextBoxOfUserData";
            TextBoxOfUserData.ReadOnly = true;
            TextBoxOfUserData.Size = new Size(283, 50);
            TextBoxOfUserData.TabIndex = 7;
            // 
            // TextBoxOfClient
            // 
            TextBoxOfClient.BackColor = SystemColors.Window;
            TextBoxOfClient.Font = new Font("Segoe UI", 16F);
            TextBoxOfClient.Location = new Point(256, 267);
            TextBoxOfClient.Name = "TextBoxOfClient";
            TextBoxOfClient.ReadOnly = true;
            TextBoxOfClient.Size = new Size(283, 50);
            TextBoxOfClient.TabIndex = 8;
            // 
            // TextBoxOfRevenue
            // 
            TextBoxOfRevenue.BackColor = SystemColors.Window;
            TextBoxOfRevenue.Font = new Font("Segoe UI", 16F);
            TextBoxOfRevenue.Location = new Point(256, 342);
            TextBoxOfRevenue.Name = "TextBoxOfRevenue";
            TextBoxOfRevenue.ReadOnly = true;
            TextBoxOfRevenue.Size = new Size(283, 50);
            TextBoxOfRevenue.TabIndex = 9;
            // 
            // TextBoxOfProfit
            // 
            TextBoxOfProfit.BackColor = SystemColors.Window;
            TextBoxOfProfit.Font = new Font("Segoe UI", 16F);
            TextBoxOfProfit.Location = new Point(256, 418);
            TextBoxOfProfit.Name = "TextBoxOfProfit";
            TextBoxOfProfit.ReadOnly = true;
            TextBoxOfProfit.Size = new Size(283, 50);
            TextBoxOfProfit.TabIndex = 10;
            // 
            // TextBoxOfDate
            // 
            TextBoxOfDate.BackColor = SystemColors.Window;
            TextBoxOfDate.Font = new Font("Segoe UI", 16F);
            TextBoxOfDate.Location = new Point(256, 495);
            TextBoxOfDate.Name = "TextBoxOfDate";
            TextBoxOfDate.ReadOnly = true;
            TextBoxOfDate.Size = new Size(283, 50);
            TextBoxOfDate.TabIndex = 11;
            // 
            // ButtonOfGoingBack
            // 
            ButtonOfGoingBack.FlatAppearance.BorderSize = 4;
            ButtonOfGoingBack.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfGoingBack.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfGoingBack.FlatStyle = FlatStyle.Flat;
            ButtonOfGoingBack.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfGoingBack.Location = new Point(112, 595);
            ButtonOfGoingBack.Name = "ButtonOfGoingBack";
            ButtonOfGoingBack.Size = new Size(309, 76);
            ButtonOfGoingBack.TabIndex = 12;
            ButtonOfGoingBack.Text = "Назад";
            ButtonOfGoingBack.UseVisualStyleBackColor = true;
            ButtonOfGoingBack.Click += ButtonOfGoingBack_Click;
            // 
            // ShipmentDetails
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(1178, 833);
            Controls.Add(ButtonOfGoingBack);
            Controls.Add(TextBoxOfDate);
            Controls.Add(TextBoxOfProfit);
            Controls.Add(TextBoxOfRevenue);
            Controls.Add(TextBoxOfClient);
            Controls.Add(TextBoxOfUserData);
            Controls.Add(LabelOfDate);
            Controls.Add(LabelOfProfit);
            Controls.Add(LabelOfRevenue);
            Controls.Add(LabelOfClient);
            Controls.Add(LabelOfUserData);
            Controls.Add(LabelOfContent);
            Controls.Add(DataGridViewOfShipmentProducts);
            Name = "ShipmentDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Подробности отгрузки";
            ((System.ComponentModel.ISupportInitialize)DataGridViewOfShipmentProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DataGridViewOfShipmentProducts;
        private Label LabelOfContent;
        private Label LabelOfUserData;
        private Label LabelOfClient;
        private Label LabelOfRevenue;
        private Label LabelOfProfit;
        private Label LabelOfDate;
        private TextBox TextBoxOfUserData;
        private TextBox TextBoxOfClient;
        private TextBox TextBoxOfRevenue;
        private TextBox TextBoxOfProfit;
        private TextBox TextBoxOfDate;
        private Button ButtonOfGoingBack;
    }
}