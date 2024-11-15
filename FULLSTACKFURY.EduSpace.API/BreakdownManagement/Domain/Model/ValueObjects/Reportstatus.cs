namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.ValueObjects
{
    public record Status
    {
        private static readonly string DefaultStatus = "Pendiente";
        private static readonly string[] ValidStatuses = { "Pendiente", "Proceso", "Terminado" };

        public string Value { get; init; }

        // Acepta string? para permitir null
        public Status(string? value)
        {
            // Si el valor es nulo o vacío, asigna el estado predeterminado "Pendiente"
            Value = string.IsNullOrWhiteSpace(value) ? DefaultStatus : value!;  // 'value!' garantiza que no es nulo después de la comprobación

            // Validar si el valor está en la lista de estados válidos
            if (Array.IndexOf(ValidStatuses, Value) == -1)
            {
                throw new ArgumentException($"El estado '{value}' no es válido. Los estados válidos son: {string.Join(", ", ValidStatuses)}.");
            }
        }
    }
}