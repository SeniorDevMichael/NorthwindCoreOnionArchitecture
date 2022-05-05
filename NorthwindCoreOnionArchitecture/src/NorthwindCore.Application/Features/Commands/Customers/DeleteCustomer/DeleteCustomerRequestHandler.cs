using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Commands.Customers.DeleteCustomer
{
    public class DeleteCustomerRequestHandler : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCustomerRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CustomerRepository.GetById(request.Id) != null)
            {
                await _unitOfWork.CustomerRepository.Remove(request.Id);
                await _unitOfWork.Complete();

                return new DeleteCustomerResponse
                {
                    CustomerId = request.Id,
                    Succeed = true,
                    Message = "Deleted successfully."
                };
            }

            return new DeleteCustomerResponse
            {
                CustomerId = -1,
                Succeed = false,
                Message = "NotFound"
            };
        }
    }
}