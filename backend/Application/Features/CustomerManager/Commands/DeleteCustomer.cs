using Application.Common.Repository;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CustomerManager.Commands
{
    public class DeleteCustomerResult
    {
        public Customer? Data { get; set; }
    }
    public class DeleteCustomerRequest : IRequest<DeleteCustomerResult>
    {
        public int Id { get; init; }
        public string DeletedById { get; init; }
    }
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerRequest>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResult>
    {
        private readonly ICommandRepository<Customer> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCustomerHandler(ICommandRepository<Customer> repository,
        IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteCustomerResult> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetAsync(request.Id!, cancellationToken);
            if (entity == null)
            {
                throw new Exception($"Customer not found : {request.Id}");
            }
            _repository.Delete(entity);
            await _unitOfWork.SaveAsync(cancellationToken);
            return new DeleteCustomerResult { Data = entity };
        }
    }
}
