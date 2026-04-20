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
            comboBoxOfContractor = new ComboBox();
            ButtonOfCancel = new Button();
            ButtonOfSaveChanges = new Button();
            textBoxOfContactInfo = new TextBox();
            textBoxOfINN = new TextBox();
            labelOfContactInfo = new Label();
            labelOfINN = new Label();
            labelOfContractor = new Label();
            textBoxOfName = new TextBox();
            labelOfName = new Label();
            LabelOfEditClient = new Label();
            ButtonOfDeleteClient = new Button();
            SuspendLayout();
            // 
            // comboBoxOfContractor
            // 
            comboBoxOfContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOfContractor.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxOfContractor.FormattingEnabled = true;
            comboBoxOfContractor.Items.AddRange(new object[] { "Физ.лицо", "Юр.лицо", "ИП" });
            comboBoxOfContractor.Location = new Point(127, 267);
            comboBoxOfContractor.Name = "comboBoxOfContractor";
            comboBoxOfContractor.Size = new Size(540, 46);
            comboBoxOfContractor.TabIndex = 22;
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
            // textBoxOfContactInfo
            // 
            textBoxOfContactInfo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfContactInfo.Location = new Point(127, 493);
            textBoxOfContactInfo.Name = "textBoxOfContactInfo";
            textBoxOfContactInfo.Size = new Size(540, 45);
            textBoxOfContactInfo.TabIndex = 19;
            // 
            // textBoxOfINN
            // 
            textBoxOfINN.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfINN.Location = new Point(127, 386);
            textBoxOfINN.Name = "textBoxOfINN";
            textBoxOfINN.Size = new Size(540, 45);
            textBoxOfINN.TabIndex = 18;
            // 
            // labelOfContactInfo
            // 
            labelOfContactInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfContactInfo.Location = new Point(127, 446);
            labelOfContactInfo.Name = "labelOfContactInfo";
            labelOfContactInfo.Size = new Size(419, 54);
            labelOfContactInfo.TabIndex = 17;
            labelOfContactInfo.Text = "Контактная информация";
            // 
            // labelOfINN
            // 
            labelOfINN.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfINN.Location = new Point(121, 338);
            labelOfINN.Name = "labelOfINN";
            labelOfINN.Size = new Size(477, 45);
            labelOfINN.TabIndex = 16;
            labelOfINN.Text = "Идентификационный номер";
            // 
            // labelOfContractor
            // 
            labelOfContractor.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfContractor.Location = new Point(121, 219);
            labelOfContractor.Name = "labelOfContractor";
            labelOfContractor.Size = new Size(207, 45);
            labelOfContractor.TabIndex = 15;
            labelOfContractor.Text = "Контрагент";
            // 
            // textBoxOfName
            // 
            textBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfName.Location = new Point(127, 158);
            textBoxOfName.Name = "textBoxOfName";
            textBoxOfName.Size = new Size(540, 45);
            textBoxOfName.TabIndex = 14;
            // 
            // labelOfName
            // 
            labelOfName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfName.Location = new Point(121, 110);
            labelOfName.Name = "labelOfName";
            labelOfName.Size = new Size(265, 45);
            labelOfName.TabIndex = 13;
            labelOfName.Text = "Наименование";
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
            Controls.Add(comboBoxOfContractor);
            Controls.Add(ButtonOfCancel);
            Controls.Add(ButtonOfSaveChanges);
            Controls.Add(textBoxOfContactInfo);
            Controls.Add(textBoxOfINN);
            Controls.Add(labelOfContactInfo);
            Controls.Add(labelOfINN);
            Controls.Add(labelOfContractor);
            Controls.Add(textBoxOfName);
            Controls.Add(labelOfName);
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

        private ComboBox comboBoxOfContractor;
        private Button ButtonOfCancel;
        private Button ButtonOfSaveChanges;
        private TextBox textBoxOfContactInfo;
        private TextBox textBoxOfINN;
        private Label labelOfContactInfo;
        private Label labelOfINN;
        private Label labelOfContractor;
        private TextBox textBoxOfName;
        private Label labelOfName;
        private Label LabelOfEditClient;
        private Button ButtonOfDeleteClient;
    }
}