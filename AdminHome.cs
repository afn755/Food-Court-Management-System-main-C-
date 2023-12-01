using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agents a = new Agents();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delivery d = new Delivery();
            d.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Percels p = new Percels();
            p.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loginPage L = new loginPage();
            L.Show();
            this.Hide();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
