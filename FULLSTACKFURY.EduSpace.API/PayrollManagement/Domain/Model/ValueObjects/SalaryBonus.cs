namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects;

public record SalaryBonus
{
    public decimal Value { get; }

    public SalaryBonus(decimal value)
    {
        if (value < 0) throw new ArgumentException("The salary bonus cannot be negative.");
        Value = value;
    }

    public static implicit operator decimal(SalaryBonus bonus) => bonus.Value;
}
