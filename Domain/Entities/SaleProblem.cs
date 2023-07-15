using Domain.Common;

namespace Domain.Entities
{
    public class SaleProblem : EntityBase
    {
        public Guid SaleId { get; set; }
        public virtual Sale Sale { get; set; }
        public Guid ProblemId { get; set; }
        public virtual Problem Problem { get; set; }
        public decimal Price { get; set; }
    }
}