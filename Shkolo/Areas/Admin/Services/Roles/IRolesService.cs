namespace Shkolo.Areas.Admin.Services.Roles
{
    using Shkolo.Areas.Admin.Models;
    using System.Collections.Generic;
    public interface IRolesService
    {
        public ICollection<AspNetRoles> All();
        public void Add(AspNetRoles role);
        public void Edit(string id, AspNetRoles role);
        public void Delete(string id);
        public AspNetRoles FindById(string id);
    }
}
