namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects;

public record PensionContribution
{
    public decimal Value { get; }

    public PensionContribution(decimal value)
    {
        if (value < 0) throw new ArgumentException("The pension contribution cannot be negative.");
        Value = value;
    }

    public static implicit operator decimal(PensionContribution contribution) => contribution.Value;
}
