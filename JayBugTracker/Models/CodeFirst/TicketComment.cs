using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JayBugTracker.Models.CodeFirst
{
    public class TicketComment
    {
        //Main Fields in TicketComment Database
        public int id { get; set; }
        public int TicketId { get; set; }
        public string AuthorId { get; set; }
        public string Description { get; set; }
        public System.DateTimeOffset Created { get; set; }
        public Nullable<System.DateTimeOffset> Updated { get; set; }
        public string UpdateReason { get; set; }

        //Relational Database
        public virtual ApplicationUser Author { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}