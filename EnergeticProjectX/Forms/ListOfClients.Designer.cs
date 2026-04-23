namespace ListOfClientsForm
{
    partial class ListOfClients
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridOfClients = new DataGridView();
            ButtonOfMainMenu = new Button();
            ButtonOfAddClient = new Button();
            ButtonOfClient = new Button();
            toolTip1 = new ToolTip(components);
            clientDisplayModelBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)DataGridOfClients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clientDisplayModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // DataGridOfClients
            // 
            DataGridOfClients.AllowUserToAddRows = false;
            DataGridOfClients.AllowUserToDeleteRows = false;
            DataGridOfClients.AllowUserToResizeColumns = false;
            DataGridOfClients.AllowUserToResizeRows = false;
            DataGridOfClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridOfClients.BackgroundColor = SystemColors.ControlLight;
            DataGridOfClients.BorderStyle = BorderStyle.Fixed3D;
            DataGridOfClients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.Padding = new Padding(0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DataGridOfClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DataGridOfClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridOfClients.EnableHeadersVisualStyles = false;
            DataGridOfClients.GridColor = SystemColors.WindowText;
            DataGridOfClients.Location = new Point(12, 17);
            DataGridOfClients.MultiSelect = false;
            DataGridOfClients.Name = "DataGridOfClients";
            DataGridOfClients.ReadOnly = true;
            DataGridOfClients.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DataGridOfClients.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataGridOfClients.RowHeadersVisible = false;
            DataGridOfClients.RowHeadersWidth = 62;
            DataGridOfClients.Size = new Size(952, 512);
            DataGridOfClients.TabIndex = 0;
            DataGridOfClients.CellMouseClick += DataGridOfClients_CellMouseClick;
            DataGridOfClients.CellMouseEnter += DataGridOfClients_CellMouseEnter;
            // 
            // ButtonOfMainMenu
            // 
            ButtonOfMainMenu.FlatAppearance.BorderColor = Color.Black;
            ButtonOfMainMenu.FlatAppearance.BorderSize = 4;
            ButtonOfMainMenu.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfMainMenu.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfMainMenu.FlatStyle = FlatStyle.Flat;
            ButtonOfMainMenu.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfMainMenu.Location = new Point(12, 553);
            ButtonOfMainMenu.Name = "ButtonOfMainMenu";
            ButtonOfMainMenu.Size = new Size(284, 65);
            ButtonOfMainMenu.TabIndex = 1;
            ButtonOfMainMenu.Text = "Главное меню";
            ButtonOfMainMenu.UseVisualStyleBackColor = true;
            ButtonOfMainMenu.Click += ButtonOfMainMenu_Click;
            // 
            // ButtonOfAddClient
            // 
            ButtonOfAddClient.FlatAppearance.BorderColor = Color.Black;
            ButtonOfAddClient.FlatAppearance.BorderSize = 4;
            ButtonOfAddClient.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfAddClient.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfAddClient.FlatStyle = FlatStyle.Flat;
            ButtonOfAddClient.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfAddClient.Location = new Point(302, 553);
            ButtonOfAddClient.Name = "ButtonOfAddClient";
            ButtonOfAddClient.Size = new Size(338, 65);
            ButtonOfAddClient.TabIndex = 2;
            ButtonOfAddClient.Text = "Добавить клиента";
            ButtonOfAddClient.UseVisualStyleBackColor = true;
            ButtonOfAddClient.Click += ButtonOfAddClient_Click;
            // 
            // ButtonOfClient
            // 
            ButtonOfClient.Enabled = false;
            ButtonOfClient.FlatAppearance.BorderColor = Color.Black;
            ButtonOfClient.FlatAppearance.BorderSize = 4;
            ButtonOfClient.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfClient.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfClient.FlatStyle = FlatStyle.Flat;
            ButtonOfClient.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfClient.Location = new Point(646, 553);
            ButtonOfClient.Name = "ButtonOfClient";
            ButtonOfClient.Size = new Size(318, 65);
            ButtonOfClient.TabIndex = 3;
            ButtonOfClient.Text = "Данные клиента";
            ButtonOfClient.UseVisualStyleBackColor = true;
            ButtonOfClient.Click += ButtonOfClient_Click;
            // 
            // clientDisplayModelBindingSource
            // 
            clientDisplayModelBindingSource.DataSource = typeof(EnergeticProjectX.Models.ClientDisplayModel);
            // 
            // ListOfClients
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(981, 630);
            Controls.Add(ButtonOfClient);
            Controls.Add(ButtonOfAddClient);
            Controls.Add(ButtonOfMainMenu);
            Controls.Add(DataGridOfClients);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ListOfClients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список клиентов";
            ((System.ComponentModel.ISupportInitialize)DataGridOfClients).EndInit();
            ((System.ComponentModel.ISupportInitialize)clientDisplayModelBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DataGridOfClients;
        private Button ButtonOfMainMenu;
        private Button ButtonOfAddClient;
        private Button ButtonOfClient;
        private ToolTip toolTip1;
        private BindingSource clientDisplayModelBindingSource;
    }
}