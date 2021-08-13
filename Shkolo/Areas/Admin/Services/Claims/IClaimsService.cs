namespace Shkolo.Areas.Admin.Services.Claims
{
    using Shkolo.Areas.Admin.Models;
    using System.Collections.Generic;
    public interface IClaimsService
    {
        public ICollection<AspNetUserClaims> All();
        public void Add(AspNetUserClaims claim);
        public void Edit(int id, AspNetUserClaims claim);
        public void Delete(int id);
        public AspNetUserClaims FindById(int id);
    }
}
