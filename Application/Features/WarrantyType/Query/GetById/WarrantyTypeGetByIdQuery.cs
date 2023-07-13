using MediatR;

namespace Application.Features.WarrantyType.Query.GetById
{
    public class WarrantyTypeGetByIdQuery : IRequest<WarrantyTypeGetByIdDto>
    {
        public int WarrantyTypeId { get; set; }

        public WarrantyTypeGetByIdQuery(int WarrantyTypeId)
        {
            this.WarrantyTypeId = WarrantyTypeId;
        }
    }
}
