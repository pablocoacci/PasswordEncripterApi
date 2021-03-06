﻿using System;

namespace PasswordEncripter.Entities
{
    public class PasswordSite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string Site { get; set; }
        public string EncriptedAccount { get; set; }
        public string EncriptedPass { get; set; }
        public string EncriptedSecretQuestion { get; set; }
        public string EncriptedSecretAnswer { get; set; }
        public string ContactMail { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public virtual User User { get; set; }
    }
}
