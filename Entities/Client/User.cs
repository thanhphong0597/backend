using Microsoft.AspNetCore.Identity;

namespace clothes_backend.Entities.Client
{
    public class User : IdentityUser
    {
        public string firstName { get;set; }

        public string lastName { get; set; }


    }
}
