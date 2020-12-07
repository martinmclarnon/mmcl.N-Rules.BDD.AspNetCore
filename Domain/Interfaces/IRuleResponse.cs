namespace Domain.Interfaces
{
    public interface IRuleResponse
    {
      RuleStatus RuleStatus { get; set;  }
      
      Order Order { get; set; }
    }
}
