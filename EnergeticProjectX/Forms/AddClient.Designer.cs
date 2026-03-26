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
            labelOfName = new Label();
            textBoxOfName = new TextBox();
            labelOfContractor = new Label();
            labelOfINN = new Label();
            labelOfContactInfo = new Label();
            textBoxOfINN = new TextBox();
            textBoxOfContactInfo = new TextBox();
            buttonOfAdd = new Button();
            buttonOfCancel = new Button();
            comboBoxOfContractor = new ComboBox();
            SuspendLayout();
            // 
            // labelOfAddClient
            // 
            labelOfAddClient.AutoSize = true;
            labelOfAddClient.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfAddClient.Location = new Point(217, 9);
            labelOfAddClient.Name = "labelOfAddClient";
            labelOfAddClient.Size = new Size(364, 48);
            labelOfAddClient.TabIndex = 0;
            labelOfAddClient.Text = "Добавление клиента";
            // 
            // labelOfName
            // 
            labelOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfName.Location = new Point(12, 108);
            labelOfName.Name = "labelOfName";
            labelOfName.Size = new Size(151, 45);
            labelOfName.TabIndex = 1;
            labelOfName.Text = "Название";
            // 
            // textBoxOfName
            // 
            textBoxOfName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfName.Location = new Point(217, 108);
            textBoxOfName.Name = "textBoxOfName";
            textBoxOfName.Size = new Size(561, 45);
            textBoxOfName.TabIndex = 2;
            // 
            // labelOfContractor
            // 
            labelOfContractor.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfContractor.Location = new Point(12, 182);
            labelOfContractor.Name = "labelOfContractor";
            labelOfContractor.Size = new Size(186, 45);
            labelOfContractor.TabIndex = 3;
            labelOfContractor.Text = "Контрагент";
            // 
            // labelOfINN
            // 
            labelOfINN.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfINN.Location = new Point(43, 262);
            labelOfINN.Name = "labelOfINN";
            labelOfINN.Size = new Size(85, 45);
            labelOfINN.TabIndex = 4;
            labelOfINN.Text = "ИНН";
            // 
            // labelOfContactInfo
            // 
            labelOfContactInfo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelOfContactInfo.Location = new Point(12, 336);
            labelOfContactInfo.Name = "labelOfContactInfo";
            labelOfContactInfo.Size = new Size(186, 82);
            labelOfContactInfo.TabIndex = 5;
            labelOfContactInfo.Text = "Контактная информация";
            // 
            // textBoxOfINN
            // 
            textBoxOfINN.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfINN.Location = new Point(217, 262);
            textBoxOfINN.Name = "textBoxOfINN";
            textBoxOfINN.Size = new Size(561, 45);
            textBoxOfINN.TabIndex = 7;
            // 
            // textBoxOfContactInfo
            // 
            textBoxOfContactInfo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxOfContactInfo.Location = new Point(217, 359);
            textBoxOfContactInfo.Name = "textBoxOfContactInfo";
            textBoxOfContactInfo.Size = new Size(561, 45);
            textBoxOfContactInfo.TabIndex = 8;
            // 
            // buttonOfAdd
            // 
            buttonOfAdd.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfAdd.Location = new Point(12, 437);
            buttonOfAdd.Name = "buttonOfAdd";
            buttonOfAdd.Size = new Size(363, 68);
            buttonOfAdd.TabIndex = 9;
            buttonOfAdd.Text = "Добавить";
            buttonOfAdd.UseVisualStyleBackColor = true;
            buttonOfAdd.Click += buttonOfAdd_Click;
            // 
            // buttonOfCancel
            // 
            buttonOfCancel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOfCancel.Location = new Point(415, 437);
            buttonOfCancel.Name = "buttonOfCancel";
            buttonOfCancel.Size = new Size(363, 69);
            buttonOfCancel.TabIndex = 10;
            buttonOfCancel.Text = "Отменить";
            buttonOfCancel.UseVisualStyleBackColor = true;
            buttonOfCancel.Click += buttonOfCancel_Click;
            // 
            // comboBoxOfContractor
            // 
            comboBoxOfContractor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOfContractor.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxOfContractor.FormattingEnabled = true;
            comboBoxOfContractor.Items.AddRange(new object[] { "Физ.лицо", "Юр.лицо", "ИП" });
            comboBoxOfContractor.Location = new Point(217, 182);
            comboBoxOfContractor.Name = "comboBoxOfContractor";
            comboBoxOfContractor.Size = new Size(561, 46);
            comboBoxOfContractor.TabIndex = 11;
            // 
            // AddClient
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 518);
            Controls.Add(comboBoxOfContractor);
            Controls.Add(buttonOfCancel);
            Controls.Add(buttonOfAdd);
            Controls.Add(textBoxOfContactInfo);
            Controls.Add(textBoxOfINN);
            Controls.Add(labelOfContactInfo);
            Controls.Add(labelOfINN);
            Controls.Add(labelOfContractor);
            Controls.Add(textBoxOfName);
            Controls.Add(labelOfName);
            Controls.Add(labelOfAddClient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddClient";
            Text = "Добавление клиента";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelOfAddClient;
        private Label labelOfName;
        private TextBox textBoxOfName;
        private Label labelOfContractor;
        private Label labelOfINN;
        private Label labelOfContactInfo;
        private TextBox textBoxOfINN;
        private TextBox textBoxOfContactInfo;
        private Button buttonOfAdd;
        private Button buttonOfCancel;
        private ComboBox comboBoxOfContractor;
    }
}