namespace EnergeticProjectX.Forms
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DGVOfShipments = new DataGridView();
            ButtonOfMainMenu = new Button();
            ButtonOfContent = new Button();
            ButtonOfExport = new Button();
            PanelOfSearch = new Panel();
            DateTimePickerTo = new DateTimePicker();
            DateTimePickerFrom = new DateTimePicker();
            LabelOfRussianTill = new Label();
            LabelOfRussianC = new Label();
            LabelOfChoosingDates = new Label();
            ((System.ComponentModel.ISupportInitialize)DGVOfShipments).BeginInit();
            PanelOfSearch.SuspendLayout();
            SuspendLayout();
            // 
            // DGVOfShipments
            // 
            DGVOfShipments.AllowUserToAddRows = false;
            DGVOfShipments.AllowUserToDeleteRows = false;
            DGVOfShipments.AllowUserToResizeColumns = false;
            DGVOfShipments.AllowUserToResizeRows = false;
            DGVOfShipments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVOfShipments.BackgroundColor = SystemColors.ControlLight;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            DGVOfShipments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DGVOfShipments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.Window;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            DGVOfShipments.DefaultCellStyle = dataGridViewCellStyle5;
            DGVOfShipments.EnableHeadersVisualStyles = false;
            DGVOfShipments.Location = new Point(12, 79);
            DGVOfShipments.MultiSelect = false;
            DGVOfShipments.Name = "DGVOfShipments";
            DGVOfShipments.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            DGVOfShipments.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            DGVOfShipments.RowHeadersVisible = false;
            DGVOfShipments.RowHeadersWidth = 62;
            DGVOfShipments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVOfShipments.Size = new Size(995, 580);
            DGVOfShipments.TabIndex = 0;
            DGVOfShipments.CellMouseClick += DataGridViewOfShipments_CellMouseClick;
            DGVOfShipments.CellMouseDoubleClick += DataGridViewOfShipments_CellMouseClick;
            DGVOfShipments.CellMouseEnter += DataGridViewOfShipments_CellMouseEnter;
            // 
            // ButtonOfMainMenu
            // 
            ButtonOfMainMenu.FlatAppearance.BorderSize = 4;
            ButtonOfMainMenu.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfMainMenu.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfMainMenu.FlatStyle = FlatStyle.Flat;
            ButtonOfMainMenu.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfMainMenu.ForeColor = Color.Black;
            ButtonOfMainMenu.Location = new Point(38, 685);
            ButtonOfMainMenu.Name = "ButtonOfMainMenu";
            ButtonOfMainMenu.Size = new Size(296, 80);
            ButtonOfMainMenu.TabIndex = 3;
            ButtonOfMainMenu.Text = "Главное меню";
            ButtonOfMainMenu.UseVisualStyleBackColor = true;
            ButtonOfMainMenu.Click += ButtonOfMainMenu_Click;
            ButtonOfMainMenu.Enter += TabSelection_Enter;
            ButtonOfMainMenu.Leave += TabSelection_Leave;
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
            ButtonOfContent.Size = new Size(289, 80);
            ButtonOfContent.TabIndex = 5;
            ButtonOfContent.Text = "Подробности";
            ButtonOfContent.UseVisualStyleBackColor = true;
            ButtonOfContent.Click += ButtonOfContent_Click;
            ButtonOfContent.Enter += TabSelection_Enter;
            ButtonOfContent.Leave += TabSelection_Leave;
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
            ButtonOfExport.Location = new Point(352, 685);
            ButtonOfExport.Name = "ButtonOfExport";
            ButtonOfExport.Size = new Size(324, 80);
            ButtonOfExport.TabIndex = 4;
            ButtonOfExport.Text = "Экспорт отчёта";
            ButtonOfExport.UseVisualStyleBackColor = true;
            ButtonOfExport.Click += ButtonOfExport_Click;
            ButtonOfExport.Enter += TabSelection_Enter;
            ButtonOfExport.Leave += TabSelection_Leave;
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
            DateTimePickerTo.CustomFormat = "dd.MM.yyyy";
            DateTimePickerTo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DateTimePickerTo.Format = DateTimePickerFormat.Custom;
            DateTimePickerTo.Location = new Point(673, 18);
            DateTimePickerTo.MaxDate = new DateTime(2100, 1, 1, 0, 0, 0, 0);
            DateTimePickerTo.MinDate = new DateTime(2010, 1, 1, 0, 0, 0, 0);
            DateTimePickerTo.Name = "DateTimePickerTo";
            DateTimePickerTo.Size = new Size(300, 39);
            DateTimePickerTo.TabIndex = 2;
            DateTimePickerTo.ValueChanged += DateTimePickerTo_ValueChanged;
            // 
            // DateTimePickerFrom
            // 
            DateTimePickerFrom.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DateTimePickerFrom.CustomFormat = "dd.MM.yyyy";
            DateTimePickerFrom.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            DateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            DateTimePickerFrom.Location = new Point(343, 18);
            DateTimePickerFrom.MaxDate = new DateTime(2100, 1, 1, 0, 0, 0, 0);
            DateTimePickerFrom.MinDate = new DateTime(2020, 1, 1, 0, 0, 0, 0);
            DateTimePickerFrom.Name = "DateTimePickerFrom";
            DateTimePickerFrom.Size = new Size(244, 39);
            DateTimePickerFrom.TabIndex = 1;
            DateTimePickerFrom.Value = new DateTime(2026, 5, 1, 1, 19, 14, 0);
            DateTimePickerFrom.ValueChanged += DateTimePickerFrom_ValueChanged;
            // 
            // LabelOfRussianTill
            // 
            LabelOfRussianTill.AutoSize = true;
            LabelOfRussianTill.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfRussianTill.Location = new Point(602, 13);
            LabelOfRussianTill.Name = "LabelOfRussianTill";
            LabelOfRussianTill.Size = new Size(65, 45);
            LabelOfRussianTill.TabIndex = 0;
            LabelOfRussianTill.Text = "До";
            // 
            // LabelOfRussianC
            // 
            LabelOfRussianC.AutoSize = true;
            LabelOfRussianC.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfRussianC.Location = new Point(297, 13);
            LabelOfRussianC.Name = "LabelOfRussianC";
            LabelOfRussianC.Size = new Size(40, 45);
            LabelOfRussianC.TabIndex = 0;
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
            Controls.Add(DGVOfShipments);
            Controls.Add(ButtonOfMainMenu);
            Controls.Add(ButtonOfContent);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ShipmentJournal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Журнал отгрузок";
            ((System.ComponentModel.ISupportInitialize)DGVOfShipments).EndInit();
            PanelOfSearch.ResumeLayout(false);
            PanelOfSearch.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridView DGVOfShipments;
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