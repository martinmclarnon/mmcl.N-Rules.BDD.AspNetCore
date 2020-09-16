namespace Domain.Interfaces
{
    public interface IOrder
    {
        int Id { get; set; }

        Customer Customer { get; set; }

        int Quantity { get; set; }

        double UnitPrice { get; set; }

        double Amount { get; }

        bool IsDiscountApplied { get; set; }
    }
}
