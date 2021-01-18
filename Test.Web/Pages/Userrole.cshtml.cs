using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Test.Application.ViewModels;
using Test.Domain.Models;

namespace Test.Web.Pages
{
    public class UserroleModel : PageModel
    {
        private readonly ILogger<UserroleModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserroleModel(
            ILogger<UserroleModel> logger,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public List<UserRoleDto> Roles { get; set; }
        [BindProperty]
        public List<string> AreChecked { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return RedirectToPage("Error");
            }

            var model = new List<UserRoleDto>();
            var roles = _roleManager.Roles.ToList();

            foreach (var role in roles)
            {
                var userRoleDto = new UserRoleDto
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleDto.IsSelected = true;
                }
                else
                {
                    userRoleDto.IsSelected = false;
                }

                model.Add(userRoleDto);
            }
            Roles = model;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return RedirectToPage("Error");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return Page();
            }

            result = await _userManager.AddToRolesAsync(user, AreChecked);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
