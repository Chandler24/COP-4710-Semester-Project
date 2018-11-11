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
    public class EventConnection : IEventConnection
    {
        public List<Events> GetEvents()
        {
            List<Events> events = new List<Events>();
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetEvents";
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Events e = new Events();
                            e.Name = reader.GetString(1);
                            e.Date = reader.GetDateTime(2);
                            switch (e.Date.Month)
                            {
                                case 1:
                                    e.Month = "Jan";
                                    break;
                                case 2:
                                    e.Month = "Feb";
                                    break;
                                case 3:
                                    e.Month = "Mar";
                                    break;
                                case 4:
                                    e.Month = "Apr";
                                    break;
                                case 5:
                                    e.Month = "May";
                                    break;
                                case 6:
                                    e.Month = "Jun";
                                    break;
                                case 7:
                                    e.Month = "Jul";
                                    break;
                                case 8:
                                    e.Month = "Aug";
                                    break;
                                case 9:
                                    e.Month = "Sep";
                                    break;
                                case 10:
                                    e.Month = "Oct";
                                    break;
                                case 11:
                                    e.Month = "Nov";
                                    break;
                                case 12:
                                    e.Month = "Dec";
                                    break;
                            }
                            e.Description = reader.GetString(3);
                            int rating = reader.GetInt32(4);
                            switch (rating)
                            {
                                case 0:
                                    e.Rating = RatingEnum.NotRated;
                                    break;
                                case 1:
                                    e.Rating = RatingEnum.OneStar;
                                    break;
                                case 2:
                                    e.Rating = RatingEnum.TwoStars;
                                    break;
                                case 3:
                                    e.Rating = RatingEnum.ThreeStars;
                                    break;
                                case 4:
                                    e.Rating = RatingEnum.FourStars;
                                    break;
                                case 5:
                                    e.Rating = RatingEnum.FiveStars;
                                    break;
                            }
                            events.Add(e);
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

            return events;
        }
    }
}
