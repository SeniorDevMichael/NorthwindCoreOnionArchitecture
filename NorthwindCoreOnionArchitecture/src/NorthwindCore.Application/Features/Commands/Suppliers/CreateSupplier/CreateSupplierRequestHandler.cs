using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using NorthwindCore.Domain.Entities;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Commands.Suppliers.CreateSupplier
{
    public class CreateSupplierRequestHandler : IRequestHandler<CreateSupplierRequest, CreateSupplierResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSupplierRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateSupplierResponse> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
        {
            Supplier supplier = _mapper.Map<Supplier>(request);

            await _unitOfWork.SupplierRepository.Add(supplier);
            await _unitOfWork.Complete();

            return new CreateSupplierResponse
            {
                SupplierId = supplier.SupplierId,
                Succeed = supplier != null,
                Message = "Created successfully."
            };
        }
    }
}