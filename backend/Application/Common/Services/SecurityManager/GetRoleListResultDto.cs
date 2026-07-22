using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services.SecurityManager
{
    public record GetRoleListResultDto
    {
        public string? Id { get; init; }
        public string? Name { get; init; }
    }

}
