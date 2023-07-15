using Application.Features.Customer.Query.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Dashboard.Query.GetMostProblematicProducts
{
    public class GetMostProblematicProductsQuery : IRequest<List<GetMostProblematicProductsDto>>
    {
        public GetMostProblematicProductsQuery()
        {
        }
    }
}
