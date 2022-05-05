using AutoMapper;
using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            //return _unitOfWork.CategoryRepository.GetAll().Result.Select(x => _mapper.Map<CategoryDTO>(x)).ToList();
            
            //var categories = await _unitOfWork.CategoryRepository.GetAll();
            var categories = await _unitOfWork.CategoryRepository.GetAll(x=>x.Products);
            return categories.Select(x => _mapper.Map<CategoryDTO>(x)).ToList();
        }
    }
}
