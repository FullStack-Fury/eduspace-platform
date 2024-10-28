namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects
{
    public record PaymentMethod
    {
        public string Value { get; }

        public PaymentMethod(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("El método de pago no puede estar vacío.");
            Value = value;
        }

        // Constructor sin parámetros para EF Core
        private PaymentMethod() { }

        public static implicit operator string(PaymentMethod paymentMethod) => paymentMethod.Value;
    }
}