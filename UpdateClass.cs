using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRecord
{
    class UpdateClass
    {

        private string connstring = ConfigurationManager.ConnectionStrings["Customer"].ConnectionString;

        public string UpdateCustomer(Customer cst)
        {
            string msg = " ";
            SqlConnection con = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("UpdateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustID", SqlDbType.Int).Value = cst.CustID;
                cmd.Parameters.Add("@CustName", SqlDbType.VarChar, 50).Value = cst.CustName;
                cmd.Parameters.Add("@FatherName", SqlDbType.VarChar, 50).Value = cst.FatherName;
                cmd.Parameters.Add("@MotherName", SqlDbType.VarChar, 50).Value = cst.MotherName;             
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.VarChar,20).Value =cst.DatheOfBirth;
                cmd.Parameters.Add("@CellNO", SqlDbType.VarChar, 15).Value = cst.CellNO;
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 10).Value = cst.Gender;
                cmd.Parameters.Add("@Prmt_Address", SqlDbType.VarChar, 200).Value = cst.Address1;
                cmd.Parameters.Add("@Prst_Address", SqlDbType.VarChar, 200).Value = cst.Address2;
                cmd.Parameters.Add("@CustImage", SqlDbType.VarChar, 500).Value = cst.CustImage;

                con.Open();
                cmd.ExecuteNonQuery();

                msg = "Data successfully updated!";

            }
            catch (Exception)
            {
                msg = "Data is not successfully updated!";
            }
            finally
            {
                con.Close();
            }
            return msg;

        }

    }
}
