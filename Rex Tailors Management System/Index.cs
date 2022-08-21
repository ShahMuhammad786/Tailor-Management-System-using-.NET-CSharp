using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rex_Tailors_Management_System
{
    public partial class Index : Form
    {
        int pm;
        bool hided;

        public Index()
        {
            InitializeComponent();
            pm = sPanel.Width;
            hided = true;
            this.sPanel.Width = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hided)
            {
                sPanel.Width += 50;
                if (sPanel.Width >= pm)
                {
                    timer1.Stop();
                    hided = false;
                    this.Refresh();
                }
            }
            else
            {
                sPanel.Width -= 50;
                if (sPanel.Width <=0)
                {
                    timer1.Stop();
                    hided = true;
                    this.Refresh();
                }
            }
        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            this.sPanel.Width = 120;
            this.timer1.Start();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really want to LogOut ?","Logout Confirmation",MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                new login().Show();
                this.Hide();
            }

        }

        private void Index_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new placeOrder().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            new CompleteOrder().Show();
            this.Hide();
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            // Connection
            string connenctionString = ConfigurationManager.ConnectionStrings["cAString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connenctionString);

            //Command (SQL)
            SqlCommand command = new SqlCommand("select * from users", connection);

            //Definig dataset and dataAdapter;
            DataSet dataset = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dataset); //filling dataset using adapter.

            this.dataGrid.DataSource = dataset.Tables[0];
            this.dataDisplay.Visible = true;
        }

        private void btnPrep_Click(object sender, EventArgs e)
        {
            // Connection
            string connenctionString = ConfigurationManager.ConnectionStrings["cAString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connenctionString);

            //Command (SQL)
            SqlCommand command = new SqlCommand("select * from completed", connection);

            //Definig dataset and dataAdapter;
            DataSet dataset = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dataset); //filling dataset using adapter.

            this.dataGrid.DataSource = dataset.Tables[0];
            this.dataDisplay.Visible = true;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            // Connection
            string connenctionString = ConfigurationManager.ConnectionStrings["cAString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connenctionString);

            //Command (SQL)
            SqlCommand command = new SqlCommand("select * from payments", connection);

            //Definig dataset and dataAdapter;
            DataSet dataset = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dataset); //filling dataset using adapter.

            this.dataGrid.DataSource = dataset.Tables[0];
            this.dataDisplay.Visible = true;
        }

        private void btncust_Click(object sender, EventArgs e)
        {
            // Connection
            string connenctionString = ConfigurationManager.ConnectionStrings["cAString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connenctionString);

            //Command (SQL)
            SqlCommand command = new SqlCommand("select * from custOrder", connection);

            //Definig dataset and dataAdapter;
            DataSet dataset = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dataset); //filling dataset using adapter.

            this.dataGrid.DataSource = dataset.Tables[0];
            this.dataDisplay.Visible = true;
        }
    }
}
