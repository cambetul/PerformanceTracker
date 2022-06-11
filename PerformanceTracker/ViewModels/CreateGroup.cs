using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerformanceTracker.Models;

namespace PerformanceTracker.ViewModels
{
    public class CreateGroup
    {
        public CreateGroup()
        {
            Users = new List<User>();
        }
        public string Title { get; set;}
        public List<User> Users {get; set;}
        public List<int> SelectedUsersIds { get; set; }
    }
}
