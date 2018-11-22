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
            ConnectionHelper conn = new ConnectionHelper();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@FirstName", request.FirstName),
                new SqlParameter("@LastName", request.LastName),
                new SqlParameter("@Username", request.Username),
                new SqlParameter("Password", request.Password),
                new SqlParameter("@UserType", request.UserType)
            };

            conn.ExecuteNonQuery("AddUser", sqlParams);
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

        public SignInResponse SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse()
            {
                UserId = -1,
                UserType = UserTypeEnum.NotValid
            };

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Username", request.Username),
            };

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SignIn";
                command.Connection = connection;
                command.Parameters.AddRange(sqlParams);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string password = reader.GetString(0);
                            if (password == request.Password)
                            {
                                response.UserId = reader.GetInt32(1);
                                int usertype = reader.GetInt32(2);
                                switch (usertype)
                                {
                                    case 0:
                                        response.UserType = UserTypeEnum.SuperAdmin;
                                        break;
                                    case 1:
                                        response.UserType = UserTypeEnum.Admin;
                                        break;
                                    case 2:
                                        response.UserType = UserTypeEnum.Student;
                                        break;
                                    default:
                                        response.UserType = UserTypeEnum.NotValid;
                                        break;
                                }
                            }
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
            return response;
        }
    }
}
