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

namespace CustomerRecord
{
    public partial class InsertForm : Form
    {
        private string connstring = ConfigurationManager.ConnectionStrings["Customer"].ConnectionString;


        string gender;
        public InsertForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gen = getGender();

            try
            {
                SqlConnection con = new SqlConnection(connstring);               
            SqlCommand cmd = new SqlCommand("InsertCustomer", con);

             
                cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustName", custName.Text);
            cmd.Parameters.AddWithValue("@FatherName", fName.Text);
            cmd.Parameters.AddWithValue("@MotherName", mName.Text);
            cmd.Parameters.AddWithValue("@DateOfBirth", dob.Text);
            cmd.Parameters.AddWithValue("@Gender", gen);
            cmd.Parameters.AddWithValue("@Prmt_Address", address1.Text);
            cmd.Parameters.AddWithValue("@Prst_Address ", address2.Text);
            cmd.Parameters.AddWithValue("@CellNO", cellNo.Text);
            cmd.Parameters.AddWithValue("@CustImage", imagePath.Text);
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();



            }
            catch
            {
                MessageBox.Show("Data Inserted Successfully !!");
            }
            finally
            {
                MessageBox.Show("Data Inserted Successfully !!");
            }
           ClearFiels();
        }

        public string getGender()
        {
            if (male.Checked == true)
            {
                gender = "Male";
            }
            else if (female.Checked == true)
            {
                gender = "Female";

            }
            else
            {
                MessageBox.Show("Please Select A Gender");

            }
            return gender;

        }

        public void ClearFiels()
        {
            custName.Text = " ";
            fName.Text = " ";
            mName.Text = " ";
            dob.Text = " ";
            address1.Text = " ";
            address2.Text = " ";
            male.Checked = false;
            female.Checked = false;
            cellNo.Text = " ";


        }

        private void picBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picBox.Image = new Bitmap(open.FileName);
                imagePath.Text = open.FileName;
            }

        }

        private void uploadbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picBox.Image = new Bitmap(open.FileName);
                imagePath.Text = open.FileName;
            }
        }
    }
}

