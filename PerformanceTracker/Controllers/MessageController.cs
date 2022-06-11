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
    public class MessageController : Controller
    {
        [HttpGet]
        public IActionResult MessageBoard(int messageTitleId)
        {
            string sessionEmail = HttpContext.Session.GetString("useremail");
            if (sessionEmail != null)
            {
                PerformanceTrackerContext db = new PerformanceTrackerContext();
                ViewModels.MessageBoardView mbv = new MessageBoardView();
                mbv.MessageTitleId = messageTitleId;
                mbv.GroupId = db.MessageTitles.FirstOrDefault(mt => mt.Id == messageTitleId).GroupId;
                mbv.AllMessages.AddRange(db.Messages
                    .Include(m => m.User)
                    .Where(m => m.TitleId == messageTitleId)
                    .OrderBy(m => m.Time).ToList());
                mbv.Title = db.MessageTitles.FirstOrDefault(mt => mt.Id == messageTitleId).Title;
                return View(mbv);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        [HttpPost]
        public IActionResult SendMessage(MessageBoardView posted)
        {
            string sessionEmail = HttpContext.Session.GetString("useremail");
            if (sessionEmail != null)
            {
                PerformanceTrackerContext db = new PerformanceTrackerContext();
                if (!string.IsNullOrWhiteSpace(posted.NewMessage))
                {
                    Models.Message newMes = new Message();
                    newMes.Time = DateTime.Now;
                    newMes.Title = db.MessageTitles
                        .FirstOrDefault(mt => mt.Id == posted.MessageTitleId);
                    newMes.TitleId = posted.MessageTitleId;
                    User currentUser = db.Users
                        .FirstOrDefault(u => u.Email == sessionEmail);
                    newMes.User = currentUser;
                    newMes.UserId = currentUser.Id;
                    newMes.Content = posted.NewMessage;
                    db.Messages.Add(newMes);
                    db.SaveChanges();
                }
                return RedirectToAction("MessageBoard", new { messageTitleId = posted.MessageTitleId });
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
    }
}
