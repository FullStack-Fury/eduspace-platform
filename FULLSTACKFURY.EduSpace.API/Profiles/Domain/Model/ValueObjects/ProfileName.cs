namespace FULLSTACKFURY.EduSpace.API.Profiles.Domain.Model.ValueObjects;

public record ProfileName
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public ProfileName() : this(string.Empty, string.Empty) { }

    public ProfileName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FullName => $"{FirstName} {LastName}";
}