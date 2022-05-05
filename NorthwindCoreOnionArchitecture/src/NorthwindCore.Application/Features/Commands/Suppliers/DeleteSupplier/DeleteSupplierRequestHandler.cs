using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using NorthwindCore.Domain.Entities;
using NorthwindCore.Application.Mapping;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Commands.Suppliers.DeleteSupplier
{
    public class DeleteSupplierRequestHandler : IRequestHandler<DeleteSupplierRequest, DeleteSupplierResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSupplierRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteSupplierResponse> Handle(DeleteSupplierRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.SupplierRepository.GetById(request.Id) != null)
            {
                await _unitOfWork.SupplierRepository.Remove(request.Id);
                await _unitOfWork.Complete();

                return new DeleteSupplierResponse
                {
                    SupplierId = request.Id,
                    Succeed = true,
                    Message = "Deleted successfully."
                };
            }

            return new DeleteSupplierResponse
            {
                SupplierId = -1,
                Succeed = false,
                Message = "NotFound"
            };
        }
    }
}