namespace ShipmentJournalForm
{
    partial class ShipmentJournal
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
            dataGridOfShipments = new DataGridView();
            labelContent = new Label();
            dataGridOfContent = new DataGridView();
            buttonOfMainMenu = new Button();
            buttonOfContent = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridOfShipments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridOfContent).BeginInit();
            SuspendLayout();
            // 
            // dataGridOfShipments
            // 
            dataGridOfShipments.AllowUserToAddRows = false;
            dataGridOfShipments.AllowUserToDeleteRows = false;
            dataGridOfShipments.AllowUserToResizeColumns = false;
            dataGridOfShipments.AllowUserToResizeRows = false;
            dataGridOfShipments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOfShipments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridOfShipments.Location = new Point(12, 12);
            dataGridOfShipments.MultiSelect = false;
            dataGridOfShipments.Name = "dataGridOfShipments";
            dataGridOfShipments.ReadOnly = true;
            dataGridOfShipments.RowHeadersVisible = false;
            dataGridOfShipments.RowHeadersWidth = 62;
            dataGridOfShipments.Size = new Size(760, 286);
            dataGridOfShipments.TabIndex = 0;
            dataGridOfShipments.CellMouseClick += dataGridOfShipments_CellMouseClick;
            dataGridOfShipments.SelectionChanged += DataGridOfShipments_SelectionChanged;
            // 
            // labelContent
            // 
            labelContent.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelContent.Location = new Point(12, 315);
            labelContent.Name = "labelContent";
            labelContent.Size = new Size(332, 42);
            labelContent.TabIndex = 1;
            labelContent.Text = "Содержание отгрузки";
            // 
            // dataGridOfContent
            // 
            dataGridOfContent.AllowUserToAddRows = false;
            dataGridOfContent.AllowUserToDeleteRows = false;
            dataGridOfContent.AllowUserToResizeColumns = false;
            dataGridOfContent.AllowUserToResizeRows = false;
            dataGridOfContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOfContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridOfContent.Location = new Point(12, 373);
            dataGridOfContent.Name = "dataGridOfContent";
            dataGridOfContent.ReadOnly = true;
            dataGridOfContent.RowHeadersVisible = false;
            dataGridOfContent.RowHeadersWidth = 62;
            dataGridOfContent.Size = new Size(760, 187);
            dataGridOfContent.TabIndex = 2;
            // 
            // buttonOfMainMenu
            // 
            buttonOfMainMenu.Font = new Font("Segoe UI", 14F);
            buttonOfMainMenu.Location = new Point(12, 578);
            buttonOfMainMenu.Name = "buttonOfMainMenu";
            buttonOfMainMenu.Size = new Size(231, 53);
            buttonOfMainMenu.TabIndex = 3;
            buttonOfMainMenu.Text = "Главное меню";
            buttonOfMainMenu.UseVisualStyleBackColor = true;
            buttonOfMainMenu.Click += buttonOfMainMenu_Click;
            // 
            // buttonOfContent
            // 
            buttonOfContent.Enabled = false;
            buttonOfContent.Font = new Font("Segoe UI", 14F);
            buttonOfContent.Location = new Point(541, 578);
            buttonOfContent.Name = "buttonOfContent";
            buttonOfContent.Size = new Size(231, 53);
            buttonOfContent.TabIndex = 4;
            buttonOfContent.Text = "Содержание";
            buttonOfContent.UseVisualStyleBackColor = true;
            buttonOfContent.Click += buttonOfContent_Click;
            // 
            // ShipmentJournal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 651);
            Controls.Add(dataGridOfShipments);
            Controls.Add(labelContent);
            Controls.Add(dataGridOfContent);
            Controls.Add(buttonOfMainMenu);
            Controls.Add(buttonOfContent);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ShipmentJournal";
            Text = "Журнал отгрузок";
            ((System.ComponentModel.ISupportInitialize)dataGridOfShipments).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridOfContent).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dataGridOfShipments;
        private Label labelContent;
        private DataGridView dataGridOfContent;
        private Button buttonOfMainMenu;
        private Button buttonOfContent;
    }

        #endregion
}