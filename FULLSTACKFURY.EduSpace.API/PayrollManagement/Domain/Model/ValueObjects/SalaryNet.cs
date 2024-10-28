namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects
{
    public record SalaryNet
    {
        public decimal Value { get; }

        public SalaryNet(decimal value)
        {
            if (value < 0) throw new ArgumentException("El salario neto no puede ser negativo.");
            Value = value;
        }

        // Constructor sin parámetros para EF Core
        private SalaryNet() { }

        public static implicit operator decimal(SalaryNet salaryNet) => salaryNet.Value;
    }
}