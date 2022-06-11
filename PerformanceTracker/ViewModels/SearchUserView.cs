using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceTracker.ViewModels
{
    public class SearchUserView
    {
        public SearchUserView()
        {
            AllUsers = new List<Models.User>();
        }
        //public int UserId { get; set; }
        public List<Models.User> AllUsers { get; set; }
    }
}
