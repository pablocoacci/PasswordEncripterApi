using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordEncripter.Entities
{
    public class PasswordSite
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public string Site { get; set; }
        public string EncriptedAccount { get; set; }
        public string EncriptedPass { get; set; }
        public string EncriptedSecretQuestion { get; set; }
        public string EncriptedSecretAnswer { get; set; }
        public string ContactMail { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
