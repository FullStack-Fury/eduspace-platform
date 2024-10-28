namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects
{
    public record Observation
    {
        public string Value { get; }

        public Observation(string value)
        {
            // La observación puede ser vacía o nula, ya que podría no haber observaciones.
            Value = value;
        }

        // Constructor sin parámetros para EF Core
        private Observation() { }

        public static implicit operator string(Observation observation) => observation.Value;
    }
}