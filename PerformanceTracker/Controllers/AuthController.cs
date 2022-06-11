using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerformanceTracker.Models;
using PerformanceTracker.ViewModels;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PerformanceTracker.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ViewModels.RegisterModel rm) // rm = kullanıcıdan gelen
        {    // db tablolarda kayıtlı olan
            PerformanceTrackerContext db = new PerformanceTrackerContext();
            if (db.Users.Any(o => o.Email == rm.Email))
            {
                ViewBag.Error = "Already registered with this e-mail.";
                return View();
            }

            if (String.IsNullOrWhiteSpace(rm.FirstName) || String.IsNullOrWhiteSpace(rm.LastName) ||
               String.IsNullOrWhiteSpace(rm.Email) || String.IsNullOrWhiteSpace(rm.Password) ||
               String.IsNullOrWhiteSpace(rm.ConfirmPassword))
            {
                ViewBag.Error = "All fields must be filled.";
                return View();
            }

            string hashed1 = ViewModels.RegisterModel.ComputeSha256Hash(rm.Password);
            string hashed2 = ViewModels.RegisterModel.ComputeSha256Hash(rm.ConfirmPassword);
            if (hashed1 != hashed2)
            {
                ViewBag.Error = "The password confirmation does not match.";
                return View();
            }

            Models.User newUser = new Models.User();
            newUser.CreatedOn = DateTime.Now;
            newUser.ModifiedOn = DateTime.Now;
            newUser.Password = hashed1;
            newUser.FirstName = rm.FirstName;
            newUser.LastName = rm.LastName;
            newUser.Email = rm.Email;
            db.Users.Add(newUser);
            db.SaveChanges(); 
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ViewModels.RegisterModel rm)
        {
            PerformanceTrackerContext db = new PerformanceTrackerContext();

            if (String.IsNullOrWhiteSpace(rm.Email) || String.IsNullOrWhiteSpace(rm.Password))
            {
                ViewBag.Error = "All fields must be filled.";
                return View();
            }

            string hashed = ViewModels.RegisterModel.ComputeSha256Hash(rm.Password);
            if (db.Users.Any(o => o.Email == rm.Email && o.Password == hashed))
            {    // login yapılan yer
                int id = db.Users.FirstOrDefault(o => o.Email == rm.Email && o.Password == hashed).Id;
                HttpContext.Session.SetString("useremail", rm.Email);
                HttpContext.Session.SetInt32("userid", id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid e-mail or password.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("useremail");
            HttpContext.Session.Remove("userid");
            return RedirectToAction("Login");
        }
    }
}
