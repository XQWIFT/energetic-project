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
            buttonOfCancel = new Button();
            buttonOfSaveChanges = new Button();
            textBoxOfContactInfo = new TextBox();
            textBoxOfINN = new TextBox();
            labelOfContactInfo = new Label();
            labelOfINN = new Label();
            labelOfContractor = new Label();
            textBoxOfName = new TextBox();
            labelOfName = new Label();
            labelOfEditClient = new Label();
            SuspendLayout();
            // 
            // comboBoxOfContractor
            // 
            comboBoxOfContractor.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxOfContractor.FormattingEnabled = true;
            comboBoxOfContractor.Items.AddRange(new object[] { "Физ.лицо", "Юр.лицо", "ИП" });
            comboBoxOfContractor.Location = new Point(222, 150);
            comboBoxOfContractor.Name = "comboBoxOfContractor";
            comboBoxOfContractor.Size = new Size(561, 46);
            comboBoxOfContractor.TabIndex = 22;
            // 
            // buttonOfCancel
            // 
            buttonOfCancel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfCancel.Location = new Point(420, 405);
            buttonOfCancel.Name = "buttonOfCancel";
            buttonOfCancel.Size = new Size(363, 69);
            buttonOfCancel.TabIndex = 21;
            buttonOfCancel.Text = "Отменить";
            buttonOfCancel.UseVisualStyleBackColor = true;
            buttonOfCancel.Click += buttonOfCancel_Click;
            // 
            // buttonOfSaveChanges
            // 
            buttonOfSaveChanges.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfSaveChanges.Location = new Point(17, 405);
            buttonOfSaveChanges.Name = "buttonOfSaveChanges";
            buttonOfSaveChanges.Size = new Size(363, 68);
            buttonOfSaveChanges.TabIndex = 20;
            buttonOfSaveChanges.Text = "Сохранить";
            buttonOfSaveChanges.UseVisualStyleBackColor = true;
            buttonOfSaveChanges.Click += buttonOfSaveChanges_Click;
            // 
            // textBoxOfContactInfo
            // 
            textBoxOfContactInfo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfContactInfo.Location = new Point(222, 327);
            textBoxOfContactInfo.Name = "textBoxOfContactInfo";
            textBoxOfContactInfo.Size = new Size(561, 45);
            textBoxOfContactInfo.TabIndex = 19;
            // 
            // textBoxOfINN
            // 
            textBoxOfINN.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfINN.Location = new Point(222, 230);
            textBoxOfINN.Name = "textBoxOfINN";
            textBoxOfINN.Size = new Size(561, 45);
            textBoxOfINN.TabIndex = 18;
            // 
            // labelOfContactInfo
            // 
            labelOfContactInfo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfContactInfo.Location = new Point(17, 304);
            labelOfContactInfo.Name = "labelOfContactInfo";
            labelOfContactInfo.Size = new Size(183, 98);
            labelOfContactInfo.TabIndex = 17;
            labelOfContactInfo.Text = "Контактная информация";
            // 
            // labelOfINN
            // 
            labelOfINN.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfINN.Location = new Point(48, 230);
            labelOfINN.Name = "labelOfINN";
            labelOfINN.Size = new Size(85, 45);
            labelOfINN.TabIndex = 16;
            labelOfINN.Text = "ИНН";
            // 
            // labelOfContractor
            // 
            labelOfContractor.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfContractor.Location = new Point(17, 150);
            labelOfContractor.Name = "labelOfContractor";
            labelOfContractor.Size = new Size(165, 45);
            labelOfContractor.TabIndex = 15;
            labelOfContractor.Text = "Контрагент";
            // 
            // textBoxOfName
            // 
            textBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfName.Location = new Point(222, 76);
            textBoxOfName.Name = "textBoxOfName";
            textBoxOfName.Size = new Size(561, 45);
            textBoxOfName.TabIndex = 14;
            // 
            // labelOfName
            // 
            labelOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfName.Location = new Point(17, 76);
            labelOfName.Name = "labelOfName";
            labelOfName.Size = new Size(151, 45);
            labelOfName.TabIndex = 13;
            labelOfName.Text = "Название";
            // 
            // labelOfEditClient
            // 
            labelOfEditClient.AutoSize = true;
            labelOfEditClient.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfEditClient.Location = new Point(170, 9);
            labelOfEditClient.Name = "labelOfEditClient";
            labelOfEditClient.Size = new Size(432, 48);
            labelOfEditClient.TabIndex = 12;
            labelOfEditClient.Text = "Редактирование клиента";
            // 
            // EditClient
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 498);
            Controls.Add(comboBoxOfContractor);
            Controls.Add(buttonOfCancel);
            Controls.Add(buttonOfSaveChanges);
            Controls.Add(textBoxOfContactInfo);
            Controls.Add(textBoxOfINN);
            Controls.Add(labelOfContactInfo);
            Controls.Add(labelOfINN);
            Controls.Add(labelOfContractor);
            Controls.Add(textBoxOfName);
            Controls.Add(labelOfName);
            Controls.Add(labelOfEditClient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditClient";
            Text = "Редактирование клиента";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxOfContractor;
        private Button buttonOfCancel;
        private Button buttonOfSaveChanges;
        private TextBox textBoxOfContactInfo;
        private TextBox textBoxOfINN;
        private Label labelOfContactInfo;
        private Label labelOfINN;
        private Label labelOfContractor;
        private TextBox textBoxOfName;
        private Label labelOfName;
        private Label labelOfEditClient;
    }
}