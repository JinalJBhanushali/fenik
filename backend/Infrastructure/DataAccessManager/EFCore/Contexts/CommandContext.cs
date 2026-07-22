using Application.Common.CQS.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccessManager.EFCore.Contexts
{
    public class CommandContext : DataContext, ICommandContext
    {
        public CommandContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
