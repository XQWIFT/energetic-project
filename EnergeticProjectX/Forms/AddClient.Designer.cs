namespace AddClientForm
{
    partial class AddClient
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
            labelOfAddClient = new Label();
            LabelOfName = new Label();
            textBoxOfName = new TextBox();
            LabelOfContractor = new Label();
            labelOfINN = new Label();
            LabelOfContactInfo = new Label();
            textBoxOfINN = new TextBox();
            textBoxOfContactInfo = new TextBox();
            ButtonOfAddClient = new Button();
            ButtonOfCancel = new Button();
            comboBoxOfContractor = new ComboBox();
            SuspendLayout();
            // 
            // labelOfAddClient
            // 
            labelOfAddClient.AutoSize = true;
            labelOfAddClient.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfAddClient.Location = new Point(192, 40);
            labelOfAddClient.Name = "labelOfAddClient";
            labelOfAddClient.Size = new Size(433, 54);
            labelOfAddClient.TabIndex = 0;
            labelOfAddClient.Text = "Добавление клиента";
            // 
            // LabelOfName
            // 
            LabelOfName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfName.Location = new Point(111, 114);
            LabelOfName.Name = "LabelOfName";
            LabelOfName.Size = new Size(261, 45);
            LabelOfName.TabIndex = 1;
            LabelOfName.Text = "Наименование";
            // 
            // textBoxOfName
            // 
            textBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfName.Location = new Point(111, 171);
            textBoxOfName.Name = "textBoxOfName";
            textBoxOfName.Size = new Size(583, 45);
            textBoxOfName.TabIndex = 2;
            // 
            // LabelOfContractor
            // 
            LabelOfContractor.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfContractor.Location = new Point(111, 240);
            LabelOfContractor.Name = "LabelOfContractor";
            LabelOfContractor.Size = new Size(210, 45);
            LabelOfContractor.TabIndex = 3;
            LabelOfContractor.Text = "Контрагент";
            // 
            // labelOfINN
            // 
            labelOfINN.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelOfINN.Location = new Point(111, 362);
            labelOfINN.Name = "labelOfINN";
            labelOfINN.Size = new Size(479, 45);
            labelOfINN.TabIndex = 4;
            labelOfINN.Text = "Идентификационный номер";
            // 
            // LabelOfContactInfo
            // 
            LabelOfContactInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfContactInfo.Location = new Point(111, 495);
            LabelOfContactInfo.Name = "LabelOfContactInfo";
            LabelOfContactInfo.Size = new Size(419, 57);
            LabelOfContactInfo.TabIndex = 5;
            LabelOfContactInfo.Text = "Контактная информация";
            // 
            // textBoxOfINN
            // 
            textBoxOfINN.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfINN.Location = new Point(111, 423);
            textBoxOfINN.Name = "textBoxOfINN";
            textBoxOfINN.Size = new Size(583, 45);
            textBoxOfINN.TabIndex = 7;
            // 
            // textBoxOfContactInfo
            // 
            textBoxOfContactInfo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfContactInfo.Location = new Point(111, 546);
            textBoxOfContactInfo.Name = "textBoxOfContactInfo";
            textBoxOfContactInfo.Size = new Size(583, 45);
            textBoxOfContactInfo.TabIndex = 8;
            // 
            // ButtonOfAddClient
            // 
            ButtonOfAddClient.Enabled = false;
            ButtonOfAddClient.FlatAppearance.BorderColor = Color.Black;
            ButtonOfAddClient.FlatAppearance.BorderSize = 4;
            ButtonOfAddClient.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfAddClient.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfAddClient.FlatStyle = FlatStyle.Flat;
            ButtonOfAddClient.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            ButtonOfAddClient.Location = new Point(111, 635);
            ButtonOfAddClient.Name = "ButtonOfAddClient";
            ButtonOfAddClient.Size = new Size(288, 68);
            ButtonOfAddClient.TabIndex = 9;
            ButtonOfAddClient.Text = "Добавить";
            ButtonOfAddClient.UseVisualStyleBackColor = true;
            ButtonOfAddClient.Click += ButtonOfAddClient_Click;
            // 
            // ButtonOfCancel
            // 
            ButtonOfCancel.FlatAppearance.BorderColor = Color.Black;
            ButtonOfCancel.FlatAppearance.BorderSize = 4;
            ButtonOfCancel.FlatAppearance.MouseDownBackColor = Color.Gray;
            ButtonOfCancel.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ButtonOfCancel.FlatStyle = FlatStyle.Flat;
            ButtonOfCancel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            ButtonOfCancel.Location = new Point(405, 635);
            ButtonOfCancel.Name = "ButtonOfCancel";
            ButtonOfCancel.Size = new Size(289, 69);
            ButtonOfCancel.TabIndex = 10;
            ButtonOfCancel.Text = "Отменить";
            ButtonOfCancel.UseVisualStyleBackColor = true;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
            // 
            // comboBoxOfContractor
            // 
            comboBoxOfContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOfContractor.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxOfContractor.FormattingEnabled = true;
            comboBoxOfContractor.Items.AddRange(new object[] { "Физ.лицо", "Юр.лицо", "ИП" });
            comboBoxOfContractor.Location = new Point(111, 288);
            comboBoxOfContractor.Name = "comboBoxOfContractor";
            comboBoxOfContractor.Size = new Size(583, 46);
            comboBoxOfContractor.TabIndex = 11;
            // 
            // AddClient
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(800, 774);
            Controls.Add(comboBoxOfContractor);
            Controls.Add(ButtonOfCancel);
            Controls.Add(ButtonOfAddClient);
            Controls.Add(textBoxOfContactInfo);
            Controls.Add(textBoxOfINN);
            Controls.Add(LabelOfContactInfo);
            Controls.Add(labelOfINN);
            Controls.Add(LabelOfContractor);
            Controls.Add(textBoxOfName);
            Controls.Add(LabelOfName);
            Controls.Add(labelOfAddClient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление клиента";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelOfAddClient;
        private Label LabelOfName;
        private TextBox textBoxOfName;
        private Label LabelOfContractor;
        private Label labelOfINN;
        private Label LabelOfContactInfo;
        private TextBox textBoxOfINN;
        private TextBox textBoxOfContactInfo;
        private Button ButtonOfAddClient;
        private Button ButtonOfCancel;
        private ComboBox comboBoxOfContractor;
    }
}