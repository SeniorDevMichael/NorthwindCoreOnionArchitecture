using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Categories.GetTopCategories
{
    public class GetTopCategoriesQueryHandler : IRequestHandler<GetTopCategoriesQuery, IEnumerable<CategoryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTopCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> Handle(GetTopCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.CategoryRepository.GetTopCategories(request.count).Select(x => _mapper.Map<CategoryDTO>(x)).ToList();
        }
    }
}