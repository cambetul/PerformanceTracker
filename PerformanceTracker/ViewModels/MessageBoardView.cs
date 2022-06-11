using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceTracker.ViewModels
{
    public class MessageBoardView
    {
        public MessageBoardView()
        {
            AllMessages = new List<Models.Message>();
        }
        public int MessageTitleId { get; set; }
        public int GroupId { get; set; }
        public string Title { get; set; }
        public string NewMessage { get; set; }
        public List<Models.Message> AllMessages { get; set; }
    }
}
