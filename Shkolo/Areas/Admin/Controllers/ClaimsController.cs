namespace Shkolo.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Shkolo.Areas.Admin.Models;
    using Shkolo.Areas.Admin.Services.Claims;

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ClaimsController:Controller
    {
        private readonly IClaimsService claimsService;
        public ClaimsController(IClaimsService claimsService)
        {
            this.claimsService = claimsService;
        }
        public IActionResult All()
        {
            var claims = this.claimsService.All();
            return View(claims);
        }

        public IActionResult Delete(int id)
        {
            this.claimsService.Delete(id);
            return this.Redirect("/Admin/Claims/All");
        }

        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(AspNetUserClaims claim)
        {
            if (!ModelState.IsValid)
            {
                return View(claim);
            }
            
            this.claimsService.Add(claim);
            return this.Redirect("/Admin/Claims/All");
        }

        public IActionResult Edit(int id)
        {
            var claimFindById = this.claimsService.FindById(id);

            return View(new AspNetUserClaims
            {
                Id = claimFindById.Id,
                UserId=claimFindById.UserId,
                ClaimType=claimFindById.ClaimType,
                ClaimValue=claimFindById.ClaimValue
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, AspNetUserClaims claim)
        {
            if (!ModelState.IsValid)
            {
                return View(claim);
            }
            this.claimsService.Edit(id,claim);
            return this.Redirect("/Admin/Claims/All");
        }
    }
}
