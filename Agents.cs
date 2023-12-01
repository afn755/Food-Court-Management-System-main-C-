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
    public partial class Agents : Form
    {
        string path = @"Data Source=LAPTOP-F31TJSO1;Initial Catalog=DeliveryManagementSystem;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int ID9;
        public Agents()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminHome f = new AdminHome();
            f.Show();
            this.Hide();
        }
        //-------------Add-----------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (Fname.Text != "" && Lname.Text != "" && Email.Text != "" && Password.Text != "")
            {
                try
                {

                    con = new SqlConnection(path);
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO AgentInfo (Agents_fName, Agents_lName, Agents_Email, Acc_Password) VALUES ('" + Fname.Text + "', '" + Lname.Text + "', '" + Email.Text + "', '" + Password.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Agent Added Successfully.");
                    clear();
                    display();


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


 
        public void display()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from AgentInfo", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID9 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Fname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Lname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Email.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Password.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }




        //-------------Update-----------------------
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
              
                con.Open();
                cmd = new SqlCommand("update AgentInfo set Agents_fName='"+ Fname.Text + "', Agents_lName = '" + Lname.Text + "', Agents_Email = '" + Email.Text + "', Acc_Password='"+ Password.Text + "' where Agents_Id='" + ID9+"'",con );
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Your Data Has been Updated.");
                clear();
                display();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }





        //-------------Delete-----------------------
        private void button3_Click(object sender, EventArgs e)
        {


            try
            {

                con.Open();
                cmd = new SqlCommand("delete from AgentInfo where Agents_fName='" + Fname + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Your Data Has been Deleted.");
                clear();
                display();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Agents_Load(object sender, EventArgs e)
        {

        }
    }

}
