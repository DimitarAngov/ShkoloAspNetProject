namespace Shkolo.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Shkolo.Areas.Admin.Models;
    using Shkolo.Areas.Admin.Services.Users;
    using Microsoft.AspNetCore.Authorization;

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public IActionResult All()
            {
            var users = this.usersService.All();
            return View(users);
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AspNetUsers user)
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
            this.usersService.Add(user);
            return this.Redirect("/Admin/Users/All");
        }

        public IActionResult Edit(string id)
        {
            var userFindById = this.usersService.FindById(id);

            return View(new AspNetUsers
            {
                Id= userFindById.Id,
                UserName= userFindById.UserName,
                Email = userFindById.Email,
                PhoneNumber= userFindById.PhoneNumber,
                PasswordHash= userFindById.PasswordHash,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            });
        }

        [HttpPost]
        public IActionResult Edit(string id, AspNetUsers user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            this.usersService.Edit(id, user);
            return this.Redirect("/Admin/Users/All");
        }
        
        public IActionResult Delete(string id)
        {
            this.usersService.Delete(id);
            return this.Redirect("/Admin/Users/All");
        }
    }
}
