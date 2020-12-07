using Domain.Interfaces;

namespace Domain
{
    public class RuleResponse : IRuleResponse
    {
        public RuleStatus RuleStatus { get; set ; }
        
        
        public Order Order { get; set; }
    }
}
