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
    public partial class Delivery : Form
    {
        string path = @"Data Source=LAPTOP-854N6ANR;Initial Catalog=deliverySystem;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int ID1;
        public Delivery()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Delivery_Load(object sender, EventArgs e)
        {

        }





        //----------------Add----------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (AName.Text != "" && Date.Text != "" && Fee.Text != "" && SName.Text != "" && SEmail.Text != "" && SAddress.Text != "")
            {
                try
                {

                    con = new SqlConnection(path);
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Delivery(Delivery_AName, Delivery_Date, Delivery_Fees,Delivery_SName,Delivery_SEmail,Delivery_SAddress) VALUES ('" + AName.Text + "', '" + Date.Text + "', '" + Fee.Text + "', '" + SName.Text + "', '" + SEmail.Text + "', '" + SAddress.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Added Successfully.");
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
            AName.Text = "";
            Date.Text = "";
            Fee.Text = "";
            SName.Text = "";
            SEmail.Text = "";
            SAddress.Text = "";
        }



        public void display()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from Delivery", con);
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
            ID1 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            AName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Date.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Fee.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            SName.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            SEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            SAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }










        //----------------UpdaTE----------------
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("update Delivery set Delivery_AName='" + AName.Text + "', Delivery_Date = '" + Date.Text + "', Delivery_Fees = '" + Fee.Text + "', Delivery_SName='" + SName.Text + "', Delivery_SEmail='" + SEmail.Text + "', Delivery_SAddress='" + SAddress.Text + "' where Delivery_Id ='" + ID1 + "'", con);
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
                cmd = new SqlCommand("delete from Delivery where Delivery_Id='" + ID1 + "'", con);
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


    }
}
