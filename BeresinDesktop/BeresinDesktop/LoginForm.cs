using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BeresinDesktop
{
    public partial class LoginForm : Form
    {
        string connString = @"Server=localhost;Database=BeresinDB;Trusted_Connection=True;";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT Role FROM Users WHERE Username=@username AND Password=@password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string role = result.ToString();
                    DashboardForm dash = new DashboardForm(role);
                    dash.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username atau Password salah");
                }
            }
        }
    }
}
    

