using Microsoft.AspNetCore.Identity;

namespace KoiCareSystem.Models

{
    public class AppUserModel : IdentityUser
    {
        public string Occupation { get; set; }


    }
}
