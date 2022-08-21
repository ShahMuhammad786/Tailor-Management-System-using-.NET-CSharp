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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (this.panel1.Visible==false)
            {
                this.panel1.Visible = true;
            }
            else
            {
                this.panel1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || this.textBox2.Text=="")
            {
                MessageBox.Show("Please fill all the feilds.");
            }
            else
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

                int rows = dataset.Tables[0].Rows.Count;
                for (int i = 0; i < rows; i++)
                {
                    if (dataset.Tables[0].Rows[i][0].ToString() == this.textBox1.Text &&
                        dataset.Tables[0].Rows[i][1].ToString() == this.textBox2.Text)
                    {
                        new Index().Show();
                        this.Hide();
                        break;
                    }
                }
            }
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
