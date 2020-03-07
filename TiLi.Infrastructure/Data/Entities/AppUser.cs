using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace TiLi.Infrastructure.Data.Entities
{
    // Add profile data for application users by adding properties to this class
    public class AppUser : IdentityUser
    {
        public AppUser() : base()
        {
            this.AppUserProject = new HashSet<AppUserProject>();
        }

        // Extended Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<AppUserProject> AppUserProject { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }
    }
}
