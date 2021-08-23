namespace Shkolo.Areas.Admin.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    public class AspNetUserRoleViewModel

    {
        public IdentityUser User { get; set; }
        public IList<string> UserRoles { get; set; }
    }
}
