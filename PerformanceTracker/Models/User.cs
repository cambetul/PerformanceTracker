using System;
using System.Collections.Generic;

#nullable disable

namespace PerformanceTracker.Models
{
    public partial class User
    {
        public User()
        {
            Groups = new HashSet<Group>(); // owned by user
            Messages = new HashSet<Message>(); // sent by user
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
