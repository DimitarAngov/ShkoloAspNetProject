namespace Shkolo.Areas.Admin.Services.Users
{
    using Shkolo.Areas.Admin.Models;
    using System.Collections.Generic;

    public interface IUsersService
    {
        public ICollection<AspNetUsers> All();
        public void Add(AspNetUsers user);
        public void Edit(string id,  AspNetUsers user);
        public void Delete(string id);
        public AspNetUsers FindById(string id);
    }
}
