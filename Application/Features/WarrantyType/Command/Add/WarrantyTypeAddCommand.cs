using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.WarrantyType.Command.Add
{
    public class WarrantyTypeAddCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
}