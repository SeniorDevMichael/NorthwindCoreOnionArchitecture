using MediatR;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Queries.Shippers.GetTopShippers
{
    public class GetTopShippersQuery : IRequest<IEnumerable<ShipperDTO>>
    {
        public int count { get; set; }
    }
}