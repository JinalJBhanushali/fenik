using Application.Common.CQS.Queries;
using Application.Common.Extensions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CustomerManager.Queries
{
    public record GetCustomerListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? GST { get; set; }
    }

    public class GetCustomerListProfile : Profile
    {
        public GetCustomerListProfile()
        {
            CreateMap<Customer, GetCustomerListDto>();
        }
    }

    public class GetCustomerListResult
    {
        public List<GetCustomerListDto>? Data { get; init; }
    }
    public class GetCustomerListRequest : IRequest<GetCustomerListResult>
    {
        public bool IsDeleted { get; init; } = false;
    }  
    public class GetCustomerListHandler : IRequestHandler<GetCustomerListRequest, GetCustomerListResult>
    {
        private readonly IMapper _mapper;
        private readonly IQueryContext _context;
        public GetCustomerListHandler(IMapper mapper, IQueryContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<GetCustomerListResult> Handle(GetCustomerListRequest request, CancellationToken cancellationToken = default)
        {
           var query = _context
                .Customer
                .AsNoTracking()
                .ApplyIsDeletedFilter(request.IsDeleted)
                .AsQueryable(); 
            var entities = await query.ToListAsync(cancellationToken);
            var dtos = _mapper.Map<List<GetCustomerListDto>>(entities);
            return new GetCustomerListResult { Data = dtos };
        }
    }
}
