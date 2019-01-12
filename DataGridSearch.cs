using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerRecord
{
    public partial class DataGridSearch : Form
    {
        ViewClass vc = new ViewClass();
        string q;

        private string connstring = ConfigurationManager.ConnectionStrings["Customer"].ConnectionString;


        public DataGridSearch()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            q = "Select CustID as'Customer ID',CustName as'Customer Name',FatherName as'Father Name',MotherName as 'Mother Name',DateOfBirth as 'Birth Date',CellNO as 'Phone No',Gender as 'Gender', Prmt_Address as'Permanent Address', Prst_Address as 'Present Address' from Customer where CustID =" + textBox1.Text + "";
     
            showData.DataSource = vc.showrecord(q);


            ReturnData rc = new ReturnData();

            string imgQuery = rc.ScalarReturn("Select CustImage from Customer where CustID=" + textBox1.Text);
            if (imgQuery == " ")
            {
                pictureBox1.Image = Image.FromFile(@"C:\Users\Theen MONZU\Source\Repos\CustomerRecord\CustomerRecord\Images\unknown.jpg");
            }
            else
            {
                pictureBox1.Image = Image.FromFile(imgQuery);
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void DataGridSearch_Load(object sender, EventArgs e)
        {
            q = "Select CustID as'Customer ID',CustName as'Customer Name',FatherName as'Father Name',MotherName as 'Mother Name',DateOfBirth as 'Birth Date',CellNO as 'Phone No',Gender as 'Gender', Prmt_Address as'Permanent Address', Prst_Address as 'Present Address' from Customer";
            showData.DataSource = vc.showrecord(q);

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

            q = "Select CustID as'Customer ID',CustName as'Customer Name',FatherName as'Father Name',MotherName as 'Mother Name',DateOfBirth as 'Birth Date',CellNO as 'Phone No',Gender as 'Gender', Prmt_Address as'Permanent Address', Prst_Address as 'Present Address' from Customer where CustName like '" + textBox2.Text + "%' or FatherName Like '"+textBox2.Text+ "%' or MotherName Like '" + textBox2.Text + "%'";
            showData.DataSource = vc.showrecord(q);

            //string d = " SELECT * FROM Staff Where StaffName like '%" & TextBox1.Text & "%' or Department like '%" & TextBox2.Text & "%'";
        }



        private void showData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ReturnData rc = new ReturnData();
            string cId;
            if (showData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {             
                 showData.CurrentRow.Selected = true;
                cId =showData.Rows[e.RowIndex].Cells["Customer ID"].FormattedValue.ToString();


                string imgQuery = rc.ScalarReturn("Select CustImage from Customer where CustID=" + Convert.ToInt32(cId));
                if (imgQuery == " ")
                {
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Theen MONZU\Source\Repos\CustomerRecord\CustomerRecord\Images\unknown.jpg");
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(imgQuery);
                }
            }
            else
            {
                MessageBox.Show("Selected Row Has not Record");
            }
            
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }
    }
}
