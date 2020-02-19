using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordEncripter.Entities
{
    public class User : IdentityUser
    {
        public User(string userName) : base(userName) { }

        public string PassEncripter { get; set; }
        public virtual ICollection<PasswordSite> PasswordSites { get; set; }
    }
}
