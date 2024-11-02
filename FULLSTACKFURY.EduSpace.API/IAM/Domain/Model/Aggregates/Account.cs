using FULLSTACKFURY.EduSpace.API.IAM.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.IAM.Domain.Model.Aggregates;

public class Account
{
    //:TODO add hashing in the future
    public int Id { get; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public ERoles Role { get; private set; }
    
    public Account(string username, string password, string role)
    {
        Username = username;
        Password = password;
        Role = Enum.Parse<ERoles>(role);
    }
}