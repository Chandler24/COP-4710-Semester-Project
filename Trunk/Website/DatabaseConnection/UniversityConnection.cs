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
    public class UniversityConnection : IUniversityConnection
    {
        public void AddUniversity(SaveUniversityRequest request)
        {
            ConnectionHelper conn = new ConnectionHelper();
            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Name", request.Name),
                new SqlParameter("@PrimaryAddress", request.PrimaryAddress),
                new SqlParameter("@SecondaryAddress", request.SecondaryAddress),
                new SqlParameter("@City", request.City),
                new SqlParameter("@State", request.State),
                new SqlParameter("@Zip", request.Zip),
                new SqlParameter("@NumberOfStudents", request.NumberOfStudents),
                new SqlParameter("@Description", request.Description)
            };

            conn.ExecuteNonQuery("AddUniversity", sqlParams);
        }

        public List<UniversityResponse> GetAllUniversities()
        {
            List<UniversityResponse> response = new List<UniversityResponse>();
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllUniversities";
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UniversityResponse u = new UniversityResponse()
                            {
                                Id = reader.GetInt32(0),
                                City = reader.GetString(1),
                                Description = reader.GetString(2),
                                Name = reader.GetString(3),
                                NumberOfStudents = reader.GetInt32(4),
                                PrimaryAddress = reader.GetString(5),
                                SecondaryAddress = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                State = reader.GetString(7),
                                Zip = reader.GetString(8)
                            };

                            response.Add(u);
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
