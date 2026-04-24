namespace AddCategoryForm
{
    partial class AddCategory
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
            LabelOfAddCategory = new Label();
            TextBoxForName = new TextBox();
            LabelOfNameCategory = new Label();
            LabelOfUnit = new Label();
            ButtonOfCancel = new Button();
            ButtonOfAddCategory = new Button();
            ComboBoxOfUnit = new ComboBox();
            SuspendLayout();
            // 
            // LabelOfAddCategory
            // 
            LabelOfAddCategory.AutoSize = true;
            LabelOfAddCategory.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfAddCategory.Location = new Point(222, 54);
            LabelOfAddCategory.Name = "LabelOfAddCategory";
            LabelOfAddCategory.Size = new Size(472, 54);
            LabelOfAddCategory.TabIndex = 0;
            LabelOfAddCategory.Text = "Добавление категории";
            // 
            // TextBoxForName
            // 
            TextBoxForName.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxForName.Location = new Point(129, 202);
            TextBoxForName.Name = "TextBoxForName";
            TextBoxForName.Size = new Size(641, 50);
            TextBoxForName.TabIndex = 1;
            // 
            // LabelOfNameCategory
            // 
            LabelOfNameCategory.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfNameCategory.Location = new Point(126, 149);
            LabelOfNameCategory.Name = "LabelOfNameCategory";
            LabelOfNameCategory.Size = new Size(340, 50);
            LabelOfNameCategory.TabIndex = 2;
            LabelOfNameCategory.Text = "Название категории";
            // 
            // LabelOfUnit
            // 
            LabelOfUnit.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfUnit.Location = new Point(129, 278);
            LabelOfUnit.Name = "LabelOfUnit";
            LabelOfUnit.Size = new Size(339, 53);
            LabelOfUnit.TabIndex = 3;
            LabelOfUnit.Text = "Единица измерения";
            // 
            // ButtonOfCancel
            // 
            ButtonOfCancel.FlatAppearance.BorderColor = Color.Black;
            ButtonOfCancel.FlatAppearance.BorderSize = 4;
            ButtonOfCancel.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfCancel.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfCancel.FlatStyle = FlatStyle.Flat;
            ButtonOfCancel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfCancel.Location = new Point(454, 430);
            ButtonOfCancel.Name = "ButtonOfCancel";
            ButtonOfCancel.Size = new Size(316, 69);
            ButtonOfCancel.TabIndex = 11;
            ButtonOfCancel.Text = "Отменить";
            ButtonOfCancel.UseVisualStyleBackColor = true;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
            // 
            // ButtonOfAddCategory
            // 
            ButtonOfAddCategory.Enabled = false;
            ButtonOfAddCategory.FlatAppearance.BorderColor = Color.Black;
            ButtonOfAddCategory.FlatAppearance.BorderSize = 4;
            ButtonOfAddCategory.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfAddCategory.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfAddCategory.FlatStyle = FlatStyle.Flat;
            ButtonOfAddCategory.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfAddCategory.Location = new Point(129, 430);
            ButtonOfAddCategory.Name = "ButtonOfAddCategory";
            ButtonOfAddCategory.Size = new Size(298, 69);
            ButtonOfAddCategory.TabIndex = 12;
            ButtonOfAddCategory.Text = "Добавить";
            ButtonOfAddCategory.UseVisualStyleBackColor = true;
            ButtonOfAddCategory.Click += ButtonOfAddCategory_Click;
            // 
            // ComboBoxOfUnit
            // 
            ComboBoxOfUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOfUnit.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ComboBoxOfUnit.FormattingEnabled = true;
            ComboBoxOfUnit.Location = new Point(129, 334);
            ComboBoxOfUnit.Name = "ComboBoxOfUnit";
            ComboBoxOfUnit.Size = new Size(641, 53);
            ComboBoxOfUnit.TabIndex = 13;
            // 
            // AddCategory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(895, 609);
            Controls.Add(ComboBoxOfUnit);
            Controls.Add(ButtonOfAddCategory);
            Controls.Add(ButtonOfCancel);
            Controls.Add(LabelOfUnit);
            Controls.Add(LabelOfNameCategory);
            Controls.Add(TextBoxForName);
            Controls.Add(LabelOfAddCategory);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление категории";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelOfAddCategory;
        private TextBox TextBoxForName;
        private Label LabelOfNameCategory;
        private Label LabelOfUnit;
        private Button ButtonOfCancel;
        private Button ButtonOfAddCategory;
        private ComboBox ComboBoxOfUnit;
    }
}