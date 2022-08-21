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
    public partial class placeOrder : Form
    {
        public placeOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Index().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Connection
            string connenctionString = ConfigurationManager.ConnectionStrings["cAString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connenctionString);

            //Command (SQL)
            SqlCommand command = new SqlCommand("select * from custOrder", connection);

            //Definig dataset and dataAdapter;
            DataSet dataset = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(dataset); //filling dataset using adapter.
            dataset.Tables[0].TableName = "custOrder";

            DataRow drow = dataset.Tables["custOrder"].NewRow();

            //Row index finding
            int lastRowIndex = 0;
            foreach (DataRow row in dataset.Tables["custOrder"].Rows)
            {
                if (row[0].ToString() == this.maskedTextBox1.Text)
                {
                    lastRowIndex = (int)dataset.Tables["custOrder"].Rows.IndexOf(row);
                    break;
                }
            }

            if ((string)dataset.Tables[0].Rows[lastRowIndex][0] == this.maskedTextBox1.Text)
            {
                MessageBox.Show("Item Already Exist !");
            }
            else
            {
                drow[0] = this.maskedTextBox1.Text;
                drow[1] = this.dateTimePicker1.Text;
                drow[2] = this.dateTimePicker2.Text;
                drow[3] = Convert.ToDecimal(this.maskedTextBox2.Text);
                drow[4] = Convert.ToDecimal(this.maskedTextBox3.Text);
                drow[5] = Convert.ToDecimal(this.maskedTextBox4.Text);
                drow[6] = Convert.ToDecimal(this.maskedTextBox5.Text);
                drow[7] = Convert.ToDecimal(this.maskedTextBox6.Text);
                drow[8] = Convert.ToDecimal(this.maskedTextBox7.Text);
                drow[9] = Convert.ToDecimal(this.maskedTextBox8.Text);
                drow[10] = Convert.ToDecimal(this.maskedTextBox9.Text);
                drow[11] = Convert.ToInt32(this.checkBox1.Checked);
                drow[12] = Convert.ToInt32(this.checkBox2.Checked);
                drow[13] = Convert.ToInt32(this.checkBox3.Checked);
                drow[14] = Convert.ToInt32(this.checkBox4.Checked);
                drow[15] = Convert.ToInt32(this.checkBox5.Checked);
                drow[16] = Convert.ToInt32(this.checkBox6.Checked);
                drow[17] = Convert.ToInt32(this.checkBox7.Checked);
                drow[18] = Convert.ToInt32(this.checkBox8.Checked);
                drow[19] = Convert.ToInt32(this.checkBox9.Checked);
                drow[20] = Convert.ToInt32(this.checkBox10.Checked);
                drow[21] = Convert.ToInt32(this.checkBox11.Checked);
                drow[22] = Convert.ToInt32(this.checkBox12.Checked);
                drow[23] = Convert.ToInt32(this.checkBox13.Checked);
                drow[24] = Convert.ToInt32(this.checkBox14.Checked);
                drow[25] = Convert.ToInt32(this.checkBox15.Checked);

                
                dataset.Tables["custOrder"].Rows.Add(drow);
                try
                {
                    SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                    sda.Update(dataset.Tables["custOrder"]);

                    new Payments().Show();
                    this.Hide();
                }
                catch (Exception i)
                {
                    MessageBox.Show(i.Message);
                }
            }
        }

        private void placeOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
