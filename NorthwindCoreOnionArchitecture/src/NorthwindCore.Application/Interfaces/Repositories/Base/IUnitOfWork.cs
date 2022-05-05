using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Interfaces.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }

        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IProductRepository ProductRepository { get; }
        IRegionRepository RegionRepository { get; }
        IShipperRepository ShipperRepository { get; }
        ISupplierRepository SupplierRepository { get; }

        Task<int> Complete();


        //Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));//
        //Task<bool> SaveEntitesAsync(CancellationToken cancellationToken = default(CancellationToken));//
    }
}
