using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerRecord
{
    class ViewClass
    {
        private string connstring = ConfigurationManager.ConnectionStrings["Customer"].ConnectionString;
        public DataTable showrecord(string querry)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(querry, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
                else
                {

                    MessageBox.Show("No Records Were Found!!");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("No records were found!!");
            }

            finally
            {
                con.Close();
            }
            return dt;
        }



    }
}
