using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class loginPage : Form


    {
        string path = @"Data Source=LAPTOP-854N6ANR;Initial Catalog=deliverySystem;Integrated Security=True";
        SqlConnection con;
       // SqlCommand cmd;

        SqlDataAdapter adpt;
        DataTable dt;

        string pass;
        public loginPage()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm r = new RegistrationForm();
            r.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserName.Text != "" && Password.Text != "")
            {
                try
                {
                    dt = new DataTable();
                    con = new SqlConnection(path);
                    con.Open();
                    adpt = new SqlDataAdapter("select * from AgentInfo where Agents_Email='" + UserName.Text+"'", con);
                    adpt.Fill(dt);
                    con.Close();

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            pass = row["Acc_Password"].ToString();
                            if (pass == Password.Text)
                            {
                                MessageBox.Show("User Found.Please Select 'Ok' to continue.");
                                Form1 f = new Form1();
                                f.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Password");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No User Found");
                        }
                    }
                    
                            
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Invalid input");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminLoginForm ah = new AdminLoginForm();
            ah.Show();
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
