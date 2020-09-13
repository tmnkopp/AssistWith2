using AssistWith.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AssistWith.Data
{
    public static class DbUtil
    {
       
        public static string ConnectionString()
        {
            var _config = ConfigurationHelper.GetConfiguration(Environment.CurrentDirectory);
            return _config.GetConnectionString("DefaultConnection");
        }
        public static string GetSaltById(int ProfileID)
        {
            SqlDataReader oReader;
            string result = "";
            var con = ConnectionString();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                SqlCommand oCmd = new SqlCommand($"SELECT PasswordSalt From Profiles WHERE ProfileID = @ProfileID", myConnection);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ProfileID";
                param.Value = ProfileID;
                oCmd.Parameters.Add(param); 
                myConnection.Open();
                using (oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        result = oReader[0].ToString();
                    }
                    myConnection.Close();
                }
            }
            return result;
        }
    }
}