namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;

public record AdministratorId
{
    public int AdminIdentifier { get; init; }

    public AdministratorId(int AdminIdentifier)
    {
        if(AdminIdentifier<=0) throw new ArgumentException("Admin Id cannot be less than or equal to 0");
        this.AdminIdentifier = AdminIdentifier;
    }
    AdministratorId() {}
}