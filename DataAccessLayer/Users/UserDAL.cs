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
    public class UserDAL : IUser
    {
      private readonly  string _inventoryDBConnString;
        public UserDAL(string connString)
        {
            _inventoryDBConnString = connString;
        }
        public int Add(User user)
        {
            try
            {
                user.IsActive = true;                
                // SQL COnnection
                // Open COnnection
                // Sql Command --> SQL Query or stored procedure
                // Execute SQL
                using (SqlConnection con = new SqlConnection(_inventoryDBConnString))
                {
                    if(con.State == ConnectionState.Closed)
                        con.Open();
                    using(SqlCommand cmd = new SqlCommand("usp_AddUser",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserTypeId", user.UserTypeId);
                        cmd.Parameters.AddWithValue("@Name", user.Name);
                        cmd.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
                        cmd.Parameters.AddWithValue("@EmailId", user.EmailId);
                        cmd.Parameters.AddWithValue("@ProfileURL", user.ProfileURL);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        //cmd.Parameters.AddWithValue("@OTP", user.OTP);
                        //cmd.Parameters.AddWithValue("@OTPCreatedOn", user.OTPCreatedOn);
                        cmd.Parameters.AddWithValue("@CurrentAddress", user.CurrentAddress);
                        cmd.Parameters.AddWithValue("@PermanentAddress", user.PermanentAddress);
                        cmd.Parameters.AddWithValue("@CityId", user.CityId);
                        cmd.Parameters.AddWithValue("@StateId", user.StateId);
                        cmd.Parameters.AddWithValue("@CountryId", user.CountryId);
                        cmd.Parameters.AddWithValue("@ZipCode", user.ZipCode);
                        cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                        //cmd.Parameters.AddWithValue("@IsDeleted", user.IsDeleted);
                        cmd.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);

                        SqlParameter sqlParameter = new SqlParameter
                        {
                            ParameterName = "@StatusCode",
                            Direction = ParameterDirection.Output,
                            DbType=DbType.Int32
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

        public bool Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public UserProfile GetUserProfile(int userId)
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
                    using (SqlCommand cmd = new SqlCommand("usp_GetUserProfile", con))
                    {
                        UserProfile userProfile=null;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        // DML - CREATE DELETE UPDATE cmd.ExecuteNonQuery()
                        // SELECT - cmd.ExecuteReader()
                        // single - ExecuteSclar()
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                userProfile = new UserProfile()
                                {
                                    Id = Convert.ToInt32(sdr["Id"]),
                                    UserTypeId = Convert.ToInt32(sdr["UserTypeId"]),
                                    UserType = Convert.ToString(sdr["UserType"]),
                                    Name = Convert.ToString(sdr["Name"]),
                                    EmailId = Convert.ToString(sdr["EmailId"]),
                                    MobileNumber = Convert.ToString(sdr["MobileNumber"])
                                };
                            }
                            return userProfile;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public List<UserViewModel> GetUsers()
        {
            List<UserViewModel> users = new List<UserViewModel>();
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
                    using (SqlCommand cmd = new SqlCommand("usp_GetUsers", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using(SqlDataReader sdr=cmd.ExecuteReader())
                        {
                            while(sdr.Read())
                            {
                                users.Add(new UserViewModel
                                {
                                    Id = Convert.ToInt32(sdr["Id"]),
                                    Name = Convert.ToString(sdr["Name"]),
                                    UserType = Convert.ToString(sdr["Title"]),
                                    EmailId = Convert.ToString(sdr["EmailId"]),
                                    MobileNumber = Convert.ToString(sdr["MobileNumber"]),
                                    IsActive = Convert.ToBoolean(sdr["IsActive"]),
                                    IsDeleted = Convert.ToBoolean(sdr["IsDeleted"])
                                });
                            }
                        }

                    }
                    return users;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
