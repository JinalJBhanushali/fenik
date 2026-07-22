using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services.SecurityManager
{
    public record GetUserListResultDto
    {
        public string? Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public bool? EmailConfirmed { get; init; }
        public bool? IsDeleted { get; init; }
        public DateTime? CreatedAt { get; init; }
    }
}
