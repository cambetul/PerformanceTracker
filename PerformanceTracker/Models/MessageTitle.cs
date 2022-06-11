using System;
using System.Collections.Generic;

#nullable disable

namespace PerformanceTracker.Models
{
    public partial class MessageTitle
    {
        public MessageTitle()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
