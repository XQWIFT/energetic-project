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
            dataGridOfUsers = new DataGridView();
            ReturnToAdministratorPanel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridOfUsers).BeginInit();
            SuspendLayout();
            // 
            // dataGridOfUsers
            // 
            dataGridOfUsers.AllowUserToAddRows = false;
            dataGridOfUsers.AllowUserToDeleteRows = false;
            dataGridOfUsers.AllowUserToResizeColumns = false;
            dataGridOfUsers.AllowUserToResizeRows = false;
            dataGridOfUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOfUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridOfUsers.Location = new Point(39, 73);
            dataGridOfUsers.Name = "dataGridOfUsers";
            dataGridOfUsers.ReadOnly = true;
            dataGridOfUsers.RowHeadersVisible = false;
            dataGridOfUsers.RowHeadersWidth = 62;
            dataGridOfUsers.Size = new Size(864, 572);
            dataGridOfUsers.TabIndex = 0;
            // 
            // ReturnToAdministratorPanel
            // 
            ReturnToAdministratorPanel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ReturnToAdministratorPanel.Location = new Point(39, 651);
            ReturnToAdministratorPanel.Name = "ReturnToAdministratorPanel";
            ReturnToAdministratorPanel.Size = new Size(303, 78);
            ReturnToAdministratorPanel.TabIndex = 3;
            ReturnToAdministratorPanel.Text = "Главное меню";
            ReturnToAdministratorPanel.UseVisualStyleBackColor = true;
            ReturnToAdministratorPanel.Click += ReturnToAdministratorPanel_Click;
            // 
            // ListOfUsers
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 762);
            Controls.Add(ReturnToAdministratorPanel);
            Controls.Add(dataGridOfUsers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ListOfUsers";
            Text = "Список пользователей";
            ((System.ComponentModel.ISupportInitialize)dataGridOfUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridOfUsers;
        private Button ReturnToAdministratorPanel;
    }
}