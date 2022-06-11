using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerformanceTracker.Models;

namespace PerformanceTracker.ViewModels
{
    public class HomeView
    {
        public HomeView()
        {
            Groups = new List<Models.Group>();
            Tasks = new List<Models.Task>();
        }
        public string Name { get; set; }
        public List<Models.Group> Groups { get; set; }
        public List<Models.Task> Tasks { get; set; }
    }
}
