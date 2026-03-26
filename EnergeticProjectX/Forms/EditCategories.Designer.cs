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
            buttonOfReturn = new Button();
            buttonOfDelete = new Button();
            buttonOfSaveChanges = new Button();
            labelOdEdit = new Label();
            labelOfCategory = new Label();
            comboBoxOfCategory = new ComboBox();
            SuspendLayout();
            // 
            // buttonOfReturn
            // 
            buttonOfReturn.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfReturn.Location = new Point(542, 611);
            buttonOfReturn.Name = "buttonOfReturn";
            buttonOfReturn.Size = new Size(231, 53);
            buttonOfReturn.TabIndex = 6;
            buttonOfReturn.Text = "Вернуться";
            buttonOfReturn.UseVisualStyleBackColor = true;
            buttonOfReturn.Click += buttonOfReturn_Click;
            // 
            // buttonOfDelete
            // 
            buttonOfDelete.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfDelete.Location = new Point(282, 611);
            buttonOfDelete.Name = "buttonOfDelete";
            buttonOfDelete.Size = new Size(231, 53);
            buttonOfDelete.TabIndex = 5;
            buttonOfDelete.Text = "Удалить";
            buttonOfDelete.UseVisualStyleBackColor = true;
            buttonOfDelete.Click += buttonOfDelete_Click;
            // 
            // buttonOfSaveChanges
            // 
            buttonOfSaveChanges.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfSaveChanges.Location = new Point(21, 611);
            buttonOfSaveChanges.Name = "buttonOfSaveChanges";
            buttonOfSaveChanges.Size = new Size(231, 53);
            buttonOfSaveChanges.TabIndex = 4;
            buttonOfSaveChanges.Text = "Изменить";
            buttonOfSaveChanges.UseVisualStyleBackColor = true;
            buttonOfSaveChanges.Click += buttonOfSaveChanges_Click;
            // 
            // labelOdEdit
            // 
            labelOdEdit.Font = new Font("Segoe UI", 28F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOdEdit.Location = new Point(30, 9);
            labelOdEdit.Name = "labelOdEdit";
            labelOdEdit.Size = new Size(743, 106);
            labelOdEdit.TabIndex = 7;
            labelOdEdit.Text = "Редактирование категории";
            // 
            // labelOfCategory
            // 
            labelOfCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfCategory.Location = new Point(12, 224);
            labelOfCategory.Name = "labelOfCategory";
            labelOfCategory.Size = new Size(159, 46);
            labelOfCategory.TabIndex = 8;
            labelOfCategory.Text = "Категория";
            // 
            // comboBoxOfCategory
            // 
            comboBoxOfCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOfCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxOfCategory.FormattingEnabled = true;
            comboBoxOfCategory.Location = new Point(166, 224);
            comboBoxOfCategory.Name = "comboBoxOfCategory";
            comboBoxOfCategory.Size = new Size(622, 46);
            comboBoxOfCategory.TabIndex = 9;
            this.comboBoxOfCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxOfCategory_SelectedIndexChanged);
            // 
            // EditCategories
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 676);
            Controls.Add(comboBoxOfCategory);
            Controls.Add(labelOfCategory);
            Controls.Add(labelOdEdit);
            Controls.Add(buttonOfReturn);
            Controls.Add(buttonOfDelete);
            Controls.Add(buttonOfSaveChanges);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditCategories";
            Text = "Корректировка категорий";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonOfDelete;
        private Button buttonOfReturn;
        private Button buttonOfSaveChanges;
        private Label labelOdEdit;
        private Label labelOfCategory;
        private ComboBox comboBoxOfCategory;
    }
}