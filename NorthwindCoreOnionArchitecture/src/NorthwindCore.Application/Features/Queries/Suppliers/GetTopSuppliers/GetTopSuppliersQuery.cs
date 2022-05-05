using MediatR;
using NorthwindCore.Application.DTO.View;
using System.Collections.Generic;

namespace NorthwindCore.Application.Features.Queries.Suppliers.GetTopSuppliers
{
    public class GetTopSuppliersQuery : IRequest<IEnumerable<SupplierDTO>>
    {
        public int count { get; set; }
    }
}