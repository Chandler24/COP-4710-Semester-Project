using Contracts;
using System;
using System.Collections.Generic;
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
    }
}
