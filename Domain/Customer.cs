using Domain.Interfaces;

namespace Domain
{
    public class Customer : ICustomer
    {
        public string Name { get; }

        public bool IsExisting { get; set; }

        public bool IsEligibleForSpecialDiscount { get; set; }
        
        public CustomerType CustomerType { get; set; }
        
        public Customer(string name) => Name = name;

        public Customer(string name, CustomerType customerType)
        {
            Name = name;
            CustomerType = customerType;
        }
    }
}
