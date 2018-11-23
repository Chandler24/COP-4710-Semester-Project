using Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class RsoConnection : IRsoConnection
    {
        public void SaveRso(SaveRsoRequest request)
        {
            ConnectionHelper conn = new ConnectionHelper();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Name", request.Name),
                new SqlParameter("@Description", request.Description)
            };

            int res = conn.ExecuteNonQuery("CreateRso", sqlParams);

            if (res > 0)
            {
                SqlParameter[] sqlParams2 = new SqlParameter[]
                {
                    new SqlParameter("@RsoName", request.Name),
                };
                int rsoId = -1;
                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetRsoId";
                    command.Connection = connection;
                    command.Parameters.AddRange(sqlParams2);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                rsoId = reader.GetInt32(0);
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

                if(rsoId != -1)
                {
                    SqlParameter[] sqlParams3 = new SqlParameter[]
                    {
                        new SqlParameter("@RsoId", rsoId),
                        new SqlParameter("@StudentEmail", request.AdminEmail),
                        new SqlParameter("@IsAdmin", 1)
                    };
                    conn.ExecuteNonQuery("AddMemberToRso", sqlParams3);
                    foreach (string m in request.Members)
                    {
                        SqlParameter[] sqlParams4 = new SqlParameter[]
                        {
                            new SqlParameter("@RsoId", rsoId),
                            new SqlParameter("@StudentEmail", m),
                            new SqlParameter("@IsAdmin", 0)
                        };

                        conn.ExecuteNonQuery("AddMemberToRso", sqlParams4);
                    }
                }
            }

        }

        public List<RegisteredStudentOrganization> GetAllRsos()
        {
            List<RegisteredStudentOrganization> response = new List<RegisteredStudentOrganization>();

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllRsos";
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            RegisteredStudentOrganization rso = new RegisteredStudentOrganization()
                            {
                                RsoId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2)
                            };

                            response.Add(rso);
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

        public bool CheckIfUserIsInRso(int userId, int rsoId)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@RsoId", rsoId)
            };

            bool result = false;
            
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CheckIfUserIsInRso";
                command.Parameters.AddRange(sqlParams);
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    result = true;
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }

        public void JoinRso(int rsoId, int userId)
        {
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@RsoId", rsoId)
            };

            ConnectionHelper conn = new ConnectionHelper();
            conn.ExecuteNonQuery("JoinRso", sqlParams);
        }
    }
}
