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
    public class GroupController : Controller
    {

        [HttpGet]
        public IActionResult GroupDetail(int groupId)
        {
            string sessionEmail = HttpContext.Session.GetString("useremail");
            if (sessionEmail != null)
            {
                GroupView groupModel = new GroupView();

                PerformanceTrackerContext db = new PerformanceTrackerContext();
                Models.Group detailedGroup = db.Groups.Include(x => x.MessageTitles)
                    .Include(x => x.Owner)
                    .Include(x => x.Tasks)
                    .FirstOrDefault(x => x.Id == groupId);
                if (detailedGroup != null)
                {
                    groupModel.Id = detailedGroup.Id;
                    groupModel.ownerId = detailedGroup.OwnerId;
                    groupModel.Title = detailedGroup.Title;
                    groupModel.NumberOfMembers = detailedGroup.NumberOfMembers;
                    groupModel.MessageTitles = detailedGroup.MessageTitles.ToList();
                    groupModel.Tasks = detailedGroup.Tasks.ToList();

                    List<Models.GroupMember> groupMembers = new List<Models.GroupMember>();
                    groupMembers = db.GroupMembers
                        .Include(x => x.User)
                                    .Include(x => x.Group)
                                    .Where(x => x.GroupId == detailedGroup.Id).ToList();

                    foreach (var gm in groupMembers)
                    {
                        groupModel.Members.Add(gm.User);
                    }
                    return View(groupModel);
                }
                else
                {
                    return RedirectToAction("CreateGroup", ViewBag.Error = "An error occured.");
                }
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        [HttpPost]
        public IActionResult GroupDetail(ViewModels.GroupView posted)
        {
            string sessionEmail = HttpContext.Session.GetString("useremail");
            if (sessionEmail != null)
            {
                PerformanceTrackerContext db = new PerformanceTrackerContext();
                Models.Group detailedGroup = new Models.Group();
                detailedGroup = db.Groups.FirstOrDefault(g => g.Id == posted.Id);
                posted.Title = detailedGroup.Title;
                posted.MessageTitles = detailedGroup.MessageTitles.ToList();
                List<Models.GroupMember> groupMembers = new List<Models.GroupMember>();
                groupMembers = db.GroupMembers
                    .Include(x => x.User)
                    .Include(x => x.Group)
                    .Where(x => x.GroupId == detailedGroup.Id).ToList();
                foreach (var gm in groupMembers)
                {
                    posted.Members.Add(gm.User);
                }
                posted.NumberOfMembers = detailedGroup.NumberOfMembers;
                posted.Tasks = detailedGroup.Tasks.ToList();
                posted.Title = detailedGroup.Title;


                //if new message title is posted
                if (posted.NewMessageTitle != null)
                {
                    if (string.IsNullOrWhiteSpace(posted.NewMessageTitle.Title))
                    {
                        ViewBag.Error = "Message title must be filled.";
                    }
                    Models.MessageTitle newMT = new Models.MessageTitle();
                    newMT.Title = posted.NewMessageTitle.Title;
                    newMT.GroupId = posted.Id;
                    newMT.Group = db.Groups.FirstOrDefault(g => g.Id == posted.Id);
                    db.MessageTitles.Add(newMT);
                    db.SaveChanges();
                }
                if (posted.NewTask != null)
                {// if new task is posted
                    if (posted.NewTask.DueDate < DateTime.Now)
                    {
                        ViewBag.Error = "Please enter a valid due date.";
                        return RedirectToAction("GroupDetail", new { groupId = posted.Id });
                    }
                    if (string.IsNullOrWhiteSpace(posted.NewTask.Explanation) || string.IsNullOrWhiteSpace(posted.NewTask.Content))
                    {
                        ViewBag.Error = "All fields must be filled.";
                        return RedirectToAction("GroupDetail", new { groupId = posted.Id });
                    }

                    Models.Task newTask = new Models.Task();
                    newTask.Content = posted.NewTask.Content;
                    newTask.Explanation = posted.NewTask.Explanation;
                    newTask.GroupId = posted.Id;
                    newTask.Group = db.Groups.FirstOrDefault(g => g.Id == posted.Id);
                    newTask.StartDate = posted.NewTask.StartDate;
                    newTask.DueDate = posted.NewTask.DueDate;
                    newTask.ModifiedOn = DateTime.Now;
                    newTask.IsPublic = true;
                    db.Tasks.Add(newTask);
                    db.SaveChanges();
                    int newTaskId = newTask.Id;
                    // MODIFY TASK MEMBERS TABLE

                    foreach (int x in posted.SelectedMembersIds)
                    {
                        Models.TaskMember newMember = new Models.TaskMember();
                        newMember.UserId = x;
                        newMember.TaskId = newTaskId;
                        newMember.User = db.Users.FirstOrDefault(u => u.Id == x);
                        newMember.Task = newTask;
                        if (newTask.StartDate > DateTime.Now)
                        {
                            newMember.StatusId = 4; // not started
                        }
                        else
                        {
                            newMember.StatusId = 3; // ongoing
                        }
                        newMember.Status = db.Statuses.FirstOrDefault(s => s.Id == newMember.StatusId);
                        db.TaskMembers.Add(newMember);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("GroupDetail", new { groupId = posted.Id });
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        [HttpGet]
        public IActionResult EditGroup(int groupId)
        {
            string sessionEmail = HttpContext.Session.GetString("useremail");
            if (sessionEmail != null)
            {
                EditGroupView editModel = new EditGroupView();
                PerformanceTrackerContext db = new PerformanceTrackerContext();
                Models.Group detailedGroup = db.Groups
                    .Include(x => x.Owner)
                    .FirstOrDefault(x => x.Id == groupId);
                editModel.Id = groupId;
                editModel.Title = detailedGroup.Title;
                List<Models.GroupMember> groupMembers = db.GroupMembers
                    .Include(gm => gm.User)
                    .Where(gm => gm.GroupId == groupId).ToList();
                foreach (var item in groupMembers)
                {
                    editModel.Members.Add(db.Users.FirstOrDefault(u => u.Id == item.UserId));
                }
                editModel.Others = db.Users.ToList();
                foreach (Models.User u in editModel.Members)
                {
                    editModel.Others.Remove(u);
                }
                editModel.Members.Remove(db.Users.FirstOrDefault(u => u.Id == detailedGroup.OwnerId));
                editModel.Others.Remove(db.Users.FirstOrDefault(u => u.Id == detailedGroup.OwnerId));
                return View(editModel);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        [HttpPost]
        public IActionResult EditGroup(ViewModels.EditGroupView posted)
        {
            string sessionEmail = HttpContext.Session.GetString("useremail");
            if (sessionEmail != null)
            {
                PerformanceTrackerContext db = new PerformanceTrackerContext();
                Models.Group currentGroup = db.Groups.FirstOrDefault(g => g.Id == posted.Id);
                if (posted.NewUsersIds != null && posted.NewUsersIds.Any())
                {//if new members are posted
                    foreach (int newId in posted.NewUsersIds)
                    {
                        Models.GroupMember newGM = new Models.GroupMember();
                        Models.User newUser = new Models.User();
                        newUser = db.Users.FirstOrDefault(u => u.Id == newId);
                        newGM.UserId = newId;
                        newGM.User = newUser;
                        newGM.GroupId = posted.Id;
                        newGM.Group = currentGroup;
                        db.GroupMembers.Add(newGM);
                        db.SaveChanges();
                    }
                    currentGroup.NumberOfMembers += posted.NewUsersIds.Count;
                    db.SaveChanges();
                }
                if (posted.DeletedUsersIds != null && posted.DeletedUsersIds.Any())
                {// if members are removed
                    foreach (int delId in posted.DeletedUsersIds)
                    {
                        Models.GroupMember deleteMember = db.GroupMembers
                            .FirstOrDefault(m => m.UserId == delId && m.GroupId == posted.Id);
                        db.GroupMembers.Remove(deleteMember);
                        db.SaveChanges();
                    }
                    currentGroup.NumberOfMembers -= posted.DeletedUsersIds.Count;
                    db.SaveChanges();
                }
                if (!string.IsNullOrWhiteSpace(posted.NewTitle))
                {
                    currentGroup.Title = posted.NewTitle;
                    db.SaveChanges();
                }
                return RedirectToAction("GroupDetail", new { groupId = posted.Id });
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }


        [HttpGet]
        public IActionResult CreateGroup()
        {
            string sessionEmail = HttpContext.Session.GetString("useremail");
            if (sessionEmail != null)
            {
                PerformanceTrackerContext db = new PerformanceTrackerContext();
                Models.User currentUser = db.Users.FirstOrDefault(x => x.Email == sessionEmail);
                ViewModels.CreateGroup cg = new ViewModels.CreateGroup();
                cg.Users = db.Users.ToList();
                cg.Users.Remove(currentUser);
                return View(cg);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }



        [HttpPost]
        public IActionResult CreateGroup(ViewModels.CreateGroup postedGroup)
        {
            string sessionEmail = HttpContext.Session.GetString("useremail");
            if (sessionEmail != null)
            {
                if (string.IsNullOrWhiteSpace(postedGroup.Title) || postedGroup.SelectedUsersIds == null || postedGroup.SelectedUsersIds.Count == 0)
                {
                    ViewBag.Error = "All fields must be filled.";
                    return View();
                }
                PerformanceTrackerContext db = new PerformanceTrackerContext();
                Models.User currentUser = db.Users.FirstOrDefault(x => x.Email == sessionEmail);

                Models.Group newGroup = new Models.Group();
                newGroup.Title = postedGroup.Title;
                newGroup.NumberOfMembers = postedGroup.SelectedUsersIds.Count;
                newGroup.ModifiedOn = DateTime.Now;
                newGroup.OwnerId = currentUser.Id;
                newGroup.Owner = currentUser;
                db.Groups.Add(newGroup);
                db.SaveChanges();
                int newGroupId = newGroup.Id;

                foreach (int x in postedGroup.SelectedUsersIds)
                {
                    Models.GroupMember newMember = new Models.GroupMember();
                    Models.User user = new Models.User();
                    newMember.UserId = x;
                    newMember.GroupId = newGroupId;
                    user = db.Users.FirstOrDefault(u => u.Id == x);
                    if (user == null)
                    {
                        System.Diagnostics.Debug.WriteLine("user null dondu");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(user.Email);
                    }
                    newMember.User = user;
                    newMember.Group = newGroup;
                    db.GroupMembers.Add(newMember);
                    db.SaveChanges();
                }
                return RedirectToAction("GroupDetail", new { groupId = newGroupId });
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        [HttpPost]
        public IActionResult DeleteGroup(ViewModels.GroupView posted)
        {
            PerformanceTrackerContext db = new PerformanceTrackerContext();
            Models.Group group = db.Groups
                .Include(g => g.MessageTitles)
                .Include(g => g.Tasks)
                .Where(g => g.Id == posted.Id).FirstOrDefault();
            List<Models.GroupMember> deletedGM = db.GroupMembers
                .Where(m => m.GroupId == posted.Id).ToList();
            db.GroupMembers.RemoveRange(deletedGM);
            List<Models.Task> deletedTasks = db.Tasks.Where(x => x.GroupId == posted.Id).ToList();
            List<Models.TaskMember> deletedTM = new List<TaskMember>();
            foreach (var task in deletedTasks)
            {
                deletedTM.AddRange(db.TaskMembers.Where(tm => tm.TaskId == task.Id));
            }
            db.TaskMembers.RemoveRange(deletedTM);

            db.Groups.Remove(group);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // POST: GroupController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GroupController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
