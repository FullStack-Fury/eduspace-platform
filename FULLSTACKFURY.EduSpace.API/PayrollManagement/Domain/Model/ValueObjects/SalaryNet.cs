namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects;

public record SalaryNet
{
    public decimal Value { get; }

    public SalaryNet(decimal value)
    {
        if (value < 0) throw new ArgumentException("The net salary cannot be negative.");
        Value = value;
    }

    public static implicit operator decimal(SalaryNet net) => net.Value;
}
