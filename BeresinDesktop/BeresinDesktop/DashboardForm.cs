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
        string connString = @"Server=localhost;Database=BeresinDB;Trusted_Connection=True;";
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

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "SELECT * FROM Tasks WHERE Status=@status";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvTasks.DataSource = dt;
            }
        }
    }
}
