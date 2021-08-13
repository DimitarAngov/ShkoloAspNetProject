using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shkolo.Areas.Admin.Models;
using Shkolo.Areas.Admin.Services.Users;
using Shkolo.Data;
using System.Collections.Generic;
using System.Linq;

namespace Shkolo.Areas.Admin.Services.UsersServices
{
    public class UsersService : IUsersService
    {
        private readonly ShkoloDbContext db;
        public UsersService(ShkoloDbContext db)
        {
            this.db = db;
        }
        public ICollection<AspNetUsers> All()
        {
            var users = this.db
            .Users
            .OrderBy(x => x.UserName)
            .Select(x => new AspNetUsers
            {
                Id=x.Id,
                UserName = x.UserName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
            }).ToList();

            return users;
        }
        public void Add(AspNetUsers user)
        {
            var userData = new IdentityUser
            {
                Id = user.Id,
                UserName=user.UserName,
                Email=user.Email,
                PhoneNumber=user.PhoneNumber,
                PasswordHash=user.PasswordHash,
                EmailConfirmed=false,
                PhoneNumberConfirmed=false,
                TwoFactorEnabled=false,
                LockoutEnabled=true,
                AccessFailedCount=0
                
            };

            db.Users.Add(userData);
            db.SaveChanges();
        }
     

        public void Delete(string id)
        {
            var UserDel = this.db.Users.FirstOrDefault(x => x.Id == id);
            this.db.Users.Remove(UserDel);
            db.SaveChanges();
        }

        public AspNetUsers FindById(string id)
       => this.db
                    .Users
                    .Where(x => x.Id == id)
                    .Select(x => new AspNetUsers
                    {
                        Id=x.Id,
                        UserName=x.UserName,
                        Email=x.Email,
                        PhoneNumber=x.PhoneNumber,
                        PasswordHash=x.GetHashCode().ToString()
                    })
                    .FirstOrDefault();

        public void Edit(string id, AspNetUsers user)
        {
            var userData = new IdentityUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0

            };

            db.Users.Update(userData);
            db.SaveChanges();
        }
    }
}
