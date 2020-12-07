using Domain;
using Domain.Interfaces;
using FluentAssertions;
using FluentAssertions.Execution;
using Service.Interfaces;
using Xbehave;

namespace Service.Test
{
    public class CustomerSpecification
    {
        /*
           Feature: Customer Eligibility for Special Discount
           If an existing customer has been defined as being eligible for a special discount
           or if they are a new customer spending over £1000; then this customer is eligible for a 
           special discount.
           
           Achieved Outcome: If the Special Discount Rule is applied to a Customer's order that matches the criteria 
           of the rule; then the outcome of the Customer's Order will be the "IsDiscountApplied" Order property will equal true.
         */

        // todo: #1 Stub Interfaces for Customer and Order models
        // todo: #2 Stub Interface for Customer Service
        // todo: #3 Stub Interfaces for rule request and response
        // todo: #4 Define Special Discount - apply this rule as per the feature above
        // todo: #5 Create Customer Domain Model
        // todo: #6 Create Order Domain Model
        // todo: #7 Create Service to process Rules against Customer and Order
        // todo: #8 Create request and response for Rule to service
        // todo: #9 Create acceptance criteria scenarios for Rule Engine (System Under Test)


        /// <summary>
        /// Acceptance Criteria:
        /// Scenario: Valid implementation of the Rule Engine for an existing Customer 
        /// who is eligible for Special Discount. This will return a valid statement.
        /// 
        /// Given the Customer is an existing customer eligible for a Special Discount
        /// When the Special Discount Rule is applied
        /// Then a valid message will be returned as "IsDiscountApplied" Order property will equal true
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="customerType"></param>
        /// <param name="isExisting"></param>
        /// <param name="isEligibleForSpecialDiscount"></param>
        /// <param name="orderId"></param>
        /// <param name="quantity"></param>
        /// <param name="unitPrice"></param>
        /// <param name="customerService"></param>
        /// <param name="ruleRequest"></param>
        /// <param name="ruleResponse"></param>
        [Scenario]
        [Example("Mickey Mouse", CustomerType.Gold, true, true, 121236, 1, 500d)]
        [Example("Minnie Mouse", CustomerType.Silver, true, true, 121237, 2, 300d)]
        [Example("Donald Duck", CustomerType.Bronze, true, true, 121238, 9, 200d)]
        [Example("Daisy Duck", CustomerType.Gold, true, true, 121239, 3, 1200d)]
        public void
            RuleEngine_ValidImplementation_IsExistingCustomer_IsEligibleForSpecialDiscount_ReturnsValidStatement(
                string customerName,
                CustomerType customerType,
                bool isExisting,
                bool isEligibleForSpecialDiscount,
                int orderId,
                int quantity,
                double unitPrice,
                ICustomerService customerService,
                IRuleRequest ruleRequest,
                IRuleResponse ruleResponse
            )
        {
            "Given the Customer is an existing customer eligible for a special discount"
                .x(() =>
                {
                    ruleRequest = HydrateRuleRequest(customerName, customerType, isExisting,
                        isEligibleForSpecialDiscount, orderId, quantity, unitPrice);
                    customerService = new CustomerService();
                });
            "When the Special Discount Rule is applied"
                .x(() => { ruleResponse = customerService.Execute(ruleRequest); });
            "Then a valid message will be returned"
                .x(() => { ValidAssertion(ruleResponse); });
        }

