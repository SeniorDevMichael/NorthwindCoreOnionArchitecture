using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Application.Features.Commands.Products.CreateProduct
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        //public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter ProductName.")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "ProductName length [2,40].")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter SupplierId.")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Please enter CategoryId.")]
        public int CategoryId { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
