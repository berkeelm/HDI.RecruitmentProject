using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sale.Query.GetById
{
    public class SaleGetByIdDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public int RepairChangeCenterUserId { get; set; }
        public string RepairChangeCenterUser { get; set; }
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
    }
}
