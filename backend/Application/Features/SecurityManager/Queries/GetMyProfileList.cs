using Application.Common.Services.SecurityManager;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecurityManager.Queries
{

    public class GetMyProfileListResult
    {
        public List<GetMyProfileListResultDto>? Data { get; init; }
    }

    public class GetMyProfileListRequest : IRequest<GetMyProfileListResult>
    {
        public string? UserId { get; init; }
    }

    public class GetMyProfileListValidator : AbstractValidator<GetMyProfileListRequest>
    {
        public GetMyProfileListValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }

    public class GetMyProfileListHandler : IRequestHandler<GetMyProfileListRequest, GetMyProfileListResult>
    {
        private readonly ISecurityService _securityService;

        public GetMyProfileListHandler(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        public async Task<GetMyProfileListResult> Handle(GetMyProfileListRequest request, CancellationToken cancellationToken)
        {
            var result = await _securityService.GetMyProfileListAsync(
                request.UserId ?? "",
                cancellationToken
                );

            return new GetMyProfileListResult
            {
                Data = result
            };
        }
    }
}
