using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Domain.Common.Constants;

namespace Infrastructure.DataAccessManager.EFCore.Common
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasMaxLength(IdConsts.MaxLength)
                .IsRequired(true);
            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .IsRequired(true);
            builder.Property(e => e.CreatedAt)
                .IsRequired(false);
            //builder.Property(e => e.CreatedById)
            //    .HasMaxLength(UserIdConsts.MaxLength)
            //    .IsRequired(false);
            builder.Property(e => e.UpdatedAt)
                .IsRequired(false);
            //builder.Property(e => e.UpdatedById)
            //    .HasMaxLength(UserIdConsts.MaxLength)
            //    .IsRequired(false);
        }
    }
}
