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
                            e.EventId = reader.GetInt32(0);
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

        public List<EventCategoryResponse> GetEventCategories()
        {
            List<EventCategoryResponse> response = new List<EventCategoryResponse>();
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetEventCategories";
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            EventCategoryResponse e = new EventCategoryResponse()
                            {
                                Id = reader.GetInt32(0),
                                Description = reader.GetString(1)
                            };
                          
                            response.Add(e);
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

        public void SaveEvent(SaveEventRequest request)
        {
            ConnectionHelper conn = new ConnectionHelper();

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Name", request.Name),
                new SqlParameter("@Type", request.Type),
                new SqlParameter("@Category", request.Category),
                new SqlParameter("@Description", request.Description), 
                new SqlParameter("@Date", request.Date),
                new SqlParameter("@Location", request.Location),
                new SqlParameter("@ContactPhone", request.ContactPhone),
                new SqlParameter("@ContactEmail", request.ContactEmail),
                new SqlParameter("@EventAdmin", request.EventAdmin),
                new SqlParameter("@HostUniversity", request.HostUniversity)
            };

            conn.ExecuteNonQuery("SaveEvent", sqlParams);
        }

        public List<EventTypeResponse> GetEventTypes()
        {
            List<EventTypeResponse> response = new List<EventTypeResponse>();
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetEventTypes";
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            EventTypeResponse e = new EventTypeResponse()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };

                            response.Add(e);
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

        public void AddComment(AddCommentRequest request)
        {
            ConnectionHelper conn = new ConnectionHelper();

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@UserId", request.UserId),
                new SqlParameter("@EventId", request.EventId),
                new SqlParameter("@Comment", request.Comment)
            };

            conn.ExecuteNonQuery("AddComment", sqlParams);
        }

        public List<EventComments> GetCommentsForEvent(int eventId)
        {
            List<EventComments> response = new List<EventComments>();
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlParameter[] sqlParams = new SqlParameter[]
                {
                    new SqlParameter("@EventId", eventId)
                };

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetCommentsForEvents";
                command.Parameters.AddRange(sqlParams);
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            EventComments e = new EventComments()
                            {
                                FirstName = reader.GetString(0),
                                LastName = reader.GetString(1),
                                Comment = reader.GetString(2),
                                CommentId = reader.GetInt32(3)
                            };

                            response.Add(e);
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

        public void EditComment(int commentId, string editedComment)
        {
            ConnectionHelper conn = new ConnectionHelper();

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("Id", commentId),
                new SqlParameter("EditedComment", editedComment)
            };

            conn.ExecuteNonQuery("EditComment", sqlParams);
        }

        public void DeleteComment(int commentId)
        {
            ConnectionHelper conn = new ConnectionHelper();

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("Id", commentId),
            };

            conn.ExecuteNonQuery("DeleteComment", sqlParams);
        }
    }
}
