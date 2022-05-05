using NorthwindCore.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Regions.CreateRegion
{
    public class CreateRegionResponse : CommonResponse
    {
        public int RegionId { get; set; }
    }
}
