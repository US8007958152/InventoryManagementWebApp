using BusinessLogicLayer.Commons;
using Entities.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Commons
{
    public class CommonDAL : ICommon
    {
        private readonly string _inventoryDBConnString;
        public CommonDAL(string connString)
        {
            _inventoryDBConnString = connString;
        }

        public List<Dropdown> GetCityDropdown(int stateId)
        {
            try
            {
                List<Dropdown> dropdownList = new List<Dropdown>();
                using (SqlConnection con = new SqlConnection(_inventoryDBConnString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetCityDropdown", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StateId", stateId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dropdownList.Add(new Dropdown
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Title = Convert.ToString(reader["Name"])
                                });
                            }
                        }
                    }
                }
                return dropdownList;
            }
            catch
            {
                throw;
            }
        }

        public List<Dropdown> GetCountryDropdown()
        {
            try
            {
                List<Dropdown> dropdownList = new List<Dropdown>();
                using (SqlConnection con = new SqlConnection(_inventoryDBConnString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetCountryDropdown", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dropdownList.Add(new Dropdown
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Title = Convert.ToString(reader["Name"])
                                });
                            }
                        }
                    }
                }
                return dropdownList;
            }
            catch
            {
                throw;
            }
        }

        public List<Dropdown> GetStateDropdown(int countryId)
        {
            try
            {
                List<Dropdown> dropdownList = new List<Dropdown>();
                using (SqlConnection con = new SqlConnection(_inventoryDBConnString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetStateDropdown", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CountryId", countryId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dropdownList.Add(new Dropdown
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Title = Convert.ToString(reader["Name"])
                                });
                            }
                        }
                    }
                }
                return dropdownList;
            }
            catch
            {
                throw;
            }
        }

        public List<Dropdown> GetUserTypeDropdown()
        {
            try
            {
               List<Dropdown> dropdownList = new List<Dropdown>();
                using (SqlConnection con = new SqlConnection(_inventoryDBConnString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetUserTypeDropdown", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                       using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                dropdownList.Add(new Dropdown
                                {
                                  Id = Convert.ToInt32(reader["Id"]),
                                  Title= Convert.ToString(reader["Title"])
                                });
                            }
                        }
                    }
                }
                return dropdownList;
            }
            catch
            {
                throw;
            }           
        }
    }
}
