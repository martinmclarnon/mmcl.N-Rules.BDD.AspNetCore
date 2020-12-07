namespace Domain.Interfaces
{
    public interface IRuleRequest
    {
        Customer Customer { get; }

        Order Order { get; }
    }
}
