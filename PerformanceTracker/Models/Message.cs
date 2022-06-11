using System;
using System.Collections.Generic;

#nullable disable

namespace PerformanceTracker.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public int TitleId { get; set; }

        public virtual MessageTitle Title { get; set; }
        public virtual User User { get; set; }
    }
}
