namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects;

public record Observation
{
    public string? Value { get; }

    public Observation(string? value)
    {
        if (value != null && value.Length > 250) 
            throw new ArgumentException("The observation cannot exceed 250 characters.");
        Value = value;
    }

    public static implicit operator string?(Observation observation) => observation.Value;
}
