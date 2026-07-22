using Domain.Entities;
using Infrastructure.DataAccessManager.EFCore.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Common.Constants;

namespace Infrastructure.DataAccessManager.EFCore.Configurations
{
    public class CustomerConfiguration : BaseEntityConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.Name).HasMaxLength(NameConsts.MaxLength).IsRequired();
            builder.Property(c => c.PhoneNumber).HasMaxLength(CodeConsts.MaxLength).IsRequired();
            builder.Property(c => c.Street).HasMaxLength(NameConsts.MaxLength).IsRequired(false);
            builder.Property(x => x.City).HasMaxLength(NameConsts.MaxLength).IsRequired(false);
            builder.Property(x => x.GST).HasMaxLength(NameConsts.MaxLength).IsRequired(false);


            builder.HasIndex(e => e.Name);
            builder.HasIndex(e => e.PhoneNumber);
        }
    }
}
