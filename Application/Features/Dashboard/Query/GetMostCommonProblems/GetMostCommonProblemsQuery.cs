using Application.Features.Customer.Query.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Dashboard.Query.GetMostCommonProblems
{
    public class GetMostCommonProblemsQuery : IRequest<List<GetMostCommonProblemsDto>>
    {
        public GetMostCommonProblemsQuery()
        {
        }
    }
}
