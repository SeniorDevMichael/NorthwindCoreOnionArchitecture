﻿using MediatR;
using NorthwindCore.Application.Interfaces.Repositories;
using NorthwindCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthwindCore.Application.DTO.View;

namespace NorthwindCore.Application.Features.Queries.Suppliers.GetAllSuppliers
{
    public class GetAllSuppliersQuery : IRequest<IEnumerable<SupplierDTO>>
    {

    }
}