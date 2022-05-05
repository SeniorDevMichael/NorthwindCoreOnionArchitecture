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

namespace NorthwindCore.Application.Features.Commands.Products.CreateProduct
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);

            await _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.Complete();

            return new CreateProductResponse
            {
                ProductId = product.ProductId,
                Succeed = product != null,
                Message = "Başarıyla eklenmiştir."
            };
        }
    }
}
