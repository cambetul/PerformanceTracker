using Microsoft.AspNetCore.Mvc;
using PerformanceTracker.Models;
using PerformanceTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;



namespace PerformanceTracker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string sessionEmail = HttpContext.Session.GetString("useremail");
            if (sessionEmail != null)
            {
                PerformanceTrackerContext db = new PerformanceTrackerContext();
                ViewModels.HomeView userInfo = new ViewModels.HomeView();
                Models.User currentUser = db.Users.FirstOrDefault(x => x.Email == sessionEmail);
                int currentUserId = currentUser.Id;

                userInfo.Name = currentUser.FirstName;
                //owner olduğu grupları bul ve ekle
                List<Models.Group> ownedGroups = ownedGroups = db.Groups.Where(g => g.OwnerId == currentUserId).Select(w => w).ToList();
                userInfo.Groups.AddRange(ownedGroups);

                // yer aldığı grupları bul ve ekle
                List<Models.GroupMember> memberedGroupsIds = new List<Models.GroupMember>();
                memberedGroupsIds = db.GroupMembers
                    .Where(gm => gm.UserId == currentUserId).ToList();
                foreach (var g in memberedGroupsIds)
                {
                    userInfo.Groups.Add(db.Groups.FirstOrDefault(o => o.Id == g.GroupId));
                }

                // görevlendirildiği taskları bul ve listele
                List<Models.TaskMember> memberedTasksIds = new List<Models.TaskMember>();
                memberedTasksIds = db.TaskMembers
                    .Where(tm => tm.UserId == currentUserId).ToList();
                foreach (var item in memberedTasksIds)
                {
                    userInfo.Tasks.Add(db.Tasks.FirstOrDefault(t => t.Id == item.TaskId));
                }
                return View(userInfo);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        [HttpGet]
        public IActionResult SearchUser()
        {
            if (HttpContext.Session.GetString("useremail") != null)
            {
                PerformanceTrackerContext db = new PerformanceTrackerContext();
                SearchUserView suv = new SearchUserView();
                //suv.UserId = userId;
                suv.AllUsers = db.Users.ToList();
                return View(suv);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString("useremail") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
