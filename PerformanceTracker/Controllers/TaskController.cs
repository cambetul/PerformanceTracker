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
    public class TaskController : Controller
    {
        [HttpGet]
        public IActionResult TaskDetail(int taskId)
        {
            string sessionEmail = HttpContext.Session.GetString("useremail");
            if (sessionEmail != null) // if user logged in
            {
                PerformanceTrackerContext db = new PerformanceTrackerContext();
                Models.Task detailedTask = db.Tasks
                    .Include(t => t.Group)
                    .FirstOrDefault(t => t.Id == taskId);
                ViewModels.TaskView tv = new TaskView();
                tv.Content = detailedTask.Content;
                tv.Explanation = detailedTask.Explanation;
                tv.DueDate = detailedTask.DueDate;
                tv.StartDate = detailedTask.StartDate;
                tv.GroupId = detailedTask.GroupId;
                tv.TaskId = taskId;
                tv.TaskMembers = db.TaskMembers
                    .Include(tm => tm.User)
                    .Include(tm => tm.Status)
                    .Where(tm => tm.TaskId == taskId).ToList();
                foreach (var item in tv.TaskMembers)
                {
                    if (item.Task.DueDate <= DateTime.Now)
                    {
                        item.StatusId = 2;
                    }
                    else if (item.Task.StartDate <= DateTime.Now && item.StatusId != 1)
                    {
                        item.StatusId = 3;
                    }
                    item.Status = db.Statuses.FirstOrDefault(s => s.Id == item.StatusId);
                    db.SaveChanges();
                }
                return View(tv);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        [HttpPost]
        public IActionResult CompleteTask(ViewModels.TaskView posted)
        {
            var sessionId = HttpContext.Session.GetInt32("userid");
            if (sessionId != null) // if user logged in
            {
                PerformanceTrackerContext db = new PerformanceTrackerContext();
                var taskMember = db.TaskMembers
                    .Include(tm => tm.Status)
                    .SingleOrDefault(tm => tm.TaskId == posted.TaskId && tm.UserId == sessionId);
                if (taskMember != null)
                {
                    taskMember.StatusId = 1;
                    taskMember.Status = db.Statuses.FirstOrDefault(s => s.Id == 1);
                    db.SaveChanges();
                }
                return RedirectToAction("TaskDetail", new { taskId = posted.TaskId });
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
    }
}
