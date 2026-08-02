using Application.Common.Repository;
using Domain.Entities;
using Infrastructure.SecurityManager.AspNetIdentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccessManager.EFCore.Contexts
{
    public class DataContext : IdentityDbContext<ApplicationUser>, IEntityDbSet
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Token> Token { get; set; }
    }
}
