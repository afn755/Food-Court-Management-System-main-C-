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
    public partial class RegistrationForm : Form
    {
        string path = @"Data Source=LAPTOP-854N6ANR;Initial Catalog=deliverySystem;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        public RegistrationForm()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loginPage l = new loginPage();
            l.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Fname.Text!="" && Lname.Text != "" && Email.Text != "" && Password.Text != "")
            {
                try 
                {
                   
                    con = new SqlConnection(path);
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO AgentInfo (Agents_fName, Agents_lName, Agents_Email, Acc_Password) VALUES ('" + Fname.Text + "', '" +Lname.Text + "', '" + Email.Text + "', '" + Password.Text + "')", con); 
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Account Created Successfully.Now you can login from Login page");
                    clear();

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
        public void clear()
        {
            Fname.Text = "";
            Lname.Text = "";
            Email.Text = "";
            Password.Text = "";
        }
    }
}
