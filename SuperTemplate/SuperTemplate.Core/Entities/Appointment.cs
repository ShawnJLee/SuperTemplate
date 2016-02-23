using System;
using System.Collections.Generic;

namespace SuperTemplate.Core.Entities
{
    public class Appointment : BaseEntity
    {
        public string Name { get; set; }
        public Room Location { get; set; }
        public ICollection<Invitation> Invitations{ get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