        /// <summary>
        /// Acceptance Criteria:
        /// Scenario: Valid implementation of the Rule Engine for new Customer 
        /// who is NOT eligible for Special Discount and has an order total over £1000. This will return a valid statement.
        /// 
        /// Given the Customer is a new customer spending over £1000
        /// When the Special Discount Rule is applied
        /// Then a valid message will be returned as "IsDiscountApplied" Order property will equal true
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="customerType"></param>
        /// <param name="isExisting"></param>
        /// <param name="isEligibleForSpecialDiscount"></param>
        /// <param name="orderId"></param>
        /// <param name="quantity"></param>
        /// <param name="unitPrice"></param>
        /// <param name="customerService"></param>
        /// <param name="ruleRequest"></param>
        /// <param name="ruleResponse"></param>
        [Scenario]
        [Example("Mickey Mouse", CustomerType.New, false, false, 121236, 1, 1000d)]
        [Example("Minnie Mouse", CustomerType.New, false, false, 121237, 4, 300d)]
        [Example("Donald Duck", CustomerType.New, false, false, 121238, 9, 200d)]
        [Example("Daisy Duck", CustomerType.New, false, false, 121239, 3, 1200d)]
        public void RuleEngine_ValidImplementation_NotExistingCustomer_NotEligibleForSpecialDiscount_OrderTotalOver1000_ReturnsValidStatement(
                string customerName,
                CustomerType customerType,
                bool isExisting,
                bool isEligibleForSpecialDiscount,
                int orderId,
                int quantity,
                double unitPrice,
                ICustomerService customerService,
                IRuleRequest ruleRequest,
                IRuleResponse ruleResponse
        )
        {
            "Given the Customer is a new customer spending over £1000"
                .x(() =>
                {
                    ruleRequest = HydrateRuleRequest(customerName, customerType, isExisting,
                        isEligibleForSpecialDiscount, orderId, quantity, unitPrice);
                    customerService = new CustomerService();
                });
            "When the Special Discount Rule is applied"
                .x(() => { ruleResponse = customerService.Execute(ruleRequest); });
            "Then a valid message will be returned"
                .x(() => { ValidAssertion(ruleResponse); });
        }

        /// <summary>
        /// Acceptance Criteria:
        /// Scenario: Invalid implementation of the Rule Engine for new Customer 
        /// who is NOT eligible for Special Discount and has an order total NOT over £1000. This will return a invalid statement.
        /// 
        /// Given the Customer is not an existing customer and therefore ineligible for a special discount nor is the customer spending over £1000
        /// When the Special Discount Rule is applied
        /// Then an invalid message will be returned as "IsDiscountApplied" Order property will equal true
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="customerType"></param>
        /// <param name="isExisting"></param>
        /// <param name="isEligibleForSpecialDiscount"></param>
        /// <param name="orderId"></param>
        /// <param name="quantity"></param>
        /// <param name="unitPrice"></param>
        /// <param name="customerService"></param>
        /// <param name="ruleRequest"></param>
        /// <param name="ruleResponse"></param>
        [Scenario]
        [Example("Mickey Mouse", CustomerType.New, false, false, 121236, 6, 150d)]
        [Example("Minnie Mouse", CustomerType.New, false, false, 121237, 2, 300d)]
        [Example("Donald Duck", CustomerType.New, false, false, 121238, 4, 200d)]
        [Example("Daisy Duck", CustomerType.New, false, false, 121239, 1, 950d)]
        public void
            RuleEngine_InvalidImplementation_NotExistingCustomer_NotEligibleForSpecialDiscount_OrderTotalNotOver1000_ReturnsInvalidStatement(
                string customerName,
                CustomerType customerType,
                bool isExisting,
                bool isEligibleForSpecialDiscount,
                int orderId,
                int quantity,
                double unitPrice,
                ICustomerService customerService,
                IRuleRequest ruleRequest,
                IRuleResponse ruleResponse
            )
        {

            "Given the Customer is not an existing customer and therefore ineligible for a special discount nor is the customer spending over £1000"
                .x(() =>
                {
                    ruleRequest = HydrateRuleRequest(customerName, customerType, isExisting,
                        isEligibleForSpecialDiscount, orderId, quantity, unitPrice);
                    customerService = new CustomerService();
                });
            "When the Special Discount Rule is applied"
                .x(() => { ruleResponse = customerService.Execute(ruleRequest); });
            "Then an invalid message will be returned"
                .x(() => { InvalidAssertion(ruleResponse); });
        }

