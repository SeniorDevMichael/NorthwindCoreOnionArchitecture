using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Categories.CreateCategory
{
    public class CreateCategoryRequest : IRequest<CreateCategoryResponse>
    {        
        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}