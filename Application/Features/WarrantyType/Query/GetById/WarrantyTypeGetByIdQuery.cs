using MediatR;

namespace Application.Features.WarrantyType.Query.GetById
{
    public class WarrantyTypeGetByIdQuery : IRequest<WarrantyTypeGetByIdDto>
    {
        public Guid WarrantyTypeId { get; set; }

        public WarrantyTypeGetByIdQuery(Guid WarrantyTypeId)
        {
            this.WarrantyTypeId = WarrantyTypeId;
        }
    }
}
