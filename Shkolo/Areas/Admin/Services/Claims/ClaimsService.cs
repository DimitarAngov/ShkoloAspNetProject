using Microsoft.AspNetCore.Identity;
using Shkolo.Areas.Admin.Models;
using Shkolo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shkolo.Areas.Admin.Services.Claims
{
    public class ClaimsService : IClaimsService
    {
        private readonly ShkoloDbContext db;
        public ClaimsService(ShkoloDbContext db)
        {
            this.db = db;
        }
         public ICollection<AspNetUserClaims> All()
        {
            var claims = this.db
            .UserClaims
            .OrderBy(x => x.Id)
            .Select(x => new AspNetUserClaims
            {
                Id = x.Id,
                ClaimType = x.ClaimType,
                ClaimValue=x.ClaimValue
            }).ToList();

            return claims;
        }
        public void Delete(int id)
        {
            var claimDel = this.db.UserClaims.FirstOrDefault(x => x.Id == id);
                this.db.UserClaims.Remove(claimDel);
        }


        public void Add(AspNetUserClaims claim)
        {
            var claimData = new IdentityUserClaim<string>
            {
                Id=claim.Id,
                UserId=claim.UserId,
                ClaimType=claim.ClaimType,
                ClaimValue=claim.ClaimValue
            };

            db.UserClaims.Add(claimData);
            db.SaveChanges();
        }
        public void Edit(int id, AspNetUserClaims claim)
        {
            var claimData = new IdentityUserClaim<string>
            {
                Id = claim.Id,
                UserId = claim.UserId,
                ClaimType = claim.ClaimType,
                ClaimValue = claim.ClaimValue
            };

            db.UserClaims.Update(claimData);
            db.SaveChanges();
        }

        public AspNetUserClaims FindById(int id)
       => this.db
                    .UserClaims
                    .Where(x => x.Id == id)
                    .Select(x => new AspNetUserClaims
                    {
                        Id = x.Id,
                        UserId=x.UserId,
                        ClaimType=x.ClaimType,
                        ClaimValue=x.ClaimValue
                    })
                    .FirstOrDefault();
    }
}
