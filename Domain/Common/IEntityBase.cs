using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IEntityBase
    {
        int Id { get; }
        DateTime CreatedDate { get; }
        int? CreatedUserId { get; }
        DateTime? UpdatedDate { get; }
        int? UpdatedUserId { get; }
        bool IsDeleted { get; }
    }
}
