namespace Shkolo.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Shkolo.Areas.Admin.Models;
    using Microsoft.AspNetCore.Authorization;
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Shkolo.Data;

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        
        public UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult All()
        {
            var users = this.userManager.Users
                .OrderBy(x => x.Id)
                .Select(x => new AspNetUsers
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                }).ToList();

            return View(users);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if (user != null)
            {
                await this.userManager.DeleteAsync(user);
            }
            return this.Redirect("/Admin/Users/All");
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AspNetUsers model)
        {
            if (this.ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    PasswordHash = model.PasswordHash,
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                };

                IdentityResult result = await this.userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    return this.Redirect("/Admin/Users/All");
                }
            }

            return this.View(model);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var model = await this.userManager.FindByIdAsync(id);

            var user = new AspNetUsers
            {
                Id = model.Id,
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PasswordHash = model.PasswordHash,
            };

            return this.View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AspNetUsers model)
        {
            var user = await this.userManager.FindByIdAsync(model.Id);
            user.UserName = model.UserName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.PasswordHash = model.PasswordHash;
            IdentityResult result = await this.userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return this.Redirect("/Admin/Users/All");
            }
            else
            {
                return this.View(model);
            }
        }

        public IActionResult AddUsersRoles()
        {
            
            return View();
        }

        public async Task<IActionResult> AllUsersRolesAsync()
        {
            List<IdentityUser> users = userManager.Users.ToList();
            List<AspNetUserRoleViewModel> model= new List<AspNetUserRoleViewModel>();

            //var user = await this.userManager.FindByNameAsync(TempData["userName"].ToString());
            //var role = await this.roleManager.FindByNameAsync(TempData["roleName"].ToString());

            foreach (var user in users)
            {
                 var userRoles = await this.userManager.GetRolesAsync(user);
                 model.Add(new AspNetUserRoleViewModel{User= user,UserRoles= userRoles});
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddUsersRoles(AspNetUserRoles model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userManager.FindByIdAsync(model.UserId);
                var role = await this.roleManager.FindByIdAsync(model.RoleId);
                
                if (user!=null&&role!=null)
                {
                    await userManager.CreateAsync(new IdentityUser(user.UserName));
                    await roleManager.CreateAsync(new IdentityRole(role.Name));
                    await userManager.AddToRoleAsync(user, role.Name);
                }
          
               /* TempData["userName"]= user.UserName;
                TempData["roleName"] = role.Name;*/

                return this.Redirect("/Admin/Users/AllUsersRoles");
            }
           
            return this.View(model);
        }

        public async Task<IActionResult> DeleteUserRoles(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var userRoles = await this.userManager.GetRolesAsync(user);
           
            if (user != null)
            {
                await this.userManager.RemoveFromRolesAsync(user,userRoles);
            }
            return this.Redirect("/Admin/Users/AllUsersRoles");
        }

    }

}
