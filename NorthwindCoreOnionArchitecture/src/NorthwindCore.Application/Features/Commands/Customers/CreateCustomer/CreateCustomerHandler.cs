using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using AutoMapper;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using NorthwindCore.Domain.Entities;

namespace NorthwindCore.Application.Features.Commands.Customers.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            //Customer customer = request.Changer<Customer>();
            Customer customer = _mapper.Map<Customer>(request);

            await _unitOfWork.CustomerRepository.Add(customer);
            await _unitOfWork.Complete();

            return new CreateCustomerResponse
            {
                CustomerId = customer.CustomerId,
                Succeed = customer != null,
                Message = "Başarıyla eklenmiştir."
            };
        }
    }
}
