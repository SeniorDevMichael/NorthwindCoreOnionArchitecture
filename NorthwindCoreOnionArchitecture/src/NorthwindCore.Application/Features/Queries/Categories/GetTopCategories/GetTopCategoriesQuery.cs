using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Categories.GetTopCategories
{
    public class GetTopCategoriesQuery : IRequest<IEnumerable<CategoryDTO>>
    {
        public int count { get; set; }
    }
}