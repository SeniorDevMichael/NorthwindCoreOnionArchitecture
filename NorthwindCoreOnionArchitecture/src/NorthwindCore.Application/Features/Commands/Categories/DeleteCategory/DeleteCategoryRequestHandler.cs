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

namespace NorthwindCore.Application.Features.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryRequestHandler : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCategoryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CategoryRepository.GetById(request.Id) != null)
            {
                await _unitOfWork.CategoryRepository.Remove(request.Id);
                await _unitOfWork.Complete();

                return new DeleteCategoryResponse
                {
                    CategoryId = request.Id,
                    Succeed = true,
                    Message = "Deleted successfully."
                };
            }

            return new DeleteCategoryResponse
            {
                CategoryId = -1,
                Succeed = false,
                Message = "NotFound"
            };
        }
    }
}