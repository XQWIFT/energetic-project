namespace EnergeticProjectX.Forms
{
    partial class EditCategories
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
            ButtonOfCancel = new Button();
            ButtonOfDeleteCategory = new Button();
            ButtonOfSaveChanges = new Button();
            LabelOfEditCategory = new Label();
            LabelOfCategory = new Label();
            ComboBoxOfCategory = new ComboBox();
            LabelOfUnitData = new Label();
            TextBoxForCurrentUnit = new TextBox();
            LabelOfNewUnitData = new Label();
            ComboBoxOfNewUnitData = new ComboBox();
            SuspendLayout();
            // 
            // ButtonOfCancel
            // 
            ButtonOfCancel.FlatAppearance.BorderColor = Color.Black;
            ButtonOfCancel.FlatAppearance.BorderSize = 4;
            ButtonOfCancel.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfCancel.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfCancel.FlatStyle = FlatStyle.Flat;
            ButtonOfCancel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfCancel.Location = new Point(336, 590);
            ButtonOfCancel.Name = "ButtonOfCancel";
            ButtonOfCancel.Size = new Size(317, 71);
            ButtonOfCancel.TabIndex = 6;
            ButtonOfCancel.Text = "Отменить";
            ButtonOfCancel.UseVisualStyleBackColor = true;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
            ButtonOfCancel.Enter += TabSelection_Enter;
            ButtonOfCancel.Leave += TabSelection_Leave;
            // 
            // ButtonOfDeleteCategory
            // 
            ButtonOfDeleteCategory.Enabled = false;
            ButtonOfDeleteCategory.FlatAppearance.BorderColor = Color.Black;
            ButtonOfDeleteCategory.FlatAppearance.BorderSize = 4;
            ButtonOfDeleteCategory.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfDeleteCategory.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfDeleteCategory.FlatStyle = FlatStyle.Flat;
            ButtonOfDeleteCategory.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfDeleteCategory.Location = new Point(513, 506);
            ButtonOfDeleteCategory.Name = "ButtonOfDeleteCategory";
            ButtonOfDeleteCategory.Size = new Size(318, 64);
            ButtonOfDeleteCategory.TabIndex = 5;
            ButtonOfDeleteCategory.Text = "Удалить";
            ButtonOfDeleteCategory.UseVisualStyleBackColor = true;
            ButtonOfDeleteCategory.Click += ButtonOfDelete_Click;
            ButtonOfDeleteCategory.Enter += TabSelection_Enter;
            ButtonOfDeleteCategory.Leave += TabSelection_Leave;
            // 
            // ButtonOfSaveChanges
            // 
            ButtonOfSaveChanges.Enabled = false;
            ButtonOfSaveChanges.FlatAppearance.BorderColor = Color.Black;
            ButtonOfSaveChanges.FlatAppearance.BorderSize = 4;
            ButtonOfSaveChanges.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfSaveChanges.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfSaveChanges.FlatStyle = FlatStyle.Flat;
            ButtonOfSaveChanges.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfSaveChanges.Location = new Point(175, 506);
            ButtonOfSaveChanges.Name = "ButtonOfSaveChanges";
            ButtonOfSaveChanges.Size = new Size(310, 64);
            ButtonOfSaveChanges.TabIndex = 4;
            ButtonOfSaveChanges.Text = "Изменить";
            ButtonOfSaveChanges.UseVisualStyleBackColor = true;
            ButtonOfSaveChanges.Click += ButtonOfSaveChanges_Click;
            ButtonOfSaveChanges.Enter += TabSelection_Enter;
            ButtonOfSaveChanges.Leave += TabSelection_Leave;
            // 
            // LabelOfEditCategory
            // 
            LabelOfEditCategory.AutoSize = true;
            LabelOfEditCategory.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfEditCategory.Location = new Point(258, 80);
            LabelOfEditCategory.Name = "LabelOfEditCategory";
            LabelOfEditCategory.Size = new Size(495, 48);
            LabelOfEditCategory.TabIndex = 0;
            LabelOfEditCategory.Text = "Редактирование категории";
            // 
            // LabelOfCategory
            // 
            LabelOfCategory.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfCategory.Location = new Point(166, 148);
            LabelOfCategory.Name = "LabelOfCategory";
            LabelOfCategory.Size = new Size(356, 46);
            LabelOfCategory.TabIndex = 0;
            LabelOfCategory.Text = "Название категории";
            // 
            // ComboBoxOfCategory
            // 
            ComboBoxOfCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOfCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ComboBoxOfCategory.FormattingEnabled = true;
            ComboBoxOfCategory.Location = new Point(175, 197);
            ComboBoxOfCategory.Name = "ComboBoxOfCategory";
            ComboBoxOfCategory.Size = new Size(656, 46);
            ComboBoxOfCategory.TabIndex = 1;
            ComboBoxOfCategory.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // LabelOfUnitData
            // 
            LabelOfUnitData.AutoSize = true;
            LabelOfUnitData.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfUnitData.Location = new Point(166, 260);
            LabelOfUnitData.Name = "LabelOfUnitData";
            LabelOfUnitData.Size = new Size(477, 45);
            LabelOfUnitData.TabIndex = 0;
            LabelOfUnitData.Text = "Текущая единица измерения";
            // 
            // TextBoxForCurrentUnit
            // 
            TextBoxForCurrentUnit.BackColor = Color.White;
            TextBoxForCurrentUnit.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxForCurrentUnit.Location = new Point(175, 308);
            TextBoxForCurrentUnit.Multiline = true;
            TextBoxForCurrentUnit.Name = "TextBoxForCurrentUnit";
            TextBoxForCurrentUnit.ReadOnly = true;
            TextBoxForCurrentUnit.Size = new Size(656, 46);
            TextBoxForCurrentUnit.TabIndex = 2;
            // 
            // LabelOfNewUnitData
            // 
            LabelOfNewUnitData.AutoSize = true;
            LabelOfNewUnitData.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfNewUnitData.Location = new Point(175, 378);
            LabelOfNewUnitData.Name = "LabelOfNewUnitData";
            LabelOfNewUnitData.Size = new Size(444, 45);
            LabelOfNewUnitData.TabIndex = 0;
            LabelOfNewUnitData.Text = "Новая единица измерения";
            // 
            // ComboBoxOfNewUnitData
            // 
            ComboBoxOfNewUnitData.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOfNewUnitData.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ComboBoxOfNewUnitData.FormattingEnabled = true;
            ComboBoxOfNewUnitData.Location = new Point(175, 426);
            ComboBoxOfNewUnitData.Name = "ComboBoxOfNewUnitData";
            ComboBoxOfNewUnitData.Size = new Size(656, 46);
            ComboBoxOfNewUnitData.TabIndex = 3;
            ComboBoxOfNewUnitData.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // EditCategories
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(981, 707);
            Controls.Add(ComboBoxOfNewUnitData);
            Controls.Add(LabelOfNewUnitData);
            Controls.Add(TextBoxForCurrentUnit);
            Controls.Add(LabelOfUnitData);
            Controls.Add(ComboBoxOfCategory);
            Controls.Add(LabelOfCategory);
            Controls.Add(LabelOfEditCategory);
            Controls.Add(ButtonOfCancel);
            Controls.Add(ButtonOfDeleteCategory);
            Controls.Add(ButtonOfSaveChanges);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditCategories";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Работа с существующими категориями";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonOfDeleteCategory;
        private Button ButtonOfCancel;
        private Button ButtonOfSaveChanges;
        private Label LabelOfEditCategory;
        private Label LabelOfCategory;
        private ComboBox ComboBoxOfCategory;
        private Label LabelOfUnitData;
        private TextBox TextBoxForCurrentUnit;
        private Label LabelOfNewUnitData;
        private ComboBox ComboBoxOfNewUnitData;
    }
}