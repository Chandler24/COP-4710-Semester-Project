using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Contracts;
using DatabaseConnection;

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
            return View();
        }

        public ActionResult CreateUniversity()
        {
            ViewBag.Title = "Create University";
            return View();
        }

        public ActionResult CreateRSO()
        {
            ViewBag.Title = "Create RSO";
            return View();
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
                bool result = accountConnection.SignIn(request);
                if (result == true)
                    viewName = "Home";
            }

            return RedirectToAction(viewName);
        }

        public ActionResult Home()
        {
            HomeModel model = new HomeModel();
            model.Events = new List<EventModel>();
            EventConnection eventConnection = new EventConnection();
            List<Events> events = eventConnection.GetEvents();
            model.Events = ConvertEvents(events);
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

        private SignupRequest ConvertSignUpModel(SignupModel input)
        {
            SignupRequest output = new SignupRequest()
            {
                FirstName = input.FirstName,
                LastName = input.LastName, 
                Password = input.Password,
                Username = input.Username
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
                    Date = e.Date,
                    Description = e.Description,
                    Month = e.Month,
                    Name = e.Name,
                    Rating = e.Rating
                };

                output.Add(m);
            }
            return output;
        }
    }
}
