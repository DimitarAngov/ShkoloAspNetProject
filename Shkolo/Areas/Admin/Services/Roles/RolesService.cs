namespace Shkolo.Areas.Admin.Services.Roles
{
    using Microsoft.AspNetCore.Identity;
    using Shkolo.Areas.Admin.Models;
    using Shkolo.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RolesService : IRolesService
    {
        private readonly ShkoloDbContext db;
        public RolesService(ShkoloDbContext db)
            {
                this.db = db;
            }
        public ICollection<AspNetRoles> All()
        {
            var roles = this.db
            .Roles
            .OrderBy(x => x.Name)
            .Select(x => new AspNetRoles
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return roles;
        }
        public void Delete(string id)
        {
            var roleDel = this.db.Roles.FirstOrDefault(x => x.Id == id);
            this.db.Roles.Remove(roleDel);
            db.SaveChanges();
        }

        public void Add(AspNetRoles role)
        {
            var roleData = new IdentityRole
            {
                Name = role.Name,
            };

            db.Roles.Add(roleData);
            db.SaveChanges();
        }
        public void Edit(string id, AspNetRoles role)
        {
            var roleData = new IdentityRole
            {
                Id = role.Id,
                Name=role.Name
            };

            db.Roles.Update(roleData);
            db.SaveChanges();
        }
        public AspNetRoles FindById(string id)
            => this.db
                  .Roles
                  .Where(x => x.Id == id)
                  .Select(x => new AspNetRoles
                  {
                      Id = x.Id,
                      Name=x.Name
                  })
                  .FirstOrDefault();
    }
}
