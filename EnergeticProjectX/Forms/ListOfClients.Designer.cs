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
            dataGridOfClients = new DataGridView();
            buttonOfMainMenu = new Button();
            buttonAddClient = new Button();
            buttonOfClient = new Button();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dataGridOfClients).BeginInit();
            SuspendLayout();
            // 
            // dataGridOfClients
            // 
            dataGridOfClients.AllowUserToAddRows = false;
            dataGridOfClients.AllowUserToDeleteRows = false;
            dataGridOfClients.AllowUserToResizeColumns = false;
            dataGridOfClients.AllowUserToResizeRows = false;
            dataGridOfClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOfClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridOfClients.Location = new Point(12, 17);
            dataGridOfClients.Name = "dataGridOfClients";
            dataGridOfClients.ReadOnly = true;
            dataGridOfClients.RowHeadersVisible = false;
            dataGridOfClients.RowHeadersWidth = 62;
            dataGridOfClients.Size = new Size(734, 477);
            dataGridOfClients.TabIndex = 0;
            dataGridOfClients.CellMouseClick += dataGridOfClients_CellMouseClick;
            dataGridOfClients.CellMouseEnter += dataGridOfClients_CellMouseEnter;
            // 
            // buttonOfMainMenu
            // 
            buttonOfMainMenu.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfMainMenu.Location = new Point(12, 516);
            buttonOfMainMenu.Name = "buttonOfMainMenu";
            buttonOfMainMenu.Size = new Size(231, 53);
            buttonOfMainMenu.TabIndex = 1;
            buttonOfMainMenu.Text = "Главное меню";
            buttonOfMainMenu.UseVisualStyleBackColor = true;
            buttonOfMainMenu.Click += buttonOfMainMenu_Click;
            // 
            // buttonAddClient
            // 
            buttonAddClient.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAddClient.Location = new Point(249, 516);
            buttonAddClient.Name = "buttonAddClient";
            buttonAddClient.Size = new Size(260, 53);
            buttonAddClient.TabIndex = 2;
            buttonAddClient.Text = "Добавить клиента";
            buttonAddClient.UseVisualStyleBackColor = true;
            buttonAddClient.Click += buttonAddClient_Click;
            // 
            // buttonOfClient
            // 
            buttonOfClient.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfClient.Location = new Point(515, 516);
            buttonOfClient.Name = "buttonOfClient";
            buttonOfClient.Size = new Size(231, 53);
            buttonOfClient.TabIndex = 3;
            buttonOfClient.Text = "Клиент";
            buttonOfClient.UseVisualStyleBackColor = true;
            buttonOfClient.Click += buttonOfClient_Click;
            // 
            // ListOfClients
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 589);
            Controls.Add(buttonOfClient);
            Controls.Add(buttonAddClient);
            Controls.Add(buttonOfMainMenu);
            Controls.Add(dataGridOfClients);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ListOfClients";
            Text = "Список клиентов";
            ((System.ComponentModel.ISupportInitialize)dataGridOfClients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridOfClients;
        private Button buttonOfMainMenu;
        private Button buttonAddClient;
        private Button buttonOfClient;
        private ToolTip toolTip1;
    }
}