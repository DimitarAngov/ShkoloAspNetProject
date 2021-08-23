namespace Shkolo.Areas.Admin.Models
{
    public class AspNetUserRoles
    {
        public string UserId { get; set; }
        public AspNetUsers AspNetUsers { get; set; }
        public string RoleId { get; set; }
        public AspNetRoles AspNetRoles { get; set; }
    }
}
