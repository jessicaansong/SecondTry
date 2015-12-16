using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JayBugTracker.Models.CodeFirst
{
    public class TicketHistory
    {
        //Main Database
            public int Id { get; set; }
            public int TicketId { get; set; }
            public string UserId { get; set; }
            public string Property { get; set; }
            public string OldValue { get; set; }
            public string NewValue { get; set; }
            public System.DateTimeOffset Changed { get; set; }
            public string EditId { get; set; }

        //Relational Databases
            public virtual ApplicationUser User { get; set; }
            public virtual Ticket Ticket { get; set; }
    }
}