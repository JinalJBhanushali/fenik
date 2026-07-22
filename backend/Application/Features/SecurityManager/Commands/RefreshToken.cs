using Application.Common.Services.SecurityManager;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecurityManager.Commands
{

    public class RefreshTokenResult
    {
        public RefreshTokenResultDto? Data { get; init; }
    }

    public class RefreshTokenRequest : IRequest<RefreshTokenResult>
    {
        public string? RefreshToken { get; set; }
    }

    public class RefreshTokenValidator : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }

    public class RefreshTokenHandler : IRequestHandler<RefreshTokenRequest, RefreshTokenResult>
    {
        private readonly ISecurityService _securityService;

        public RefreshTokenHandler(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        public async Task<RefreshTokenResult> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var result = await _securityService.RefreshTokenAsync(
                request.RefreshToken ?? "",
                cancellationToken
                );

            return new RefreshTokenResult
            {
                Data = result
            };
        }
    }
}
