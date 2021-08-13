namespace Shkolo.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Areas.Admin.Models;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult All()
        {
            var roles = this.roleManager.Roles
                .OrderBy(x => x.Id)
                .Select(x => new AspNetRoles
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList(); ;

            return View(roles);
        }

         public async Task<IActionResult> Delete(string id)
        {
            var role = await this.roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await this.roleManager.DeleteAsync(role);
            }
            return this.Redirect("/Admin/Roles/All");
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AspNetRoles model)
        {
            if (this.ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Id = model.Id,
                    Name = model.Name
                };

                IdentityResult result = await this.roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return this.Redirect("/Admin/Roles/All");
                }
            }

            return this.View(model);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var role = await this.roleManager.FindByIdAsync(id);

            var model = new AspNetRoles
            {
                Id = role.Id,
                Name = role.Name,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AspNetRoles model)
        {
            var role = await this.roleManager.FindByIdAsync(model.Id);
            role.Name = model.Name;
            IdentityResult result = await this.roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return this.Redirect("/Admin/Roles/All");
            }
            else
            {
                return this.View(model);
            }
        }
    }
}
