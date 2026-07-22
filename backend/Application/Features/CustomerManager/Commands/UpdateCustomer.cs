using Application.Common.Repository;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.CustomerManager.Commands
{
    public class UpdateCustomerResult
    {
        public Customer? Data { get; set; }
    }
    public class UpdateCustomerRequest : IRequest<UpdateCustomerResult>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? GST { get; set; }
    }
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Number).NotEmpty().WithMessage("Number is required.");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
        }
    }
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResult>
    {
        private readonly ICommandRepository<Customer> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomerHandler(ICommandRepository<Customer> repository,
        IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateCustomerResult> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                throw new Exception($"Customer not found : {request.Id}");
            }
            entity.Name = request.Name;
            entity.Street = request.Street;
            entity.City = request.City;
            entity.PhoneNumber = request.PhoneNumber;
            entity.GST = request.GST;
            _repository.Update(entity);
            await _unitOfWork.SaveAsync(cancellationToken);
            return new UpdateCustomerResult { Data = entity };
        }
    }
}
