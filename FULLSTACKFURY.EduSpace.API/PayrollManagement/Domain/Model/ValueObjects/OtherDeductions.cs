namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects
{
    public record OtherDeductions
    {
        public decimal Value { get; }

        public OtherDeductions(decimal value)
        {
            if (value < 0) throw new ArgumentException("Other deductions cannot be negative.");
            Value = value;
        }

        public static implicit operator decimal(OtherDeductions deductions) => deductions.Value;
    }
}