using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Address_Book
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=chenna;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;

        int ID = 0;

        public Form1()
        {
            InitializeComponent();
            DisplayData();

        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("SELECT * FROM tbl_user", con);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void ClearData()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtHomeAddress.Text = "";
            txtMobileNumber.Text = "";
            txtTelephoneNumber.Text = "";
            txtEmailAddress.Text = "";
            ID = 0;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Written By: Mr. Chenna",
                "About This Program", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            txtFirstName.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != ""
                                        && txtHomeAddress.Text != "" && txtMobileNumber.Text != ""
                                        && txtTelephoneNumber.Text != "" && txtEmailAddress.Text != "")
            {
                cmd = new SqlCommand(
                    "INSERT INTO tbl_user(firstname,lastname,address,mobile,telephone,email) VALUES(@firstname,@lastname,@address,@mobile,@telephone,@email)",
                    con);
                con.Open();
                cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text.ToUpper());
                cmd.Parameters.AddWithValue("@lastname", txtLastName.Text.ToUpper());
                cmd.Parameters.AddWithValue("@address", txtHomeAddress.Text.ToUpper());
                cmd.Parameters.AddWithValue("@mobile", txtMobileNumber.Text.ToUpper());
                cmd.Parameters.AddWithValue("@telephone", txtTelephoneNumber.Text.ToUpper());
                cmd.Parameters.AddWithValue("@email", txtEmailAddress.Text.ToLower());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != ""
                                        && txtHomeAddress.Text != "" && txtMobileNumber.Text != ""
                                        && txtTelephoneNumber.Text != "" && txtEmailAddress.Text != "")
            {
                cmd = new SqlCommand(
                    "UPDATE tbl_user SET firstname=@firstname,lastname=@lastname,address=@address,mobile=@mobile,telephone=@telephone,email=@email WHERE id=@id",
                    con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text.ToUpper());
                cmd.Parameters.AddWithValue("@lastname", txtLastName.Text.ToUpper());
                cmd.Parameters.AddWithValue("@address", txtHomeAddress.Text.ToUpper());
                cmd.Parameters.AddWithValue("@mobile", txtMobileNumber.Text.ToUpper());
                cmd.Parameters.AddWithValue("@telephone", txtTelephoneNumber.Text.ToUpper());
                cmd.Parameters.AddWithValue("@email", txtEmailAddress.Text.ToLower());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtFirstName.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtLastName.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtHomeAddress.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMobileNumber.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtTelephoneNumber.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEmailAddress.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtHomeAddress.Text = "";
            txtMobileNumber.Text = "";
            txtTelephoneNumber.Text = "";
            txtEmailAddress.Text = "";
            txtFirstName.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("DELETE tbl_user WHERE id=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
