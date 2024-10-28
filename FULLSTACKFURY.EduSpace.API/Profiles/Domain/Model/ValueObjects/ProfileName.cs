namespace FULLSTACKFURY.EduSpace.API.Profiles.Domain.Model.ValueObjects;

public record ProfileName
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public ProfileName(string firstName, string lastName)
    {
        if(firstName.Length < 2)
            throw new ArgumentException("First name must be at least 2 characters long", nameof(FirstName));
        if(lastName.Length < 5)
            throw new ArgumentException("Last name must be at least 5 characters long", nameof(LastName));
        
        FirstName = firstName;
        LastName = lastName;
    }

    public string FullName => $"{FirstName} {LastName}";
}