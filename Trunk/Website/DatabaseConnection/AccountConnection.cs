using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DatabaseConnection
{
    public class AccountConnection : IAccountConnection
    {
        public void AddUser(SignupRequest request)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@FirstName", request.FirstName),
                new SqlParameter("@LastName", request.LastName),
                new SqlParameter("@Username", request.Username),
                new SqlParameter("Password", request.Password)
            };


            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlParams);
                command.CommandText = "AddUser";
                command.Connection = connection;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<UserType> GetUserTypes()
        {
            List<UserType> userTypes = new List<UserType>();

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUserTypes";
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserType usertype = new UserType();
                            usertype.Id = reader.GetInt32(0);
                            usertype.Description = reader.GetString(1);
                            userTypes.Add(usertype);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
            }

            return userTypes;
        }
    }
}
