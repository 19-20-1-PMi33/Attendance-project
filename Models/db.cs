using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Attendance.Models;

namespace Attendance.Models
{
    public class db
    {
        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=modeldb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public int LoginCheck(User user)
        {
            SqlCommand command = new SqlCommand("sp_login", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Us_id", user.Id);
            command.Parameters.AddWithValue("@Us_Password", user.Password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = System.Data.SqlDbType.Bit;
            oblogin.Direction = System.Data.ParameterDirection.Output;
            command.Parameters.Add(oblogin);
            connection.Open();
            command.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            connection.Close();
            return res;
        }
    }
}
