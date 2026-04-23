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
            DataGridOfShipments = new DataGridView();
            LabelContent = new Label();
            DataGridOfContent = new DataGridView();
            ButtonOfMainMenu = new Button();
            ButtonOfContent = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGridOfShipments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGridOfContent).BeginInit();
            SuspendLayout();
            // 
            // DataGridOfShipments
            // 
            DataGridOfShipments.AllowUserToAddRows = false;
            DataGridOfShipments.AllowUserToDeleteRows = false;
            DataGridOfShipments.AllowUserToResizeColumns = false;
            DataGridOfShipments.AllowUserToResizeRows = false;
            DataGridOfShipments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridOfShipments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridOfShipments.EnableHeadersVisualStyles = false;
            DataGridOfShipments.Location = new Point(12, 12);
            DataGridOfShipments.MultiSelect = false;
            DataGridOfShipments.Name = "DataGridOfShipments";
            DataGridOfShipments.ReadOnly = true;
            DataGridOfShipments.RowHeadersVisible = false;
            DataGridOfShipments.RowHeadersWidth = 62;
            DataGridOfShipments.Size = new Size(760, 286);
            DataGridOfShipments.TabIndex = 0;
            DataGridOfShipments.CellMouseClick += DataGridOfShipments_CellMouseClick;
            DataGridOfShipments.SelectionChanged += DataGridOfShipments_SelectionChanged;
            // 
            // LabelContent
            // 
            LabelContent.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            LabelContent.Location = new Point(12, 315);
            LabelContent.Name = "LabelContent";
            LabelContent.Size = new Size(332, 42);
            LabelContent.TabIndex = 1;
            LabelContent.Text = "Содержание отгрузки";
            // 
            // DataGridOfContent
            // 
            DataGridOfContent.AllowUserToAddRows = false;
            DataGridOfContent.AllowUserToDeleteRows = false;
            DataGridOfContent.AllowUserToResizeColumns = false;
            DataGridOfContent.AllowUserToResizeRows = false;
            DataGridOfContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridOfContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridOfContent.Location = new Point(12, 373);
            DataGridOfContent.Name = "DataGridOfContent";
            DataGridOfContent.ReadOnly = true;
            DataGridOfContent.RowHeadersVisible = false;
            DataGridOfContent.RowHeadersWidth = 62;
            DataGridOfContent.Size = new Size(760, 187);
            DataGridOfContent.TabIndex = 2;
            // 
            // ButtonOfMainMenu
            // 
            ButtonOfMainMenu.Font = new Font("Segoe UI", 14F);
            ButtonOfMainMenu.Location = new Point(12, 578);
            ButtonOfMainMenu.Name = "ButtonOfMainMenu";
            ButtonOfMainMenu.Size = new Size(231, 53);
            ButtonOfMainMenu.TabIndex = 3;
            ButtonOfMainMenu.Text = "Главное меню";
            ButtonOfMainMenu.UseVisualStyleBackColor = true;
            ButtonOfMainMenu.Click += ButtonOfMainMenu_Click;
            // 
            // ButtonOfContent
            // 
            ButtonOfContent.Enabled = false;
            ButtonOfContent.Font = new Font("Segoe UI", 14F);
            ButtonOfContent.Location = new Point(541, 578);
            ButtonOfContent.Name = "ButtonOfContent";
            ButtonOfContent.Size = new Size(231, 53);
            ButtonOfContent.TabIndex = 4;
            ButtonOfContent.Text = "Содержание";
            ButtonOfContent.UseVisualStyleBackColor = true;
            ButtonOfContent.Click += ButtonOfContent_Click;
            // 
            // ShipmentJournal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 651);
            Controls.Add(DataGridOfShipments);
            Controls.Add(LabelContent);
            Controls.Add(DataGridOfContent);
            Controls.Add(ButtonOfMainMenu);
            Controls.Add(ButtonOfContent);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ShipmentJournal";
            Text = "Журнал отгрузок";
            ((System.ComponentModel.ISupportInitialize)DataGridOfShipments).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGridOfContent).EndInit();
            ResumeLayout(false);
        }

        private DataGridView DataGridOfShipments;
        private Label LabelContent;
        private DataGridView DataGridOfContent;
        private Button ButtonOfMainMenu;
        private Button ButtonOfContent;
    }

        #endregion
}