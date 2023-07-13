using Domain.Common;
using MediatR;

namespace Application.Features.WarrantyType.Command.Delete
{
    public class WarrantyTypeDeleteCommand : IRequest<Response<bool>>
    {
        public int WarrantyTypeId { get; set; }
    }
}