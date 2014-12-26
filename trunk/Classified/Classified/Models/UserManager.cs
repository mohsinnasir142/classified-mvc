using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;

namespace Classified.Models
{
    public class UserManager
    {
        SqlConnection connection;

        public SqlConnection getconnection(SqlConnection connection)
        {
            try
            {
                connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                connection.Open();
                return connection;
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
                return null;
            }
        }

        public void registerUser(RegisterModel model)
        {
            try
            {
                connection = getconnection(new SqlConnection());
                if (connection != null)
                {
                    string query = "insert into personal_info(userName,firstName,lastName,email,password,phoneNo,DateAdded,activated,accountType) values('" + model.UserName + "','" + model.FirstName + "','" + model.LastName + "','" + model.EmailAddress + "','" + model.Password + "','" + model.Mobile + "','" + model.DateAdded + "',1,'" + model.Role + "')";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public UserModel getUserByUsername(string userName)
        {
            UserModel model = new UserModel();
            try
            {
                connection = getconnection(new SqlConnection());
                if (connection != null)
                {
                    string query = "select * from personal_info where(userName = '" + userName + "')";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader sdr = command.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            model.UserName = sdr["userName"].ToString();
                            model.Password = sdr["password"].ToString();
                            model.FirstName = sdr["firstName"].ToString();
                            model.LastName = sdr["lastName"].ToString();
                            model.EmailAddress = sdr["email"].ToString();
                            model.Mobile = sdr["phoneNo"].ToString();
                            model.Address = sdr["address"].ToString();
                            model.City = sdr["city"].ToString();
                            model.Country = sdr["country"].ToString();
                            model.Longitude = sdr["longitude"].ToString();
                            model.Latitude = sdr["latitude"].ToString();
                            model.Other = sdr["other"].ToString();
                        }
                    }
                    return model;
                }
                return model;
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
                return model;
            }
            finally
            {
                connection.Close();
            }
        }

        public Boolean updateUserByUsername(UserModel model)
        {
            try
            {
                connection = getconnection(new SqlConnection());
                if (connection != null)
                {
                    string query = "update personal_info set firstName = '" + model.FirstName + "',lastName = '" + model.LastName + "',email = '" + model.EmailAddress + "',password = '" + model.Password + "',phoneNo = '" + model.Mobile + "', Address = '" + model.Address + "', City = '" + model.City + "',Country='" + model.Country + "',Longitude='" + model.Longitude + "',Latitude = '" + model.Latitude + "',ProfilePic = '" + model.ProfilePic + "',DateEdited = '" + model.DateEdited + "',Other = '" + model.Other + "' where userName = '" + model.UserName + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    return true;
                }
                return false;
            }
            catch (SqlException e)
            {
                Console.Write(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<SelectListItem> getAllCities()
        {
            connection = getconnection(new SqlConnection());
            string query = "select tagValue as city from extra where tagName = 'city' ";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<SelectListItem> items = new List<SelectListItem>();
            while (reader.Read())
            {
                items.Add(new SelectListItem { Text = reader["city"].ToString(), Value = reader["city"].ToString() });
            }
            return items;
        }
        public List<SelectListItem> getWarranty()
        {
            connection = getconnection(new SqlConnection());
            string query = "select tagValue as warranty from extra where tagName = 'warranty' ";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<SelectListItem> items = new List<SelectListItem>();
            while (reader.Read())
            {
                items.Add(new SelectListItem { Text = reader["warranty"].ToString(), Value = reader["warranty"].ToString() });
            }
            return items;
        }
        public List<SelectListItem> getUserType()
        {
            connection = getconnection(new SqlConnection());
            string query = "select tagValue as userType from extra where tagName = 'userType' ";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<SelectListItem> items = new List<SelectListItem>();
            while (reader.Read())
            {
                items.Add(new SelectListItem { Text = reader["userType"].ToString(), Value = reader["userType"].ToString() });
            }
            return items;
        }
        public List<SelectListItem> getAdType()
        {
            connection = getconnection(new SqlConnection());
            string query = "select tagValue as adType from extra where tagName = 'adType' ";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<SelectListItem> items = new List<SelectListItem>();
            while (reader.Read())
            {
                items.Add(new SelectListItem { Text = reader["adType"].ToString(), Value = reader["adType"].ToString() });
            }
            return items;
        }
        public List<SelectListItem> getSubCategories(string categoryName)
        {
            connection = getconnection(new SqlConnection());
            string query = "select subcategory from category where category = '" + categoryName + "' ";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<SelectListItem> items = new List<SelectListItem>();
            while (reader.Read())
            {
                items.Add(new SelectListItem { Text = reader["subcategory"].ToString(), Value = reader["subcategory"].ToString() });
            }
            return items;
        }
        public DataTable getPersonalInformation(string username)
        {
                DataTable dt = null;
                connection = getconnection(new SqlConnection());
                if (connection != null)
                {
                    string query = "select * from personal_info where userName = '" + username + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;

                }
             
                return dt;
        }

    }
}