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
            string viewName = "Login";

            if (ModelState.IsValid)
            {
                // Check the user's credentials against the database

                viewName = "LandingPage";
            }

            return View(viewName);
        }

        public ActionResult LandingPage()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
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
