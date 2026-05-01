namespace EnergeticProjectX.Forms
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
            DGVOfClients = new DataGridView();
            ButtonOfMainMenu = new Button();
            ButtonOfAddClient = new Button();
            ButtonOfClient = new Button();
            toolTip1 = new ToolTip(components);
            clientDisplayModelBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)DGVOfClients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clientDisplayModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // DGVOfClients
            // 
            DGVOfClients.AllowUserToAddRows = false;
            DGVOfClients.AllowUserToDeleteRows = false;
            DGVOfClients.AllowUserToResizeColumns = false;
            DGVOfClients.AllowUserToResizeRows = false;
            DGVOfClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVOfClients.BackgroundColor = SystemColors.ControlLight;
            DGVOfClients.BorderStyle = BorderStyle.Fixed3D;
            DGVOfClients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGVOfClients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGVOfClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVOfClients.EnableHeadersVisualStyles = false;
            DGVOfClients.GridColor = SystemColors.WindowText;
            DGVOfClients.Location = new Point(12, 17);
            DGVOfClients.MultiSelect = false;
            DGVOfClients.Name = "DGVOfClients";
            DGVOfClients.ReadOnly = true;
            DGVOfClients.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DGVOfClients.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DGVOfClients.RowHeadersVisible = false;
            DGVOfClients.RowHeadersWidth = 62;
            DGVOfClients.Size = new Size(952, 512);
            DGVOfClients.TabIndex = 0;
            DGVOfClients.CellMouseClick += DGVOfClients_CellMouseClick;
            DGVOfClients.CellMouseDoubleClick += DGVOfClients_CellMouseClick;
            DGVOfClients.CellMouseEnter += DGVOfClients_CellMouseEnter;
            DGVOfClients.SelectionChanged += DGVOfClients_SelectionChanged;
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
            ButtonOfMainMenu.Enter += TabSelection_Enter;
            ButtonOfMainMenu.Leave += TabSelection_Leave;
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
            ButtonOfAddClient.Enter += TabSelection_Enter;
            ButtonOfAddClient.Leave += TabSelection_Leave;
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
            ButtonOfClient.Enter += TabSelection_Enter;
            ButtonOfClient.Leave += TabSelection_Leave;
            // 
            // clientDisplayModelBindingSource
            // 
            clientDisplayModelBindingSource.DataSource = typeof(Models.ClientDisplayModel);
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
            Controls.Add(DGVOfClients);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ListOfClients";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список клиентов";
            ((System.ComponentModel.ISupportInitialize)DGVOfClients).EndInit();
            ((System.ComponentModel.ISupportInitialize)clientDisplayModelBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVOfClients;
        private Button ButtonOfMainMenu;
        private Button ButtonOfAddClient;
        private Button ButtonOfClient;
        private ToolTip toolTip1;
        private BindingSource clientDisplayModelBindingSource;
    }
}