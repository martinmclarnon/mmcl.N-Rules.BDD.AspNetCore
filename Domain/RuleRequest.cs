using Domain.Interfaces;

namespace Domain
{
    public class RuleRequest : IRuleRequest
    {
        public Customer Customer { get; set; }

        public Order Order { get; set; }
    }
}
