using System;
using System.Collections.Generic;

#nullable disable

namespace PerformanceTracker.Models
{
    public partial class TaskMember
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
