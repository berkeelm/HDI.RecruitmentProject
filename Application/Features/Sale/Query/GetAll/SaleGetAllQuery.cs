using MediatR;

namespace Application.Features.Sale.Query.GetAll
{
    public class SaleGetAllQuery : IRequest<List<SaleGetAllDto>>
    {
        public SaleGetAllQuery()
        {
        }
    }
}