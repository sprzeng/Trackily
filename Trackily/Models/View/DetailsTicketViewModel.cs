﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trackily.Models.Domain;
using static Trackily.Models.Domain.Ticket;

namespace Trackily.Models.View
{
    public class DetailsTicketViewModel
    {
        public Guid TicketId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Created")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Last Updated")]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedDate { get; set; }

        [Display(Name = "Creator")]
        public string CreatorUserName { get; set; }  

        [Display(Name = "Reviewed?")]
        public bool IsReviewed { get; set; }

        [Display(Name = "Approved?")]
        public bool IsApproved { get; set; }

        [Display(Name = "Assigned Developers")]
        public List<string> Assigned { get; set; }

        public TicketType Type { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
    }
}
