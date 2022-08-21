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
    public partial class CompleteOrder : Form
    {
        public CompleteOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Index().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Connection
            string connenctionString = ConfigurationManager.ConnectionStrings["cAString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connenctionString);

            //Command (SQL)
            SqlCommand command = new SqlCommand("select * from completed", connection);

            //Definig dataset and dataAdapter;
            DataSet dataset = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dataset); //filling dataset using adapter.
            dataset.Tables[0].TableName = "completed";

            DataRow drow = dataset.Tables["completed"].NewRow();

            //Row index finding
            int lastRowIndex = 0;
            foreach (DataRow row in dataset.Tables["completed"].Rows)
            {
                if (row[0].ToString() == this.maskedTextBox1.Text)
                {
                    lastRowIndex = (int)dataset.Tables["completed"].Rows.IndexOf(row);
                    break;
                }
            }

            if (dataset.Tables[0].Rows[lastRowIndex][0] == this.maskedTextBox1.Text)
            {
                MessageBox.Show("Item Already Exist !");
            }
            else
            {
                drow[0] = Convert.ToInt32(this.maskedTextBox1.Text);
                drow[1] = this.maskedTextBox3.Text;
                drow[2] = Convert.ToInt32(this.maskedTextBox4.Text);
                drow[3] = this.dateTimePicker1.Text;             



                dataset.Tables["completed"].Rows.Add(drow);
                try
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                    sda.Update(dataset.Tables["completed"]);

                    MessageBox.Show("Order Completed !");
                    new Index().Show();
                    this.Hide();
                }
                catch (Exception i)
                {
                    MessageBox.Show(i.Message);
                }
            }
        }

        private void CompleteOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
