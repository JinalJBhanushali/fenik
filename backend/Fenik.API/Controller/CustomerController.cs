using Application.Features.CustomerManager.Commands;
using Application.Features.CustomerManager.Queries;
using Fenik.API.Common.Base;
using Fenik.API.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fenik.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseApiController
    {
        public CustomerController(ISender sender) : base(sender)
        {
        }
        [HttpPost("CreateCustomer")]
        public async Task<ActionResult<ApiSuccessResult<CreateCustomerResult>>> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(request, cancellationToken);

            return Ok(new ApiSuccessResult<CreateCustomerResult>
            {
                Code = StatusCodes.Status200OK,
                Message = $"Success executing {nameof(CreateCustomerAsync)}",
                Content = response
            });
        }
        [HttpGet("GetCustomerList")]
        public async Task<ActionResult<ApiSuccessResult<GetCustomerListResult>>> GetCustomerListAsync(
            CancellationToken cancellationToken,
            [FromQuery] bool isDeleted = false
        )
        {
            var request = new GetCustomerListRequest { IsDeleted = isDeleted };
            var response = await _sender.Send(request, cancellationToken);

            return Ok(new ApiSuccessResult<GetCustomerListResult>
            {
                Code = StatusCodes.Status200OK,
                Message = $"Success executing {nameof(GetCustomerListAsync)}",
                Content = response
            });
        }
    }
}
