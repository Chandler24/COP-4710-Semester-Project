using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Contracts;
using DatabaseConnection;
using System.Threading.Tasks;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Login";
            return View("Login");
        }

        public ActionResult CreateEvent()
        {
            ViewBag.Title = "Create Event";

            CreateEventModel model = new CreateEventModel();

            UniversityConnection conn = new UniversityConnection();
            EventConnection econn = new EventConnection();

            List<UniversityResponse> response1 = conn.GetAllUniversities();
            List<EventCategoryResponse> response2 = econn.GetEventCategories();
            List<EventTypeResponse> response3 = econn.GetEventTypes();

            model.Universities = ConvertUniversityResponse(response1);
            model.EventCategories = ConvertEventCategoryResponse(response2);
            model.EventTypes = ConvertEventTypeResponse(response3);

            return View(model);
        }

        public ActionResult CreateUniversity()
        {
            ViewBag.Title = "Create University";
            return View();
        }

        public ActionResult JoinRSO()
        {
            ViewBag.Title = "Join RSO";
            RsoConnection conn = new RsoConnection();
            JoinRsoModel model = new JoinRsoModel();
            List<RegisteredStudentOrganization> rsos = conn.GetAllRsos();
            model.RegisteredStudentOrganizations = ConvertRsos(rsos);
            return View(model);
        }

        public ActionResult CreateRSO()
        {
            ViewBag.Title = "Create RSO";
            CreateRsoModel model = new CreateRsoModel();
            UniversityConnection conn = new UniversityConnection();
            List<UniversityResponse> uni = conn.GetAllUniversities();
            model.Universities = ConvertUniversityResponse(uni);
            return View(model);
        }

        public ActionResult Login(LoginModel model)
        {
            string viewName = "Index";
            if (ModelState.IsValid)
            {
                // Check the user's credentials against the database
                AccountConnection accountConnection = new AccountConnection();
                SignInRequest request = new SignInRequest()
                {
                    Username = model.Username,
                    Password = model.Password
                };
                SignInResponse response = accountConnection.SignIn(request);
                if (response.UserId != -1)
                {
                    // Redirect the user to home and store the user id as a session variable. Helps for account tracking.
                    viewName = "Home";
                    Session["UserId"] = response.UserId;
                    Session["UserType"] = response.UserType;
                    Session["Username"] = model.Username;
                }
            }

            return RedirectToAction(viewName);
        }

        public ActionResult Home()
        {
            HomeModel model = new HomeModel();
            model.Events = new List<EventModel>();
            EventConnection eventConnection = new EventConnection();
            List<Events> events = eventConnection.GetEvents(0);
            model.Events = ConvertEvents(events);
            List<EventTypeResponse> eventTypes = eventConnection.GetEventTypes();
            model.EventTypes = ConvertEventTypeResponse(eventTypes);
            return View(model);
        }

        public ActionResult Signup()
        {
            SignupModel model = new SignupModel();
            AccountConnection accountConnection = new AccountConnection();
            model.UserTypes = accountConnection.GetUserTypes();
            return View(model);
        }

        public ActionResult SubmitRegistration(SignupModel model)
        {
            string viewName = "Signup";
            AccountConnection accountConnection = new AccountConnection();

            if (ModelState.IsValid)
            {
                SignupRequest request = ConvertSignUpModel(model);
                accountConnection.AddUser(request);
                viewName = "Login";
            }

            return View(viewName);
        }

        public ActionResult AddUniversity(UniversityModel model)
        {
            UniversityConnection connection = new UniversityConnection();
            SaveUniversityRequest request = new SaveUniversityRequest()
            {
                City = model.City,
                Description = model.Description,
                Name = model.Name,
                NumberOfStudents = model.NumberOfStudents,
                PrimaryAddress = model.PrimaryAddress,
                SecondaryAddress = model.SecondaryAddress,
                State = model.State,
                Zip = model.Zip
            };

            connection.AddUniversity(request);
            return View();
        }

        public ActionResult AddEvent(CreateEventModel model)
        {
            SaveEventRequest request = PrepareSaveEventRequest(model);
            EventConnection conn = new EventConnection();
            conn.SaveEvent(request);

            return RedirectToAction("Home");
        }

        [HttpPost]
        public bool AddComment(int eventId, string comment)
        {
            try
            {
                if (string.IsNullOrEmpty(comment))
                    return false;

                int userId = (int)Session["UserId"];
                AddCommentRequest request = new AddCommentRequest()
                {
                    UserId = userId,
                    EventId = eventId,
                    Comment = comment
                };

                EventConnection conn = new EventConnection();
                conn.AddComment(request);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public bool EditComment(int commentId, string editedComment)
        {
            try
            {
                EventConnection conn = new EventConnection();
                conn.EditComment(commentId, editedComment);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        public bool DeleteComment(int commentId)
        {
            try
            {
                EventConnection conn = new EventConnection();
                conn.DeleteComment(commentId);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        public JsonResult GetEventComments(int eventId)
        {
            EventConnection conn = new EventConnection();
            List<EventComments> response = conn.GetCommentsForEvent(eventId);
            List<EventCommentModel> comments = ConvertEventComments(response, eventId);
            return Json(comments);
        }

        [HttpPost]
        public ActionResult AddRso(CreateRsoModel model)
        {
            SaveRsoRequest request = PrepareSaveRsoRequest(model);
            RsoConnection conn = new RsoConnection();
            conn.SaveRso(request);
            return RedirectToAction("Home");
        }

        [HttpPost]
        public JsonResult JoinNewRso(int rsoId)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            RsoConnection conn = new RsoConnection();
            bool userInRso = conn.CheckIfUserIsInRso(userId, rsoId);

            if (userInRso)
            {
                return Json("You've already joined this Rso!");
            }

            conn.JoinRso(rsoId, userId);

            return Json("Success! You've joined the RSO!");
        }

        [HttpPost]
        public PartialViewResult FilterEvents(int eventType)
        {
            HomeModel model = new HomeModel();
            model.Events = new List<EventModel>();
            EventConnection eventConnection = new EventConnection();
            List<Events> events = eventConnection.GetEvents(eventType);
            model.Events = ConvertEvents(events);
            return PartialView("_Events", model);
        }

        // Private conversion methods
        private SignupRequest ConvertSignUpModel(SignupModel input)
        {
            SignupRequest output = new SignupRequest()
            {
                FirstName = input.FirstName,
                LastName = input.LastName, 
                Password = input.Password,
                Username = input.Username,
                UserType = input.SelectedUserType
            };

            return output;
        }

        private List<EventModel> ConvertEvents(List<Events> input)
        {
            List<EventModel> output = new List<EventModel>();
            foreach(Events e in input)
            {
                EventModel m = new EventModel
                {
                    EventId = e.EventId,
                    Date = e.Date,
                    Description = e.Description,
                    Month = e.Month,
                    Name = e.Name,
                    Rating = e.Rating
                };

                output.Add(m);
            }

            output = output.OrderBy(m => m.Date).ToList();

            return output;
        }

        private List<University> ConvertUniversityResponse(List<UniversityResponse> input)
        {
            List<University> output = new List<University>();

            foreach (UniversityResponse u in input)
            {
                University uni = new University()
                {
                    Id = u.Id,
                    Name = u.Name
                };
                output.Add(uni);
            }

            return output;
        }

        private List<EventCategory> ConvertEventCategoryResponse(List<EventCategoryResponse> input)
        {
            List<EventCategory> output = new List<EventCategory>();

            foreach (EventCategoryResponse e in input)
            {
                EventCategory eve = new EventCategory()
                {
                    Id = e.Id,
                    Name = e.Description
                };
                output.Add(eve);
            }

            return output;
        }

        private SaveEventRequest PrepareSaveEventRequest(CreateEventModel model)
        {
            string date = model.Date + " " + model.StartTime;
            int userId = Convert.ToInt32(Session["UserId"]);

            SaveEventRequest request = new SaveEventRequest()
            {
                Category = model.SelectedCategory,
                ContactEmail = model.ContactEmail,
                ContactPhone = model.ContactPhone,
                Date = date,
                Description = model.Description,
                EventAdmin = userId,
                HostUniversity = model.SelectedUniversity,
                Location = 1,
                Name = model.Name,
                Type = model.SelectedEventType
            };

            return request;
        }

        private List<EventType> ConvertEventTypeResponse(List<EventTypeResponse> input)
        {
            List<EventType> output = new List<EventType>();

            foreach (EventTypeResponse e in input)
            {
                EventType type = new EventType()
                {
                    Id = e.Id,
                    Name = e.Name
                };

                output.Add(type);
            }

            return output;
        }

        private List<EventCommentModel> ConvertEventComments(List<EventComments> input, int eventId)
        {
            List<EventCommentModel> output = new List<EventCommentModel>();

            foreach (EventComments e in input)
            {
                EventCommentModel m = new EventCommentModel()
                {
                    Comment = e.Comment,
                    Name = e.FirstName + " " + e.LastName,
                    CommentId = e.CommentId,
                    EventId = eventId
                };

                output.Add(m);
            }

            return output;
        }

        private SaveRsoRequest PrepareSaveRsoRequest(CreateRsoModel model)
        {
            string username = Session["Username"].ToString();
            SaveRsoRequest request = new SaveRsoRequest()
            {
                AdminEmail = username,
                Description = model.Description,
                Name = model.Name,
                University = model.SelectedUniversity
            };

            if (ValidateMembers(model))
            {
                request.Members = new List<string>();
                request.Members.Add(model.Member1);
                request.Members.Add(model.Member2);
                request.Members.Add(model.Member3);
                request.Members.Add(model.Member4);
                request.Members.Add(model.Member5);
            }

            return request;
        }

        private bool ValidateMembers(CreateRsoModel model)
        {
            bool result = true;

            if (!string.IsNullOrEmpty(model.Member1) && !string.IsNullOrEmpty(model.Member2) && !string.IsNullOrEmpty(model.Member3) && !string.IsNullOrEmpty(model.Member4) && !string.IsNullOrEmpty(model.Member5))
            {
                string emailDomain = model.Member1.Substring(model.Member1.LastIndexOf('@') + 1);

                if (model.Member2.Contains(emailDomain) && model.Member3.Contains(emailDomain) && model.Member4.Contains(emailDomain) && model.Member5.Contains(emailDomain))
                    result = true;
                else
                    result = false;
            }
            else
                result = false;

            return result;
        }

        private List<Rso> ConvertRsos(List<RegisteredStudentOrganization> input)
        {
            List<Rso> output = new List<Rso>();
            foreach(RegisteredStudentOrganization r in input)
            {
                Rso rso = new Rso()
                {
                    Id = r.RsoId,
                    Description = r.Description,
                    Name = r.Name
                };

                output.Add(rso);
            }
            return output;
        }
    }
}
