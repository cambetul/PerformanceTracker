using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerformanceTracker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceTracker.ViewModels
{
    public class GroupView
    {
        public GroupView()
        {
            MessageTitles = new List<Models.MessageTitle>();
            Tasks = new List<Models.Task>();
            SelectedMembersIds = new List<int>();
            Members = new List<Models.User>();
        }
        public int Id { get; set; }
        public int ownerId { get; set; }
        public string Title { get; set; }
        public int NumberOfMembers { get; set; }
        //       public MessageTitle CreatedMessageTitle { get; set; }

        public List<Models.MessageTitle> MessageTitles { get; set; } // to list all message titles
        public List<Models.Task> Tasks { get; set; }
        public Models.MessageTitle NewMessageTitle { get; set; }
        public Models.Task NewTask { get; set; }
        public List<int> SelectedMembersIds { get; set; } // new task's members
        public List<Models.User> Members { get; set; } // new task's members

    }
}