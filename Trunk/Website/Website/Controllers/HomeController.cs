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

        public ActionResult Login(LoginModel model)
        {
            string actionName = "Login";
            if (ModelState.IsValid)
            {
                // Check the user's credentials against the database
                actionName = "Home";
            }

            return RedirectToAction(actionName);
        }

        public ActionResult Home()
        {
            HomeModel model = new HomeModel();
            model.Events = new List<EventModel>();

            EventModel eventOne = new EventModel();
            eventOne.Date = DateTime.Now.AddDays(2);
            eventOne.Rating = RatingEnum.FiveStars;
            eventOne.Name = "Testing Event 1";
            eventOne.Month = "Nov";
            eventOne.Description = "Test Event 1 Description";

            EventModel eventTwo = new EventModel();
            eventTwo.Date = DateTime.Now.AddDays(10);
            eventTwo.Rating = RatingEnum.FiveStars;
            eventTwo.Name = "Testing Event 2";
            eventTwo.Month = "Nov";
            eventTwo.Description = "Test Event 2 Description";

            model.Events.Add(eventOne);
            model.Events.Add(eventTwo);

            return View("LandingPage", model);
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
    }
}
