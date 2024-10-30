namespace FULLSTACKFURY.EduSpace.API.Profiles.Domain.Model.ValueObjects;

public record ProfilePrivateInformation
{
    public string Email { get; init; }
    public string Dni { get; init; }
    public string Address { get; init; }
    public string Phone { get; init; }

    public ProfilePrivateInformation(string email, string dni
        , string address, string phone)
    {
        Email = email;
        Dni = dni;
        Address = address;
        Phone = phone;
        
        if(string.IsNullOrWhiteSpace(Email)) throw new ArgumentException("Email cannot be null or empty");
        if(string.IsNullOrWhiteSpace(Dni)) throw new ArgumentException("Dni cannot be null or empty");
        if(string.IsNullOrWhiteSpace(Address)) throw new ArgumentException("Address cannot be null or empty");
        if(string.IsNullOrWhiteSpace(Phone)) throw new ArgumentException("Phone cannot be null or empty");
        
        
    }
    public string ObtainEmail => $"{Email}";
    public string ObtainDni => $"{Dni}";
}