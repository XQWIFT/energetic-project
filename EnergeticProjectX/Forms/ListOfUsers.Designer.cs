namespace ListOfUsersForm
{
    partial class ListOfUsers
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridOfUsers = new DataGridView();
            ReturnToAdministratorPanel = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGridOfUsers).BeginInit();
            SuspendLayout();
            // 
            // DataGridOfUsers
            // 
            DataGridOfUsers.AllowUserToAddRows = false;
            DataGridOfUsers.AllowUserToDeleteRows = false;
            DataGridOfUsers.AllowUserToResizeColumns = false;
            DataGridOfUsers.AllowUserToResizeRows = false;
            DataGridOfUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridOfUsers.BackgroundColor = SystemColors.ControlLight;
            DataGridOfUsers.BorderStyle = BorderStyle.Fixed3D;
            DataGridOfUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DataGridOfUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DataGridOfUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridOfUsers.GridColor = SystemColors.WindowText;
            DataGridOfUsers.Location = new Point(39, 34);
            DataGridOfUsers.MultiSelect = false;
            DataGridOfUsers.Name = "DataGridOfUsers";
            DataGridOfUsers.ReadOnly = true;
            DataGridOfUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DataGridOfUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataGridOfUsers.RowHeadersVisible = false;
            DataGridOfUsers.RowHeadersWidth = 62;
            DataGridOfUsers.Size = new Size(864, 611);
            DataGridOfUsers.TabIndex = 0;
            // 
            // ReturnToAdministratorPanel
            // 
            ReturnToAdministratorPanel.FlatAppearance.BorderColor = Color.Black;
            ReturnToAdministratorPanel.FlatAppearance.BorderSize = 4;
            ReturnToAdministratorPanel.FlatAppearance.MouseDownBackColor = Color.Gray;
            ReturnToAdministratorPanel.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ReturnToAdministratorPanel.FlatStyle = FlatStyle.Flat;
            ReturnToAdministratorPanel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ReturnToAdministratorPanel.Location = new Point(39, 662);
            ReturnToAdministratorPanel.Name = "ReturnToAdministratorPanel";
            ReturnToAdministratorPanel.Size = new Size(372, 78);
            ReturnToAdministratorPanel.TabIndex = 3;
            ReturnToAdministratorPanel.Text = "Главное меню";
            ReturnToAdministratorPanel.UseVisualStyleBackColor = true;
            ReturnToAdministratorPanel.Click += ReturnToAdministratorPanel_Click;
            // 
            // ListOfUsers
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(946, 762);
            Controls.Add(ReturnToAdministratorPanel);
            Controls.Add(DataGridOfUsers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ListOfUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Просмотр пользователей системы";
            ((System.ComponentModel.ISupportInitialize)DataGridOfUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DataGridOfUsers;
        private Button ReturnToAdministratorPanel;
    }
}