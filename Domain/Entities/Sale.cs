using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sale : EntityBase
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public decimal Price { get; set; }
        public Guid RepairChangeCenterUserId { get; set; }
        public virtual User RepairChangeCenterUser { get; set; }
    }
}