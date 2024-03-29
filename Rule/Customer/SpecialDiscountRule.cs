﻿using System;
using Domain;
using Domain.Interfaces;
using NRules.Fluent.Dsl;

namespace CustomRule.Customer
{
    public class SpecialDiscountRule : NRules.Fluent.Dsl.Rule
    {
        // todo: Define Special Discount

        /// <summary>
        /// Given the Customer is an existing customer and eligible for a special discount or is a new customer spending over £1000
        /// When there is a change made to order quantity or order UnitPrice
        /// Then the IsDiscountApplied property will be set to true.
        /// </summary>
        public override void Define()
        {
            ApplyDiscount();
        }
        
        private void ApplyDiscount()
        {
            
            Domain.Customer customer = null;
            Order order = null;

            When()
                .Match(() => order)
                .Or(x => x
                    .Match<Domain.Customer>(() => customer, c => c.IsExisting && c.IsEligibleForSpecialDiscount)
                    .And(xx => xx
                        .Match<Domain.Customer>(() => customer, c => !c.IsExisting && !c.IsEligibleForSpecialDiscount)
                        .Exists<Order>(o => o.Customer == customer, o => o.Amount >= 1000)
                    )
                );
            Filter()
                .OnChange(() => order.Quantity, () => order.UnitPrice);
            Then()
                .Do(ctx => ctx.Update(order, ApplyDiscount));
        }
        
        private static void ApplyDiscount(Order order)
        {
            order.IsDiscountApplied = true;
            
            order.DiscountedAmount = order.Customer.CustomerType switch
            {
                CustomerType.Gold => order.Amount * 0.7,
                CustomerType.Silver => order.Amount * 0.8,
                CustomerType.Bronze => order.Amount * 0.9,
                _ => order.Amount
            };
        }
    }
}
