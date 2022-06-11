using System;
using System.Collections.Generic;

#nullable disable

namespace PerformanceTracker.Models
{
    public partial class GroupMember
    {
        //public GroupMember()
        //{
        //    Group = new Group();
        //    User = new User();
        //}
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
