using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Problem : EntityBase
    {
        public int WarrantyTypeId { get; set; }
        public virtual WarrantyType WarrantyType { get; set; }
        public string Name { get; set; }
    }
}
