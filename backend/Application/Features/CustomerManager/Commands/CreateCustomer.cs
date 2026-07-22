using Application.Common.Repository;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.CustomerManager.Commands
{
    public class CreateCustomerResult
    {
        public Customer? Data { get; set; }
    }
    public class CreateCustomerRequest : IRequest<CreateCustomerResult>
    {
        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? GST { get; set; }
    }
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
        }
    }
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResult>
    {
        private readonly ICommandRepository<Customer> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCustomerHandler(ICommandRepository<Customer> repository,
        IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateCustomerResult> Handle(CreateCustomerRequest request, CancellationToken cancellationToken=default)
        {
            var entity = new Customer();
            entity.Name = request.Name;
            entity.Street = request.Street;
            entity.City = request.City;
            entity.PhoneNumber = request.PhoneNumber;
            entity.GST = request.GST;
            await _repository.CreateAsync(entity, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            return new CreateCustomerResult { Data = entity };
        }
    }
}
