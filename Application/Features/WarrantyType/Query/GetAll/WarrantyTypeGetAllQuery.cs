using MediatR;

namespace Application.Features.WarrantyType.Query.GetAll
{
    public class WarrantyTypeGetAllQuery : IRequest<List<WarrantyTypeGetAllDto>>
    {
        public WarrantyTypeGetAllQuery()
        {
        }
    }
}