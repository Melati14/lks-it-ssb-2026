namespace BeresinDesktop
{
    partial class DashboardForm
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
            dgvTasks = new DataGridView();
            txtSearch = new TextBox();
            cmbStatus = new ComboBox();
            btnTambah = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            lblWelcome = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            // 
            // dgvTasks
            // 
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(43, 107);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.RowHeadersWidth = 62;
            dgvTasks.Size = new Size(360, 225);
            dgvTasks.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(193, 37);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 31);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += textBox1_TextChanged;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Pending", "Completed" });
            cmbStatus.Location = new Point(510, 35);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(182, 33);
            cmbStatus.TabIndex = 2;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // btnTambah
            // 
            btnTambah.Location = new Point(580, 127);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(112, 34);
            btnTambah.TabIndex = 3;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = true;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(580, 183);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += button2_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(580, 235);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(65, 44);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(59, 25);
            lblWelcome.TabIndex = 6;
            lblWelcome.Text = "label1";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblWelcome);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnTambah);
            Controls.Add(cmbStatus);
            Controls.Add(txtSearch);
            Controls.Add(dgvTasks);
            Name = "DashboardForm";
            Text = "DashboardForm";
            Load += DashboardForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTasks;
        private TextBox txtSearch;
        private ComboBox cmbStatus;
        private Button btnTambah;
        private Button btnEdit;
        private Button btnDelete;
        private Label lblWelcome;
    }
}