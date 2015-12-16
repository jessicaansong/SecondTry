using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JayBugTracker.Models.CodeFirst
{
    public class TicketAttachment
    {
        //Main fields in TicketAttachment Database
            public int Id { get; set; }
            public int TicketId { get; set; }
            public int AuthorId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public System.DateTimeOffset Created { get; set; }
            public Nullable<System.DateTimeOffset> Updated { get; set; }
            public string UpdateReason { get; set; }
            public string MediaURL { get; set; }
            public string Type { get; set; }
            // Relational table
           public virtual ApplicationUser Author { get; set; }
           public virtual Ticket Ticket { get; set; }
    }
}