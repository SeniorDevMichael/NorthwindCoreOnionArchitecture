using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;
using NorthwindCore.Application.Interfaces.Repositories.Base;

namespace NorthwindCore.Application.Features.Commands.Products.DeleteProduct
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.ProductRepository.GetById(request.Id) != null)
            {
                await _unitOfWork.ProductRepository.Remove(request.Id);
                await _unitOfWork.Complete();

                return new DeleteProductResponse
                {
                    ProductId = request.Id,
                    Succeed = true,
                    Message = "Deleted successfully."
                };
            }

            return new DeleteProductResponse
            {
                ProductId = -1,
                Succeed = false,
                Message = "NotFound"
            };
        }
    }
}