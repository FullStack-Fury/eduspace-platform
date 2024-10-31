namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;

public record MeetingIdentifier(Guid Identifier)
{
    /// <summary>
    /// Default constructor for the meeting identifier. 
    /// </summary>
    public MeetingIdentifier() : this(Guid.NewGuid())
    {
    }
}