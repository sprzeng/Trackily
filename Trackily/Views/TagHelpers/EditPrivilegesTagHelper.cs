﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Trackily.Views.TagHelpers
{
    [HtmlTargetElement(Attributes = "creator")]
    public class EditPrivilegesTagHelper : TagHelper
    {
        private readonly IAuthorizationService _authService;
        private readonly ClaimsPrincipal _principal;
        public Guid Creator { get; set; }

        public EditPrivilegesTagHelper(IAuthorizationService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _principal = httpContextAccessor.HttpContext.User;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var authResult = await _authService.AuthorizeAsync(_principal, Creator, "HasEditPrivileges");
            if (!authResult.Succeeded)
                output.SuppressOutput();
        }
    }
}
