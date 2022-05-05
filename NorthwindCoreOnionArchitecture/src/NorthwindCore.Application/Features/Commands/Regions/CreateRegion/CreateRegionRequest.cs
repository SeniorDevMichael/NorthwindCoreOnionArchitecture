using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Regions.CreateRegion
{
    public class CreateRegionRequest : IRequest<CreateRegionResponse>
    {
        //public int RegionId { get; set; }

        [Required(ErrorMessage = "Please enter Region Description.")]
        public string RegionDescription { get; set; }
    }
}