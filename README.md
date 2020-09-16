# mmcl.N-Rules.BDD.AspNetCore
Sample solution using BDD with xBehave to demonstrate N-Rules


Feature: Customer Eligibility for Special Discount
	If an existing customer has been defined as being eligible for a special discount
	or if they are a new customer spending over £1000; then this customer is eligible for a 
	special discount.

Achieved Outcome: 
	If the Special Discount Rule is applied to a Customer's order that matches the criteria 
	of the rule; then the outcome of the Customer's Order will be the "IsDiscountApplied" Order property will equal true.

Acceptance Criteria:
	Scenario: Valid implementation of the Rule Engine for an existing Customer 
			  who is eligible for Special Discount. This will return a valid statement.

	Given the Customer is an existing customer eligible for a Special Discount
	When the Special Discount Rule is applied
	Then a valid message will be returned as "IsDiscountApplied" Order property will equal true


Acceptance Criteria:
	Scenario: Valid implementation of the Rule Engine for new Customer 
			  who is NOT eligible for Special Discount and has an order total over £1000. This will return a valid statement.

	Given the Customer is a new customer spending over £1000
	When the Special Discount Rule is applied
	Then a valid message will be returned as "IsDiscountApplied" Order property will equal true


Acceptance Criteria:
	Scenario: Invalid implementation of the Rule Engine for new Customer 
			  who is NOT eligible for Special Discount and has an order total NOT over £1000. This will return a invalid statement.

	Given the Customer is NOT an existing customer and therefore ineligible for a special discount nor is the customer spending over £1000
	When the Special Discount Rule is applied
	Then an invalid message will be returned as "IsDiscountApplied" Order property will NOT equal true


Acceptance Criteria:
	Scenario: Invalid implementation of the Rule Engine for an existing Customer 
			  who is NOT eligible for Special Discount and has an order total NOT over £1000. This will return a invalid statement.

	Given the Customer is an existing customer but not eligible for a special discount nor is the customer spending over £1000
	When the Special Discount Rule is applied
	Then an invalid message will be returned as "IsDiscountApplied" Order property will not equal true
