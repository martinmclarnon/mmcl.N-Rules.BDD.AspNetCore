using Domain.Interfaces;

namespace Domain
{
    public class Order : IOrder
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double Amount => Quantity * UnitPrice;
        
        public bool IsDiscountApplied { get; set; }

        public Order(int id, Customer customer, int quantity, double unitPrice)
        {
            Id = id;
            Customer = customer;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
