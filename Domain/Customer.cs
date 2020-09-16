using Domain.Interfaces;

namespace Domain
{
    public class Customer : ICustomer
    {
        public string Name { get; }

        public bool IsExisting { get; set; }

        public bool IsEligibleForSpecialDiscount { get; set; }

        public Customer(string name) => Name = name;
    }
}
