namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;

public record AdminId
{
    public int AdminIdentifier { get; init; }

    public AdminId(int AdminIdentifier)
    {
        if(AdminIdentifier<=0) throw new ArgumentException("Admin Id cannot be less than or equal to 0");
        this.AdminIdentifier = AdminIdentifier;
    }
    AdminId() {}
}