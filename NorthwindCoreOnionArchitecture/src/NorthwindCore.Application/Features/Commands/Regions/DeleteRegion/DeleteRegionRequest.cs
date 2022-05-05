using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Regions.DeleteRegion
{
    public class DeleteRegionRequest : IRequest<DeleteRegionResponse>
    {
        public int Id { get; set; }
    }
}