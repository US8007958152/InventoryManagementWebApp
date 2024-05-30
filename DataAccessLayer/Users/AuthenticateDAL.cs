using BusinessLogicLayer.Users;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Users
{
    public class AuthenticateDAL : IAuthenticate
    {
        private readonly string _inventoryDBConnString;
        public AuthenticateDAL(string connString)
        {
            _inventoryDBConnString = connString;
        }
        public int Validate(string userName, string password)
        {
            try
            {
                // SQL COnnection
                // Open COnnection
                // Sql Command --> SQL Query or stored procedure
                // Execute SQL
                using (SqlConnection con = new SqlConnection(_inventoryDBConnString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_ValidateUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@Password", password);

                        SqlParameter sqlParameter = new SqlParameter
                        {
                            ParameterName = "@StatusCode",
                            Direction = ParameterDirection.Output,
                            DbType = DbType.Int32
                        };
                        cmd.Parameters.Add(sqlParameter);


                        cmd.ExecuteNonQuery();
                        return Convert.ToInt32(cmd.Parameters["@StatusCode"].Value);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
