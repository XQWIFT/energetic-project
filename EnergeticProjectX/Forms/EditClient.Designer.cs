namespace EditClientForm
{
    partial class EditClient
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
            ComboBoxOfContractor = new ComboBox();
            ButtonOfCancel = new Button();
            ButtonOfSaveChanges = new Button();
            TextBoxOfContactInfo = new TextBox();
            TextBoxOfINN = new TextBox();
            LabelOfContactInfo = new Label();
            LabelOfINN = new Label();
            LabelOfContractor = new Label();
            TextBoxOfName = new TextBox();
            LabelOfName = new Label();
            LabelOfEditClient = new Label();
            ButtonOfDeleteClient = new Button();
            SuspendLayout();
            // 
            // ComboBoxOfContractor
            // 
            ComboBoxOfContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOfContractor.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ComboBoxOfContractor.FormattingEnabled = true;
            ComboBoxOfContractor.Items.AddRange(new object[] { "Физ. лицо", "Юр. лицо", "ИП" });
            ComboBoxOfContractor.Location = new Point(127, 267);
            ComboBoxOfContractor.Name = "ComboBoxOfContractor";
            ComboBoxOfContractor.Size = new Size(540, 46);
            ComboBoxOfContractor.TabIndex = 22;
            // 
            // ButtonOfCancel
            // 
            ButtonOfCancel.FlatAppearance.BorderColor = Color.Black;
            ButtonOfCancel.FlatAppearance.BorderSize = 4;
            ButtonOfCancel.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfCancel.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfCancel.FlatStyle = FlatStyle.Flat;
            ButtonOfCancel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfCancel.Location = new Point(401, 572);
            ButtonOfCancel.Name = "ButtonOfCancel";
            ButtonOfCancel.Size = new Size(266, 69);
            ButtonOfCancel.TabIndex = 21;
            ButtonOfCancel.Text = "Отменить";
            ButtonOfCancel.UseVisualStyleBackColor = true;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
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
            ButtonOfSaveChanges.Location = new Point(127, 572);
            ButtonOfSaveChanges.Name = "ButtonOfSaveChanges";
            ButtonOfSaveChanges.Size = new Size(259, 68);
            ButtonOfSaveChanges.TabIndex = 20;
            ButtonOfSaveChanges.Text = "Сохранить";
            ButtonOfSaveChanges.UseVisualStyleBackColor = true;
            ButtonOfSaveChanges.Click += ButtonOfSaveChanges_Click;
            // 
            // TextBoxOfContactInfo
            // 
            TextBoxOfContactInfo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfContactInfo.Location = new Point(127, 493);
            TextBoxOfContactInfo.Name = "TextBoxOfContactInfo";
            TextBoxOfContactInfo.Size = new Size(540, 45);
            TextBoxOfContactInfo.TabIndex = 19;
            // 
            // TextBoxOfINN
            // 
            TextBoxOfINN.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfINN.Location = new Point(127, 386);
            TextBoxOfINN.Name = "TextBoxOfINN";
            TextBoxOfINN.Size = new Size(540, 45);
            TextBoxOfINN.TabIndex = 18;
            // 
            // LabelOfContactInfo
            // 
            LabelOfContactInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfContactInfo.Location = new Point(127, 446);
            LabelOfContactInfo.Name = "LabelOfContactInfo";
            LabelOfContactInfo.Size = new Size(419, 54);
            LabelOfContactInfo.TabIndex = 17;
            LabelOfContactInfo.Text = "Контактная информация";
            // 
            // LabelOfINN
            // 
            LabelOfINN.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfINN.Location = new Point(121, 338);
            LabelOfINN.Name = "LabelOfINN";
            LabelOfINN.Size = new Size(477, 45);
            LabelOfINN.TabIndex = 16;
            LabelOfINN.Text = "Идентификационный номер";
            // 
            // LabelOfContractor
            // 
            LabelOfContractor.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfContractor.Location = new Point(121, 219);
            LabelOfContractor.Name = "LabelOfContractor";
            LabelOfContractor.Size = new Size(207, 45);
            LabelOfContractor.TabIndex = 15;
            LabelOfContractor.Text = "Контрагент";
            // 
            // TextBoxOfName
            // 
            TextBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfName.Location = new Point(127, 158);
            TextBoxOfName.Name = "TextBoxOfName";
            TextBoxOfName.Size = new Size(540, 45);
            TextBoxOfName.TabIndex = 14;
            // 
            // LabelOfName
            // 
            LabelOfName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfName.Location = new Point(121, 110);
            LabelOfName.Name = "LabelOfName";
            LabelOfName.Size = new Size(265, 45);
            LabelOfName.TabIndex = 13;
            LabelOfName.Text = "Наименование";
            // 
            // LabelOfEditClient
            // 
            LabelOfEditClient.AutoSize = true;
            LabelOfEditClient.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfEditClient.Location = new Point(141, 36);
            LabelOfEditClient.Name = "LabelOfEditClient";
            LabelOfEditClient.Size = new Size(515, 54);
            LabelOfEditClient.TabIndex = 12;
            LabelOfEditClient.Text = "Редактирование клиента";
            // 
            // ButtonOfDeleteClient
            // 
            ButtonOfDeleteClient.FlatAppearance.BorderColor = Color.Black;
            ButtonOfDeleteClient.FlatAppearance.BorderSize = 4;
            ButtonOfDeleteClient.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfDeleteClient.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfDeleteClient.FlatStyle = FlatStyle.Flat;
            ButtonOfDeleteClient.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ButtonOfDeleteClient.Location = new Point(201, 657);
            ButtonOfDeleteClient.Name = "ButtonOfDeleteClient";
            ButtonOfDeleteClient.Size = new Size(377, 68);
            ButtonOfDeleteClient.TabIndex = 23;
            ButtonOfDeleteClient.Text = "Удалить клиента";
            ButtonOfDeleteClient.UseVisualStyleBackColor = true;
            ButtonOfDeleteClient.Click += ButtonOfDeleteClient_Click;
            // 
            // EditClient
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(818, 763);
            Controls.Add(ButtonOfDeleteClient);
            Controls.Add(ComboBoxOfContractor);
            Controls.Add(ButtonOfCancel);
            Controls.Add(ButtonOfSaveChanges);
            Controls.Add(TextBoxOfContactInfo);
            Controls.Add(TextBoxOfINN);
            Controls.Add(LabelOfContactInfo);
            Controls.Add(LabelOfINN);
            Controls.Add(LabelOfContractor);
            Controls.Add(TextBoxOfName);
            Controls.Add(LabelOfName);
            Controls.Add(LabelOfEditClient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление данными клиентской базы";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ComboBoxOfContractor;
        private Button ButtonOfCancel;
        private Button ButtonOfSaveChanges;
        private TextBox TextBoxOfContactInfo;
        private TextBox TextBoxOfINN;
        private Label LabelOfContactInfo;
        private Label LabelOfINN;
        private Label LabelOfContractor;
        private TextBox TextBoxOfName;
        private Label LabelOfName;
        private Label LabelOfEditClient;
        private Button ButtonOfDeleteClient;
    }
}