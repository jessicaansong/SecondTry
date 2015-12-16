using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JayBugTracker.Models.CodeFirst
{
    public class Ticket
    {
        public Ticket()
        {
            this.Comments = new HashSet<TicketComment>();
            this.Attachments = new HashSet<TicketAttachment>();
            this.History = new HashSet<TicketHistory>();
        }

        //Main ticket database
                public int Id { get; set; }
                public string Title { get; set; }
                public string Description { get; set; }
                public System.DateTimeOffset Created { get; set; }
                public Nullable<System.DateTimeOffset> Updated { get; set; }
        //ID Fields in other databases 
                public int ProjectId { get; set; }
                public int TicketPriorityId { get; set; }
                public int TicketStatusId { get; set; }
                public int TicketTypeId { get; set; }
                public string TicketOwnerId { get; set; }
                //public string TicketAssigneeId { get; set; }
        //Relational Tables
                public virtual Project Project { get; set; }
                public virtual TicketPriority TicketPriority { get; set; }
                public virtual TicketStatus TicketStatus { get; set; }
                public virtual TicketType TicketType { get; set; }
                public virtual ApplicationUser TicketOwner { get; set; }
                //public virtual ApplicationUser Users { get; set; }
        //All hashsets require an ICollection 
                public virtual ICollection<TicketComment> Comments { get; set; }
                public virtual ICollection<TicketAttachment> Attachments { get; set; }
                public virtual ICollection<TicketHistory> History { get; set; }

            }
}