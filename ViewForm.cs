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
    public partial class ViewForm : Form
    {

        //string q;
        private string connstring = ConfigurationManager.ConnectionStrings["Customer"].ConnectionString;

        public ViewForm()
        {
            InitializeComponent();
        }

        private void searchbyID_KeyUp(object sender, KeyEventArgs e)
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



            SqlConnection connection = new SqlConnection(connstring);

            string sq = "Select CustName,FatherName,MotherName,DateOfBirth,CellNO,Gender,Prmt_Address,Prst_Address,CustImage from Customer where CustID="+searchbyID.Text+"";

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sq, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    custName.Text = reader.GetValue(0).ToString();
                    fName.Text = reader.GetValue(1).ToString();
                    mName.Text = reader.GetValue(2).ToString();
                    dob.Text = reader.GetValue(3).ToString();
                    cellNo.Text = reader.GetValue(4).ToString();
                    address1.Text = reader.GetValue(6).ToString();
                    address2.Text = reader.GetValue(7).ToString();
                    imagePath.Text = reader.GetValue(8).ToString();
                    picName.Text = reader.GetValue(0).ToString();



                    if (reader.GetValue(5).ToString().Equals("male"))
                    {
                        male.Checked = true;
                    }
                    else
                    {
                        female.Checked = true;
                    }




             

                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Record Not Found !");
            }


            ReturnData rc = new ReturnData();
            string imgQuery = rc.ScalarReturn("Select CustImage from Customer where CustID=" + searchbyID.Text);
            if (imgQuery == " ")
            {
                picBox.Image = Image.FromFile(@"C:\Users\Theen MONZU\Source\Repos\CustomerRecord\CustomerRecord\Images\unknown.jpg");
            }
            else
            {
                picBox.Image = Image.FromFile(imgQuery);
            }
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button1_Click(object sender, EventArgs e)
        {


            Customer cst = new Customer();
            cst.CustName = custName.Text;
            cst.FatherName = fName.Text;
            cst.MotherName = mName.Text;
            cst.DatheOfBirth = dob.Text;
            cst.CellNO = cellNo.Text;
       
            cst.Address1 = address1.Text;
            cst.Address2 = address2.Text;
            if (male.Checked == true)
            {
                cst.Gender = "male";
            }
            else
            {
                cst.Gender = "female";
            }

            cst.CustImage = imagePath.Text;
            //cst.Address1 = address1.Text;
            cst.CustID = Convert.ToInt32(searchbyID.Text);

            UpdateClass updt = new UpdateClass();
            string msg = updt.UpdateCustomer(cst);
            MessageBox.Show(msg);
            ClearFields();



        }


        public void ClearFields()
        {
            searchbyID.Text = " ";
            custName.Text = " ";
            fName.Text = " ";
            mName.Text = " ";
            dob.Text = " ";
            address1.Text = " ";
            address2.Text = " ";
            male.Checked = false;
            female.Checked = false;
            cellNo.Text = " ";
            picBox.Image = null;
            picName.Text = " ";
            imagePath.Text = " ";

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
