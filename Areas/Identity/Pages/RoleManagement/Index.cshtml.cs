using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raffel_Web.Areas.Identity.Data;

namespace Raffel_Web.Areas.Identity.Pages.RoleManagement
{
    [Authorize(Roles = "Manager, Supervisor")]
    public class IndexModel : PageModel
    {

        private readonly UserManager<Raffel_WebUser> _userManager;
        private readonly SignInManager<Raffel_WebUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public IndexModel(
            UserManager<Raffel_WebUser> userManager,
            SignInManager<Raffel_WebUser> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        public IList<Raffel_WebUser> users { get; set; }
        public IList<string> roles { get; set; }
        public string currentRole { get; set; }
        public int count { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            users = await _userManager.Users.ToListAsync();
            for (int i = 0; i < users.Count(); i++) { 
               var userroles = await _userManager.GetRolesAsync(users[i]); ///this only gets one role
                if(roles == null)
                {
                    roles = userroles;
                }
                else
                {
                    roles.Add(userroles.FirstOrDefault());
                }
            }
            
            return Page();
        }
       

        
       /*
        public async Task<IEnumerable<string>> Get()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var user = await _userManager.FindByIdAsync(userId);
            // Get the roles for the user
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }*/
    }

  
}
