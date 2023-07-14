using Domain.Common;
using MediatR;

namespace Application.Features.WarrantyType.Command.Delete
{
    public class WarrantyTypeDeleteCommand : IRequest<Response<bool>>
    {
        public Guid WarrantyTypeId { get; set; }
    }
}