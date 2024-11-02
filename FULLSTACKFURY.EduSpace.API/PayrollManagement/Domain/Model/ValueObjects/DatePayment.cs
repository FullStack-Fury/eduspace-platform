namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects
{
    public record DatePayment
    {
        public DateTime Value { get; }

        public DatePayment(DateTime value)
        {
            if (value == default) throw new ArgumentException("La fecha de pago no puede ser vacía.");
            Value = value;
        }

        // Constructor sin parámetros para EF Core
        private DatePayment() { }

        public static implicit operator DateTime(DatePayment datePayment) => datePayment.Value;
    }
}