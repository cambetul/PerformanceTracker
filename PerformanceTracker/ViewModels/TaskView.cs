using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceTracker.ViewModels
{
    public class TaskView
    {
        public TaskView()
        {
           // AssignedUsers = new List<Models.User>();
            TaskMembers = new List<Models.TaskMember>();
        }
        public int TaskId { get; set; }
        public int GroupId { get; set; }
        public string Content { get; set; }
        public string Explanation { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartDate { get; set; }
  //      public List<Models.User> AssignedUsers { get; set; }
        public List<Models.TaskMember> TaskMembers { get; set; }
    }
}