        /// <summary>
        /// Acceptance Criteria:
        /// Scenario: Invalid implementation of the Rule Engine for an existing Customer 
        /// who is NOT eligible for Special Discount and has an order total NOT over £1000. This will return a invalid statement.
        /// 
        /// Given the Customer is an existing customer but not eligible for a special discount nor is the customer spending over £1000
        /// When the Special Discount Rule is applied
        /// Then an invalid message will be returned as "IsDiscountApplied" Order property will not equal true
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="customerType"></param>
        /// <param name="isExisting"></param>
        /// <param name="isEligibleForSpecialDiscount"></param>
        /// <param name="orderId"></param>
        /// <param name="quantity"></param>
        /// <param name="unitPrice"></param>
        /// <param name="customerService"></param>
        /// <param name="ruleRequest"></param>
        /// <param name="ruleResponse"></param>
        [Scenario]
        [Example("Mickey Mouse", CustomerType.Bronze, true, false, 121236, 6, 150d)]
        [Example("Minnie Mouse", CustomerType.Gold, true, false, 121237, 2, 300d)]
        [Example("Donald Duck", CustomerType.Silver, true, false, 121238, 4, 200d)]
        [Example("Daisy Duck", CustomerType.Gold, true, false, 121239, 1, 950d)]
        public void RuleEngine_InvalidImplementation_IsExistingCustomer_NotEligibleForSpecialDiscount_OrderTotalNotOver1000_ReturnsInvalidStatement(
                string customerName,
                CustomerType customerType,
                bool isExisting,
                bool isEligibleForSpecialDiscount,
                int orderId,
                int quantity,
                double unitPrice,
                ICustomerService customerService,
                IRuleRequest ruleRequest,
                IRuleResponse ruleResponse
        )
        {
            "Given the Customer is an existing customer but not eligible for a special discount nor is the customer spending over £1000"
                .x(() =>
                {
                    ruleRequest = HydrateRuleRequest(customerName, customerType, isExisting,
                        isEligibleForSpecialDiscount, orderId, quantity, unitPrice);
                    customerService = new CustomerService();
                });
            "When the Special Discount Rule is applied"
                .x(() => { ruleResponse = customerService.Execute(ruleRequest); });
            "Then an invalid message will be returned"
                .x(() => { InvalidAssertion(ruleResponse); });
        }
        
        private static void ValidAssertion(IRuleResponse ruleResponse)
        {
            using (new AssertionScope())
            {
                ruleResponse.RuleStatus.Should().Be(RuleStatus.Success);
                
                switch (ruleResponse.Order.Customer.CustomerType)
                {
                    case CustomerType.Gold:
                        ruleResponse.Order.DiscountedAmount.Should().Be(ruleResponse.Order.Amount * 0.7);
                        break;
                    case CustomerType.Silver:
                        ruleResponse.Order.DiscountedAmount.Should().Be(ruleResponse.Order.Amount * 0.8);
                        break;
                    case CustomerType.Bronze:
                        ruleResponse.Order.DiscountedAmount.Should().Be(ruleResponse.Order.Amount * 0.9);
                        break;
                    case CustomerType.New :
                        ruleResponse.Order.DiscountedAmount.Should().Be(ruleResponse.Order.Amount);
                        break;
                    default:
                        ruleResponse.Order.DiscountedAmount.Should().Be(ruleResponse.Order.Amount);
                        break;
                }
            }
        }

        private static void InvalidAssertion(IRuleResponse ruleResponse)
        {
            using (new AssertionScope())
            {
                ruleResponse.RuleStatus.Should().Be(RuleStatus.Failed);
            }
        }

        private static RuleRequest HydrateRuleRequest(string customerName, CustomerType customerType, bool isExisting,
            bool isEligibleForSpecialDiscount, int orderId, int quantity, double unitPrice)
        {
            var customer = new Customer(customerName, customerType)
                { IsExisting = isExisting, IsEligibleForSpecialDiscount = isEligibleForSpecialDiscount };
            
            
            var order = new Order(orderId, customer, quantity, unitPrice);

            return new RuleRequest { Customer = customer, Order = order };
        }
    }
}
