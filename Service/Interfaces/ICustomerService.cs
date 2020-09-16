using Domain;
using Domain.Interfaces;

namespace Service.Interfaces
{
    public interface ICustomerService
    {
        RuleResponse Execute(IRuleRequest ruleRequest);
    }
}
