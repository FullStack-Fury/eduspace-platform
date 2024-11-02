namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects
{
    public record Account
    {
        public string Value { get; }

        // Constructor para uso normal
        public Account(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("La cuenta no puede estar vacía.");
            Value = value;
        }

        // Constructor sin parámetros para EF Core
        private Account() { }

        public static implicit operator string(Account account) => account.Value;
    }
}