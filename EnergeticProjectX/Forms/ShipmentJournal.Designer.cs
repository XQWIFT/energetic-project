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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewOfShipments = new DataGridView();
            ButtonOfMainMenu = new Button();
            ButtonOfContent = new Button();
            ButtonOfExport = new Button();
            PanelOfSearch = new Panel();
            DateTimePickerTo = new DateTimePicker();
            DateTimePickerFrom = new DateTimePicker();
            LabelOfRussianTill = new Label();
            LabelOfRussianC = new Label();
            LabelOfChoosingDates = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridViewOfShipments).BeginInit();
            PanelOfSearch.SuspendLayout();
            SuspendLayout();
            // 
            // DataGridViewOfShipments
            // 
            DataGridViewOfShipments.AllowUserToAddRows = false;
            DataGridViewOfShipments.AllowUserToDeleteRows = false;
            DataGridViewOfShipments.AllowUserToResizeColumns = false;
            DataGridViewOfShipments.AllowUserToResizeRows = false;
            DataGridViewOfShipments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewOfShipments.BackgroundColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DataGridViewOfShipments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DataGridViewOfShipments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Window;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DataGridViewOfShipments.DefaultCellStyle = dataGridViewCellStyle2;
            DataGridViewOfShipments.EnableHeadersVisualStyles = false;
            DataGridViewOfShipments.Location = new Point(12, 79);
            DataGridViewOfShipments.MultiSelect = false;
            DataGridViewOfShipments.Name = "DataGridViewOfShipments";
            DataGridViewOfShipments.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DataGridViewOfShipments.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DataGridViewOfShipments.RowHeadersVisible = false;
            DataGridViewOfShipments.RowHeadersWidth = 62;
            DataGridViewOfShipments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewOfShipments.Size = new Size(995, 580);
            DataGridViewOfShipments.TabIndex = 0;
            // 
            // ButtonOfMainMenu
            // 
            ButtonOfMainMenu.FlatAppearance.BorderSize = 4;
            ButtonOfMainMenu.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfMainMenu.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfMainMenu.FlatStyle = FlatStyle.Flat;
            ButtonOfMainMenu.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfMainMenu.ForeColor = Color.Black;
            ButtonOfMainMenu.Location = new Point(50, 685);
            ButtonOfMainMenu.Name = "ButtonOfMainMenu";
            ButtonOfMainMenu.Size = new Size(296, 80);
            ButtonOfMainMenu.TabIndex = 3;
            ButtonOfMainMenu.Text = "Главное меню";
            ButtonOfMainMenu.UseVisualStyleBackColor = true;
            ButtonOfMainMenu.Click += ButtonOfMainMenu_Click;
            // 
            // ButtonOfContent
            // 
            ButtonOfContent.Enabled = false;
            ButtonOfContent.FlatAppearance.BorderSize = 4;
            ButtonOfContent.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfContent.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfContent.FlatStyle = FlatStyle.Flat;
            ButtonOfContent.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfContent.ForeColor = Color.Black;
            ButtonOfContent.Location = new Point(693, 685);
            ButtonOfContent.Name = "ButtonOfContent";
            ButtonOfContent.Size = new Size(278, 80);
            ButtonOfContent.TabIndex = 4;
            ButtonOfContent.Text = "Подробности";
            ButtonOfContent.UseVisualStyleBackColor = true;
            ButtonOfContent.Click += ButtonOfContent_Click;
            // 
            // ButtonOfExport
            // 
            ButtonOfExport.Enabled = false;
            ButtonOfExport.FlatAppearance.BorderSize = 4;
            ButtonOfExport.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfExport.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfExport.FlatStyle = FlatStyle.Flat;
            ButtonOfExport.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfExport.ForeColor = Color.Black;
            ButtonOfExport.Location = new Point(363, 685);
            ButtonOfExport.Name = "ButtonOfExport";
            ButtonOfExport.Size = new Size(313, 80);
            ButtonOfExport.TabIndex = 5;
            ButtonOfExport.Text = "Экспорт отчёта";
            ButtonOfExport.UseVisualStyleBackColor = true;
            ButtonOfExport.Click += ButtonOfExport_Click;
            // 
            // PanelOfSearch
            // 
            PanelOfSearch.Controls.Add(DateTimePickerTo);
            PanelOfSearch.Controls.Add(DateTimePickerFrom);
            PanelOfSearch.Controls.Add(LabelOfRussianTill);
            PanelOfSearch.Controls.Add(LabelOfRussianC);
            PanelOfSearch.Controls.Add(LabelOfChoosingDates);
            PanelOfSearch.Location = new Point(9, 6);
            PanelOfSearch.Name = "PanelOfSearch";
            PanelOfSearch.Size = new Size(998, 67);
            PanelOfSearch.TabIndex = 6;
            // 
            // DateTimePickerTo
            // 
            DateTimePickerTo.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DateTimePickerTo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DateTimePickerTo.Location = new Point(673, 18);
            DateTimePickerTo.Name = "DateTimePickerTo";
            DateTimePickerTo.Size = new Size(300, 39);
            DateTimePickerTo.TabIndex = 4;
            // 
            // DateTimePickerFrom
            // 
            DateTimePickerFrom.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DateTimePickerFrom.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DateTimePickerFrom.Location = new Point(343, 18);
            DateTimePickerFrom.Name = "DateTimePickerFrom";
            DateTimePickerFrom.Size = new Size(244, 39);
            DateTimePickerFrom.TabIndex = 3;
            // 
            // LabelOfRussianTill
            // 
            LabelOfRussianTill.AutoSize = true;
            LabelOfRussianTill.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfRussianTill.Location = new Point(602, 13);
            LabelOfRussianTill.Name = "LabelOfRussianTill";
            LabelOfRussianTill.Size = new Size(65, 45);
            LabelOfRussianTill.TabIndex = 2;
            LabelOfRussianTill.Text = "До";
            // 
            // LabelOfRussianC
            // 
            LabelOfRussianC.AutoSize = true;
            LabelOfRussianC.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfRussianC.Location = new Point(297, 13);
            LabelOfRussianC.Name = "LabelOfRussianC";
            LabelOfRussianC.Size = new Size(40, 45);
            LabelOfRussianC.TabIndex = 1;
            LabelOfRussianC.Text = "С";
            // 
            // LabelOfChoosingDates
            // 
            LabelOfChoosingDates.AutoSize = true;
            LabelOfChoosingDates.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfChoosingDates.Location = new Point(13, 13);
            LabelOfChoosingDates.Name = "LabelOfChoosingDates";
            LabelOfChoosingDates.Size = new Size(278, 45);
            LabelOfChoosingDates.TabIndex = 0;
            LabelOfChoosingDates.Text = "Выбор периода:";
            // 
            // ShipmentJournal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(1019, 794);
            Controls.Add(PanelOfSearch);
            Controls.Add(ButtonOfExport);
            Controls.Add(DataGridViewOfShipments);
            Controls.Add(ButtonOfMainMenu);
            Controls.Add(ButtonOfContent);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ShipmentJournal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Журнал отгрузок";
            ((System.ComponentModel.ISupportInitialize)DataGridViewOfShipments).EndInit();
            PanelOfSearch.ResumeLayout(false);
            PanelOfSearch.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridView DataGridViewOfShipments;
        private Button ButtonOfMainMenu;
        private Button ButtonOfContent;
        private Button ButtonOfExport;
        private Panel PanelOfSearch;
        private DateTimePicker DateTimePickerTo;
        private DateTimePicker DateTimePickerFrom;
        private Label LabelOfRussianTill;
        private Label LabelOfRussianC;
        private Label LabelOfChoosingDates;
    }

        #endregion
}