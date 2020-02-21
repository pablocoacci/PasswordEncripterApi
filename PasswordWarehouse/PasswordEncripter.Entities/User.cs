using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PasswordEncripter.Entities
{
    public class User : IdentityUser
    {
        public User(string userName) : base(userName) 
        {
            PasswordSites = new Collection<PasswordSite>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public string PassEncripter { get; set; }
        public virtual ICollection<PasswordSite> PasswordSites { get; set; }
    }
}
