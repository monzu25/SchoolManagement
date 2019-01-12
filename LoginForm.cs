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
    public partial class LoginForm : Form
    {


        private string connstring = ConfigurationManager.ConnectionStrings["Customer"].ConnectionString;
        public LoginForm()
        {
            InitializeComponent();
        }


        //string adminID;
        private void loginbtn_Click(object sender, EventArgs e)
        {


            string user = userName.Text;
            string pass = password.Text;
            string userdb, passworddb;

            ReturnData rc = new ReturnData();
            userdb = rc.ScalarReturn("Select count(AdminID) from AdminStore where AdminName='" + user + "'");


            if (userdb.Equals("0"))
            {
                MessageBox.Show("The User Name Is Invalid");
            }
            else
            {
                passworddb = rc.ScalarReturn("select AdminPassword from Administrator where AdminName='" + user + "'");


                if (passworddb.Equals(pass))
                {

                    //adminID = rc.ScalarReturn("Select AdminID from Administrator where UserName='" + user + "'");
                    InsertForm f2 = new InsertForm();
                    f2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("This user Password is invlaid");
                }
            }


            HomePage hm = new HomePage();
            hm.Show();
            this.Hide();
        }
    }
}
