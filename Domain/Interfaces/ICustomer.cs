namespace Domain.Interfaces
{
    public interface ICustomer
    {
        string Name { get; }

        bool IsExisting { get; set; }

        bool IsEligibleForSpecialDiscount { get; set; }
    }
}
