namespace EnergeticProjectX.Forms
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
            LabelOfAddClient = new Label();
            LabelOfName = new Label();
            TextBoxOfName = new TextBox();
            LabelOfContractor = new Label();
            LabelOfInn = new Label();
            LabelOfContactInfo = new Label();
            TextBoxOfINN = new TextBox();
            TextBoxOfContactInfo = new TextBox();
            ButtonOfAddClient = new Button();
            ButtonOfCancel = new Button();
            ComboBoxOfContractor = new ComboBox();
            SuspendLayout();
            // 
            // LabelOfAddClient
            // 
            LabelOfAddClient.AutoSize = true;
            LabelOfAddClient.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfAddClient.Location = new Point(192, 40);
            LabelOfAddClient.Name = "LabelOfAddClient";
            LabelOfAddClient.Size = new Size(433, 54);
            LabelOfAddClient.TabIndex = 0;
            LabelOfAddClient.Text = "Добавление клиента";
            // 
            // LabelOfName
            // 
            LabelOfName.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfName.Location = new Point(111, 114);
            LabelOfName.Name = "LabelOfName";
            LabelOfName.Size = new Size(261, 45);
            LabelOfName.TabIndex = 0;
            LabelOfName.Text = "Наименование";
            // 
            // TextBoxOfName
            // 
            TextBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfName.Location = new Point(111, 171);
            TextBoxOfName.Name = "TextBoxOfName";
            TextBoxOfName.Size = new Size(583, 45);
            TextBoxOfName.TabIndex = 1;
            TextBoxOfName.TextChanged += IsTextChanged;
            // 
            // LabelOfContractor
            // 
            LabelOfContractor.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfContractor.Location = new Point(111, 240);
            LabelOfContractor.Name = "LabelOfContractor";
            LabelOfContractor.Size = new Size(210, 45);
            LabelOfContractor.TabIndex = 0;
            LabelOfContractor.Text = "Контрагент";
            // 
            // LabelOfInn
            // 
            LabelOfInn.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfInn.Location = new Point(111, 362);
            LabelOfInn.Name = "LabelOfInn";
            LabelOfInn.Size = new Size(479, 45);
            LabelOfInn.TabIndex = 0;
            LabelOfInn.Text = "Идентификационный номер";
            // 
            // LabelOfContactInfo
            // 
            LabelOfContactInfo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LabelOfContactInfo.Location = new Point(111, 495);
            LabelOfContactInfo.Name = "LabelOfContactInfo";
            LabelOfContactInfo.Size = new Size(419, 48);
            LabelOfContactInfo.TabIndex = 0;
            LabelOfContactInfo.Text = "Контактная информация";
            // 
            // TextBoxOfINN
            // 
            TextBoxOfINN.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfINN.Location = new Point(111, 423);
            TextBoxOfINN.Name = "TextBoxOfINN";
            TextBoxOfINN.Size = new Size(583, 45);
            TextBoxOfINN.TabIndex = 3;
            TextBoxOfINN.TextChanged += IsTextChanged;
            // 
            // TextBoxOfContactInfo
            // 
            TextBoxOfContactInfo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            TextBoxOfContactInfo.Location = new Point(111, 546);
            TextBoxOfContactInfo.Name = "TextBoxOfContactInfo";
            TextBoxOfContactInfo.Size = new Size(583, 45);
            TextBoxOfContactInfo.TabIndex = 4;
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
            ButtonOfAddClient.TabIndex = 5;
            ButtonOfAddClient.Text = "Добавить";
            ButtonOfAddClient.UseVisualStyleBackColor = true;
            ButtonOfAddClient.Click += ButtonOfAddClient_Click;
            ButtonOfAddClient.Enter += TabSelection_Enter;
            ButtonOfAddClient.Leave += TabSelection_Leave;
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
            ButtonOfCancel.TabIndex = 6;
            ButtonOfCancel.Text = "Отменить";
            ButtonOfCancel.UseVisualStyleBackColor = true;
            ButtonOfCancel.Click += ButtonOfCancel_Click;
            ButtonOfCancel.Enter += TabSelection_Enter;
            ButtonOfCancel.Leave += TabSelection_Leave;
            // 
            // ComboBoxOfContractor
            // 
            ComboBoxOfContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOfContractor.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ComboBoxOfContractor.FormattingEnabled = true;
            ComboBoxOfContractor.Items.AddRange(new object[] { "Физ. лицо", "Юр. лицо", "ИП" });
            ComboBoxOfContractor.Location = new Point(111, 288);
            ComboBoxOfContractor.Name = "ComboBoxOfContractor";
            ComboBoxOfContractor.Size = new Size(583, 46);
            ComboBoxOfContractor.TabIndex = 2;
            ComboBoxOfContractor.SelectedIndexChanged += IsTextChanged;
            ComboBoxOfContractor.TextChanged += IsTextChanged;
            // 
            // AddClient
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(800, 774);
            Controls.Add(ComboBoxOfContractor);
            Controls.Add(ButtonOfCancel);
            Controls.Add(ButtonOfAddClient);
            Controls.Add(TextBoxOfContactInfo);
            Controls.Add(TextBoxOfINN);
            Controls.Add(LabelOfContactInfo);
            Controls.Add(LabelOfInn);
            Controls.Add(LabelOfContractor);
            Controls.Add(TextBoxOfName);
            Controls.Add(LabelOfName);
            Controls.Add(LabelOfAddClient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление клиента";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelOfAddClient;
        private Label LabelOfName;
        private TextBox TextBoxOfName;
        private Label LabelOfContractor;
        private Label LabelOfInn;
        private Label LabelOfContactInfo;
        private TextBox TextBoxOfINN;
        private TextBox TextBoxOfContactInfo;
        private Button ButtonOfAddClient;
        private Button ButtonOfCancel;
        private ComboBox ComboBoxOfContractor;
    }
}