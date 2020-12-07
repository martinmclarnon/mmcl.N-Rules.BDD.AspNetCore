using System.Reflection;
using CustomRule.Customer;
using Domain;
using Domain.Interfaces;
using NRules;
using NRules.Fluent;
using Service.Interfaces;

namespace Service
{

    public class CustomerService : ICustomerService
    {

        // todo: #1 Instantiate and implement variables to apply rules to
        // todo: #2 Hydrate RuleRepository with rules
        // todo: #3 Compile Rules
        // todo: #4 Create session
        // todo: #5 Insert facts into rules engine's memory
        // todo: #6 Start match/resolve/act cycle


        /// <summary>
        /// Execute Rules
        /// </summary>
        /// <param name="ruleRequest"></param>
        /// <returns></returns>
        public RuleResponse Execute(IRuleRequest ruleRequest)
        {
            var customer = ruleRequest.Customer;
            var order = ruleRequest.Order;

            var repository = new RuleRepository();

            repository.Load(x => x.From(Assembly.GetAssembly(typeof(SpecialDiscountRule))));

            var factory = repository.Compile();
            var session = factory.CreateSession();
            session.Insert(customer);
            session.Insert(order);
            session.Update(customer);
            session.Fire();

            return new RuleResponse
            {
                RuleStatus = order.IsDiscountApplied ? RuleStatus.Success : RuleStatus.Failed,
                Order = order
            };
        }
    }
}
