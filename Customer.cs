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
    public partial class Customer : Form
    {
        string path = @"Data Source=LAPTOP-854N6ANR;Initial Catalog=deliverySystem;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int ID8;
        public Customer()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            display();
        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1  f= new Form1();
            f.Show();
            this.Hide();
        }




        //----------------Delete----------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (CName.Text != "" && CPnone.Text != "" && CEmail.Text != "" && CAddress.Text != "")
            {
                try
                {

                    con = new SqlConnection(path);
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Coustomers (Coustomers_fName, Coustomers_Phone, Coustomers_Email, Coustomers_Address) VALUES ('" + CName.Text + "', '" + CPnone.Text + "', '" + CEmail.Text + "', '" + CAddress.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Coustomer Added Successfully.");
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
            CName.Text = "";
            CPnone.Text = "";
            CEmail.Text = "";
            CAddress.Text = "";
        }

        public void display()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from Coustomers", con);
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
            ID8 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            CName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            CPnone.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            CAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }




        //----------------Delete----------------
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("update Coustomers set Coustomers_fName='" + CName.Text + "', Coustomers_Phone = '" + CPnone.Text + "', Coustomers_Email = '" + CEmail.Text + "',Coustomers_Address='" + CAddress.Text + "' where Coustomers_Id='" + ID8 + "'", con);
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





        //----------------Delete----------------
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("delete from Coustomers where Coustomers_Id='" + ID8 + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Coustomer Data Has been Deleted.");
                clear();
                display();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

