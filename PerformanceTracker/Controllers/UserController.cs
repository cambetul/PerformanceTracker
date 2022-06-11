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
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult UserDetail(int userId)
        {
            string sessionEmail = HttpContext.Session.GetString("useremail");
            if (sessionEmail != null)
            {
                PerformanceTrackerContext db = new PerformanceTrackerContext();
                ViewModels.UserView uv = new ViewModels.UserView();
                uv.UserId = userId;
                uv.User = db.Users.FirstOrDefault(u => u.Id == userId);
                uv.MemberedGroupCount = db.GroupMembers.Where(gm => gm.UserId == userId).ToList().Count;
                uv.OwnedGroupCount = db.Groups.Where(g => g.OwnerId == userId).ToList().Count;
                uv.MemberedTasks = db.TaskMembers.Where(tm => tm.UserId == userId).ToList();
                uv.Succeed = uv.MemberedTasks.Where(mt => mt.StatusId == 1).ToList().Count;
                uv.Failed = uv.MemberedTasks.Where(mt => mt.StatusId == 2).ToList().Count;
                uv.OnGoing = uv.MemberedTasks.Where(mt => mt.StatusId == 3).ToList().Count;
                uv.NotStarted = uv.MemberedTasks.Where(mt => mt.StatusId == 4).ToList().Count;
                return View(uv);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
    }
}
