using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows.Forms;

namespace BeresinDesktop
{
    public partial class DashboardForm : Form
    {
        string connString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BeresinDB;Integrated Security=True;";
        string userRole;

        public DashboardForm(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

            if (userRole == "Admin")
            {
                lblWelcome.Text = "Selamat Datang Admin, Anda memiliki akses penuh";
                btnDelete.Visible = true; // Admin bisa lihat tombol hapus
            }
            else
            {
                lblWelcome.Text = "Selamat Datang Pengguna, akses terbatas";
                btnDelete.Visible = false; // Selain admin, tombol hapus disembunyikan
            }

            LoadTasks();
            LoadCategories();
        }


        void LoadTasks()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"SELECT Tasks.TaskID, Tasks.Title, Tasks.Status, Categories.CategoryName
                        FROM Tasks
                        INNER JOIN Categories ON Tasks.CategoryID = Categories.CategoryID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvTasks.DataSource = dt;
            }
        }

        void LoadCategories()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT CategoryID, CategoryName FROM Categories";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "CategoryName"; // yang tampil
                cmbCategory.ValueMember = "CategoryID";     // yang dikirim
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"SELECT * FROM Tasks 
                        WHERE Title LIKE @search";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvTasks.DataSource = dt;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

         
            if (dgvTasks.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvTasks.CurrentRow.Cells["TaskID"].Value);

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "UPDATE Tasks SET Title=@title, Status=@status WHERE TaskID=@id";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@title", txtTambah.Text);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil diupdate!");

                    LoadTasks();
                }
            }
            else
            {
                MessageBox.Show("Klik data dulu di tabel!");
            }
        }


        private void btnTambah_Click(object sender, EventArgs e)
        {


            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "INSERT INTO Tasks (Title, Status, CategoryID) VALUES (@title, @status, @category)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@title", txtTambah.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@category", cmbCategory.SelectedValue); // 🔥 ini penting

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil ditambahkan!");

                LoadTasks();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvTasks.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["TaskID"].Value);

                DialogResult result = MessageBox.Show(
                    "Yakin mau hapus data ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo
                );

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();

                        string query = "DELETE FROM Tasks WHERE TaskID=@id";

                        SqlCommand cmd = new SqlCommand(query, conn);

                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data berhasil dihapus!");

                        LoadTasks();
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data dulu!");
            }
        }


        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }


        private void txtTambah_TextChanged(object sender, EventArgs e)
        {

        }
        private void dgvTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTasks.Rows[e.RowIndex];

                txtTambah.Text = row.Cells["Title"].Value.ToString();
                cmbStatus.Text = row.Cells["Status"].Value.ToString();
            }
        }
    }

}


