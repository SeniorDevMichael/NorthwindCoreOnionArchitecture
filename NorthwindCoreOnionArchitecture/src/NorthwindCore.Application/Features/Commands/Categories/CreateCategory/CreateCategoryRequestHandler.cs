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

namespace NorthwindCore.Application.Features.Commands.Categories.CreateCategory
{
    public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            //Category category = request.Changer<Category>();
            Category category = _mapper.Map<Category>(request);

            await _unitOfWork.CategoryRepository.Add(category);
            await _unitOfWork.Complete();

            return new CreateCategoryResponse
            {
                CategoryId = category.CategoryId,
                Succeed = category != null,
                Message = "Created successfully."
            };
        }
    }
}