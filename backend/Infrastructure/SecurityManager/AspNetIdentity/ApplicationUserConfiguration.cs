using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Common.Constants;

namespace Infrastructure.SecurityManager.AspNetIdentity
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName)
         .HasMaxLength(NameConsts.MaxLength)
         .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(NameConsts.MaxLength)
                .IsRequired();

            builder.Property(u => u.IsDeleted)
                .IsRequired(false);

            builder.Property(u => u.CreatedAt)
                .IsRequired(false);

            builder.Property(u => u.UpdatedAt)
                .IsRequired(false);

            builder.HasIndex(u => u.UserName);
            builder.HasIndex(u => u.Email);
            builder.HasIndex(u => u.FirstName);
            builder.HasIndex(u => u.LastName);
        }
    }
}
