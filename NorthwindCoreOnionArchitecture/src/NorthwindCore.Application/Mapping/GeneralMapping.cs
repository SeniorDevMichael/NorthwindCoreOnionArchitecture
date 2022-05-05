using AutoMapper;
using NorthwindCore.Domain.Entities;
using NorthwindCore.Application.DTO.View;
using NorthwindCore.Application.Features.Commands.Categories.CreateCategory;
using NorthwindCore.Application.Features.Commands.Customers.CreateCustomer;
using NorthwindCore.Application.Features.Commands.Employees.CreateEmployee;
using NorthwindCore.Application.Features.Commands.Orders.CreateOrder;
using NorthwindCore.Application.Features.Commands.Products.CreateProduct;
using NorthwindCore.Application.Features.Commands.Regions.CreateRegion;
using NorthwindCore.Application.Features.Commands.Shippers.CreateShipper;
using NorthwindCore.Application.Features.Commands.Suppliers.CreateSupplier;
using NorthwindCore.Application.Features.Commands.OrderDetails.CreateOrderDetail;

namespace NorthwindCore.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<Customer, CreateCustomerRequest>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<Order, CreateOrderRequest>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();

            CreateMap<OrderDetail, CreateOrderDetailRequest>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();

            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<Region, CreateRegionRequest>().ReverseMap();
            CreateMap<Region, RegionDTO>().ReverseMap();

            CreateMap<Shipper, CreateShipperRequest>().ReverseMap();
            CreateMap<Shipper, ShipperDTO>().ReverseMap();
            
            CreateMap<Supplier, CreateSupplierRequest>().ReverseMap();
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
        }
    }
}