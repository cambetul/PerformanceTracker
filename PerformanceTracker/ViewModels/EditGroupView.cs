using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerformanceTracker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTracker.ViewModels
{
    public class EditGroupView
    {
        public EditGroupView()
        {
            NewUsersIds = new List<int>();
            DeletedUsersIds = new List<int>();
            Members = new List<Models.User>();
            Others = new List<Models.User>();
        }
        public int Id { get; set; }
        public string NewTitle { get; set; }
        public string Title { get; set; }
        [NotMapped]
        public List<int> NewUsersIds { get; set; }
        [NotMapped]
        public List<int> DeletedUsersIds { get; set; }
        public List<User> Members { get; set; }
        public List<Models.User> Others { get; set; }
    }
}
