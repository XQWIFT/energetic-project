namespace EditCategoriesForm
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
            ButtonOfDelete = new Button();
            ButtonOfSaveChanges = new Button();
            labelOdEdit = new Label();
            LabelOfCategory = new Label();
            ComboBoxOfCategory = new ComboBox();
            LabelOfUnitData = new Label();
            textBoxForCurrentUnit = new TextBox();
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
            // 
            // ButtonOfDelete
            // 
            ButtonOfDelete.Enabled = false;
            ButtonOfDelete.FlatAppearance.BorderColor = Color.Black;
            ButtonOfDelete.FlatAppearance.BorderSize = 4;
            ButtonOfDelete.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfDelete.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfDelete.FlatStyle = FlatStyle.Flat;
            ButtonOfDelete.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfDelete.Location = new Point(513, 506);
            ButtonOfDelete.Name = "ButtonOfDelete";
            ButtonOfDelete.Size = new Size(318, 64);
            ButtonOfDelete.TabIndex = 5;
            ButtonOfDelete.Text = "Удалить";
            ButtonOfDelete.UseVisualStyleBackColor = true;
            ButtonOfDelete.Click += ButtonOfDelete_Click;
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
            // 
            // labelOdEdit
            // 
            labelOdEdit.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOdEdit.Location = new Point(227, 68);
            labelOdEdit.Name = "labelOdEdit";
            labelOdEdit.Size = new Size(562, 61);
            labelOdEdit.TabIndex = 7;
            labelOdEdit.Text = "Редактирование категории";
            // 
            // LabelOfCategory
            // 
            LabelOfCategory.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfCategory.Location = new Point(166, 148);
            LabelOfCategory.Name = "LabelOfCategory";
            LabelOfCategory.Size = new Size(356, 46);
            LabelOfCategory.TabIndex = 8;
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
            ComboBoxOfCategory.TabIndex = 9;
            // 
            // LabelOfUnitData
            // 
            LabelOfUnitData.AutoSize = true;
            LabelOfUnitData.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfUnitData.Location = new Point(166, 260);
            LabelOfUnitData.Name = "LabelOfUnitData";
            LabelOfUnitData.Size = new Size(477, 45);
            LabelOfUnitData.TabIndex = 11;
            LabelOfUnitData.Text = "Текущая единица измерения";
            // 
            // textBoxForCurrentUnit
            // 
            textBoxForCurrentUnit.BackColor = Color.White;
            textBoxForCurrentUnit.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxForCurrentUnit.Location = new Point(175, 308);
            textBoxForCurrentUnit.Multiline = true;
            textBoxForCurrentUnit.Name = "textBoxForCurrentUnit";
            textBoxForCurrentUnit.ReadOnly = true;
            textBoxForCurrentUnit.Size = new Size(656, 46);
            textBoxForCurrentUnit.TabIndex = 12;
            // 
            // LabelOfNewUnitData
            // 
            LabelOfNewUnitData.AutoSize = true;
            LabelOfNewUnitData.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfNewUnitData.Location = new Point(175, 378);
            LabelOfNewUnitData.Name = "LabelOfNewUnitData";
            LabelOfNewUnitData.Size = new Size(444, 45);
            LabelOfNewUnitData.TabIndex = 13;
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
            ComboBoxOfNewUnitData.TabIndex = 14;
            // 
            // EditCategories
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(973, 688);
            Controls.Add(ComboBoxOfNewUnitData);
            Controls.Add(LabelOfNewUnitData);
            Controls.Add(textBoxForCurrentUnit);
            Controls.Add(LabelOfUnitData);
            Controls.Add(ComboBoxOfCategory);
            Controls.Add(LabelOfCategory);
            Controls.Add(labelOdEdit);
            Controls.Add(ButtonOfCancel);
            Controls.Add(ButtonOfDelete);
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

        private Button ButtonOfDelete;
        private Button ButtonOfCancel;
        private Button ButtonOfSaveChanges;
        private Label labelOdEdit;
        private Label LabelOfCategory;
        private ComboBox ComboBoxOfCategory;
        private Label LabelOfUnitData;
        private TextBox textBoxForCurrentUnit;
        private Label LabelOfNewUnitData;
        private ComboBox ComboBoxOfNewUnitData;
    }
}