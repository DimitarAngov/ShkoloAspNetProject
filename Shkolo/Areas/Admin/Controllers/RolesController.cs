namespace Shkolo.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Areas.Admin.Models;
    using Shkolo.Areas.Admin.Services.Roles;

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RolesController:Controller
    {
        private readonly IRolesService rolesService;
        public RolesController(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }
        public IActionResult All()
        {
            var roles = this.rolesService.All();
            return View(roles);
        }

        public IActionResult Delete(string id)
        {
            this.rolesService.Delete(id);
            return this.Redirect("/Admin/Roles/All");
        }
    
        public IActionResult Add()
        {
            return View();
        }

    [HttpPost]
        public IActionResult Add(AspNetRoles role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            this.rolesService.Add(role);
            return this.Redirect("/Admin/Roles/All");
        }

        public IActionResult Edit(string id)
        {
            var roleFindById = this.rolesService.FindById(id);

            return View(new AspNetRoles
            {
                Id=roleFindById.Id,
                Name=roleFindById.Name
            });
        }

        [HttpPost]
        public IActionResult Edit(string id, AspNetRoles role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            this.rolesService.Edit(id, role);
            return this.Redirect("/Admin/Roles/All");
        }
    }
}
