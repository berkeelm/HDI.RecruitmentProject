using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SaleProblem.Query.GetById
{
    public class SaleProblemGetByIdDto
    {
        public Guid Id { get; set; }
        public Guid SaleId { get; set; }
        public Guid ProblemId { get; set; }
        public string Problem { get; set; }
        public string WarrantyType { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
    }
}