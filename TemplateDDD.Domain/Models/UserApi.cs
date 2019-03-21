using Microsoft.AspNetCore.Identity;

namespace TemplateDDD.Domain.Models
{
    public class UserApi : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
