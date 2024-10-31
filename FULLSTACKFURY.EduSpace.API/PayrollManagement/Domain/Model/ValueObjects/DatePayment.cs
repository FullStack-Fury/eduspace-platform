namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects;

public record DatePayment
{
    public DateTime Value { get; }

    public DatePayment(DateTime value)
    {
        if (value > DateTime.Now.AddMonths(1)) 
            throw new ArgumentException("The payment date cannot be more than one month in the future.");
        Value = value;
    }

    public static implicit operator DateTime(DatePayment date) => date.Value;
}
