using MediatR;

namespace Application.Features.SaleWarranty.Query.GetAll
{
    public class SaleWarrantyGetAllQuery : IRequest<List<SaleWarrantyGetAllDto>>
    {
        public SaleWarrantyGetAllQuery()
        {
        }
    }
}