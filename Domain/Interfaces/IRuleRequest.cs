namespace Domain.Interfaces
{
    public interface IRuleRequest
    {
        Customer Customer { get; set; }

        Order Order { get; set; }
    }
}
