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
    public partial class Percels : Form
    {
        string path = @"Data Source=LAPTOP-854N6ANR;Initial Catalog=deliverySystem;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int ID3;
        public Percels()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            display();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Percels_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        //----------------Add----------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (CName.Text != "" && PDate.Text != "" && Source.Text != "" && SName.Text != "" && RName.Text != "" && RPhone.Text != "" && RAddress.Text != "" && Weight.Text != "" && Size.Text != "")
            {
                try
                {

                    con = new SqlConnection(path);
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Percel(Agent_Name, Percel_Date, Percel_Source,Sender_Name,Receiver_Name,Receiver_Address,Receiver_Phone,Package_Weight,Package_Size) VALUES ('" + CName.Text + "', '" + PDate.Text + "', '" + Source.Text + "', '" + SName.Text + "', '" + RName.Text + "', '" + RPhone.Text + "', '" + RAddress.Text + "', '" + Weight.Text + "', '" + Size.Text + "')", con);
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
            CName.Text = "";
            PDate.Text = "";
            Source.Text = "";
            SName.Text = "";
            RName.Text = "";
            RPhone.Text = "";
            RAddress.Text = "";
            Weight.Text = "";
            Size.Text = "";
        }



        public void display()
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from Percel", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            ID3 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            CName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            PDate.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Source.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            SName.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            RName.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            RPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            RAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            Weight.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            Size.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }



        //----------------Update----------------
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(path);
                con.Open();
                cmd = new SqlCommand("update Percel set Agent_Name='" + CName.Text + "', Percel_Date = '" + PDate.Text + "', Percel_Source = '" + Source.Text + "', Sender_Name='" + SName.Text + "', Receiver_Name='" + RName.Text + "', Receiver_Address='" + RPhone.Text + "', Receiver_Phone='" + RAddress.Text + "', Package_Weight='" + Weight.Text + "', Package_Size='" + Size.Text + "' where Percel_Id ='" + ID3 + "'", con);
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
                cmd = new SqlCommand("delete from Percel where Percel_Id='" + ID3 + "'", con);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
