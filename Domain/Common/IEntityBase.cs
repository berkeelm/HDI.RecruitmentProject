using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IEntityBase
    {
        Guid Id { get; }
        DateTime CreatedDate { get; }
        Guid? CreatedUserId { get; }
        DateTime? UpdatedDate { get; }
        Guid? UpdatedUserId { get; }
        bool IsDeleted { get; }
    }
}
