namespace EnergeticProjectX.Forms
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
            DGVOfUsers = new DataGridView();
            ReturnToAdministratorPanel = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVOfUsers).BeginInit();
            SuspendLayout();
            // 
            // DGVOfUsers
            // 
            DGVOfUsers.AllowUserToAddRows = false;
            DGVOfUsers.AllowUserToDeleteRows = false;
            DGVOfUsers.AllowUserToResizeColumns = false;
            DGVOfUsers.AllowUserToResizeRows = false;
            DGVOfUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVOfUsers.BackgroundColor = SystemColors.ControlLight;
            DGVOfUsers.BorderStyle = BorderStyle.Fixed3D;
            DGVOfUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGVOfUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGVOfUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVOfUsers.GridColor = SystemColors.WindowText;
            DGVOfUsers.Location = new Point(12, 12);
            DGVOfUsers.MultiSelect = false;
            DGVOfUsers.Name = "DGVOfUsers";
            DGVOfUsers.ReadOnly = true;
            DGVOfUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DGVOfUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DGVOfUsers.RowHeadersVisible = false;
            DGVOfUsers.RowHeadersWidth = 62;
            DGVOfUsers.Size = new Size(922, 645);
            DGVOfUsers.TabIndex = 0;
            DGVOfUsers.CellMouseClick += DGVOfUsers_CellMouseClick;
            DGVOfUsers.CellMouseDoubleClick += DGVOfUsers_CellMouseClick;
            DGVOfUsers.CellMouseEnter += DGVOfUsers_CellMouseEnter;
            // 
            // ReturnToAdministratorPanel
            // 
            ReturnToAdministratorPanel.FlatAppearance.BorderColor = Color.Black;
            ReturnToAdministratorPanel.FlatAppearance.BorderSize = 4;
            ReturnToAdministratorPanel.FlatAppearance.MouseDownBackColor = Color.Gray;
            ReturnToAdministratorPanel.FlatAppearance.MouseOverBackColor = Color.LightGray;
            ReturnToAdministratorPanel.FlatStyle = FlatStyle.Flat;
            ReturnToAdministratorPanel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ReturnToAdministratorPanel.Location = new Point(242, 672);
            ReturnToAdministratorPanel.Name = "ReturnToAdministratorPanel";
            ReturnToAdministratorPanel.Size = new Size(372, 78);
            ReturnToAdministratorPanel.TabIndex = 1;
            ReturnToAdministratorPanel.Text = "Главное меню";
            ReturnToAdministratorPanel.UseVisualStyleBackColor = true;
            ReturnToAdministratorPanel.Click += ReturnToAdministratorPanel_Click;
            ReturnToAdministratorPanel.Enter += TabSelection_Enter;
            ReturnToAdministratorPanel.Leave += TabSelection_Leave;
            // 
            // ListOfUsers
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(946, 762);
            Controls.Add(ReturnToAdministratorPanel);
            Controls.Add(DGVOfUsers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ListOfUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Просмотр пользователей системы";
            ((System.ComponentModel.ISupportInitialize)DGVOfUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVOfUsers;
        private Button ReturnToAdministratorPanel;
    }
}