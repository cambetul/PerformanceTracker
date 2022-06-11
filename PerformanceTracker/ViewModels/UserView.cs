using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerformanceTracker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTracker.ViewModels
{
    public class UserView
    {
        public UserView()
        {
            MemberedTasks = new List<TaskMember>();
        }
        public int UserId { get; set; }
        public Models.User User { get; set; }
        public List<Models.TaskMember> MemberedTasks { get; set; }
        public int MemberedGroupCount { get; set; }
        public int OwnedGroupCount { get; set; }
        public int Succeed { get; set; }
        public int Failed { get; set; }
        public int OnGoing { get; set; }
        public int NotStarted { get; set; }
    }
}
