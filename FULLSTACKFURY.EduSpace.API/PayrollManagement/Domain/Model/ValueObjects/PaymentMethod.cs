namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects;

public record PaymentMethod
{
    public string Value { get; }

    public PaymentMethod(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) 
            throw new ArgumentException("The payment method cannot be null or empty.");
        Value = value;
    }

    public static implicit operator string(PaymentMethod paymentMethod) => paymentMethod.Value;
}
