using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.WarrantyType.Command.Update
{
    public class WarrantyTypeUpdateCommand : IRequest<Response<bool>>
    {
        public int WarrantyTypeId { get; set; }
        public string Name { get; set; }
    }
}