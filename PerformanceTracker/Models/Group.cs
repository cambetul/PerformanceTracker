using System;
using System.Collections.Generic;

#nullable disable

namespace PerformanceTracker.Models
{
    public partial class Group
    {
        public Group()
        {
            MessageTitles = new HashSet<MessageTitle>();
            Tasks = new HashSet<Task>();
            Owner = new User();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberOfMembers { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<MessageTitle> MessageTitles { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
