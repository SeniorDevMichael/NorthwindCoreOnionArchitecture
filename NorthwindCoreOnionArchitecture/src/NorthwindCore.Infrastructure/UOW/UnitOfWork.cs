using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindCore.Application.Interfaces.Repositories;
using NorthwindCore.Application.Interfaces.Repositories.Base;
using NorthwindCore.Infrastructure.Context;
using NorthwindCore.Infrastructure.Repositories;

namespace NorthwindCore.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private NorthwindContext _northwindContext;

        public UnitOfWork(NorthwindContext context)
        {
            _northwindContext = context;

            CategoryRepository = CategoryRepository ?? new CategoryRepository(_northwindContext);
            CustomerRepository = CustomerRepository ?? new CustomerRepository(_northwindContext);
            EmployeeRepository = EmployeeRepository ?? new EmployeeRepository(_northwindContext);
            OrderRepository = OrderRepository ?? new OrderRepository(_northwindContext);
            OrderDetailRepository = OrderDetailRepository ?? new OrderDetailRepository(_northwindContext);
            ProductRepository = ProductRepository ?? new ProductRepository(_northwindContext);
            RegionRepository = RegionRepository ?? new RegionRepository(_northwindContext);
            ShipperRepository = ShipperRepository ?? new ShipperRepository(_northwindContext);
            SupplierRepository = SupplierRepository ?? new SupplierRepository(_northwindContext);
        }

        public ICategoryRepository CategoryRepository { get; private set; }
        public ICustomerRepository CustomerRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }
        public IOrderDetailRepository OrderDetailRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public IRegionRepository RegionRepository { get; private set; }
        public IShipperRepository ShipperRepository { get; private set; }
        public ISupplierRepository SupplierRepository { get; private set; }

        public async Task<int> Complete()
        {
            return await _northwindContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _northwindContext.DisposeAsync();
        }
    }
}