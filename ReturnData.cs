using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRecord
{
    class ReturnData
    {
        private string connstring = ConfigurationManager.ConnectionStrings["Customer"].ConnectionString;


        public string ScalarReturn(string q)
        {
            string s = " ";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(q, con);
                s = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                s = " ";

            }

            return s;

        }



    }
}
