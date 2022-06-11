using System;
using System.Collections.Generic;

#nullable disable

namespace PerformanceTracker.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsPublic { get; set; }
        public int GroupId { get; set; }
        public string Explanation { get; set; }
        public virtual Group Group { get; set; }
    }
}
