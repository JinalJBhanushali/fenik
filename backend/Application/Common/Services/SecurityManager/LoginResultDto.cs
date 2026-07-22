using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services.SecurityManager
{
    public record LoginResultDto
    {
        public string? AccessToken { get; init; }
        public string? RefreshToken { get; init; }
        public string? UserId { get; init; }
        public string? Email { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public List<string>? Roles { get; init; }
    }

}
