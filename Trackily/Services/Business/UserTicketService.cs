﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trackily.Data;
using Trackily.Models.Domain;
using Trackily.Services.Business;
using Trackily.Services.DataAccess;

namespace Trackily.Services.Business
{
    public class UserTicketService 
    {
        private readonly TrackilyContext _context;

        public UserTicketService(TrackilyContext context)
        {
            _context = context;
        }

        public List<string> UserTicketToNames(ICollection<UserTicket> userTickets)
        {
            return userTickets.Select(userTicket => userTicket.User.UserName).ToList();
        }

        public async Task<UserTicket> GetUserTicket(Guid ticketId, Guid userId)
        {
            var userTicket = await _context.UserTickets.FindAsync(userId, ticketId);
            return userTicket;
        }
    }
}
