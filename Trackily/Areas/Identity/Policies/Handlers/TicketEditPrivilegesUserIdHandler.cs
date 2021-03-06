﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Trackily.Areas.Identity.Data;
using Trackily.Areas.Identity.Policies.Requirements;


namespace Trackily.Areas.Identity.Policies.Handlers
{
    public class TicketEditPrivilegesUserIdHandler : AuthorizationHandler<TicketEditPrivilegesRequirement, Guid>
    {
        private readonly UserManager<TrackilyUser> _userManager;

        public TicketEditPrivilegesUserIdHandler(UserManager<TrackilyUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            TicketEditPrivilegesRequirement requirement,
            Guid creatorId)
        {
            var currentUser = await _userManager.GetUserAsync(context.User);
            Debug.Assert(currentUser != null);

            if (currentUser.Role == TrackilyUser.UserRole.Manager || currentUser.Id == creatorId)
            {
                context.Succeed(requirement);
            }
        }
    }
}
