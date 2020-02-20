using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PasswordEncripter.Entities.EF.Mappings
{
    class PasswordSiteMapping : IEntityTypeConfiguration<PasswordSite>
    {
        public void Configure(EntityTypeBuilder<PasswordSite> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(255);

            builder.Property(x => x.Site)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.Property(x => x.EncriptedAccount)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.Property(x => x.EncriptedPass)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.Property(x => x.EncriptedSecretQuestion)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(150);

            builder.Property(x => x.EncriptedSecretAnswer)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(150);

            builder.Property(x => x.ContactMail)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.HasOne(x => x.User)
                .WithMany(x => x.PasswordSites)
                .HasForeignKey(x => x.UserId);
                
        }
    }
}
