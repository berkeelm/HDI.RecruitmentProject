using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SaleWarranty.Query.GetById
{
    public class SaleWarrantyGetByIdDto
    {
        public Guid Id { get; set; }
        public Guid SaleId { get; set; }
        public string CustomerName { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string PhotoPath { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal SalePrice { get; set; }
        public Guid WarrantyTypeId { get; set; }
        public string WarrantyType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
    }
}
