namespace FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.ValueObjects;

public record TeacherId
{
    public int Id { get; init; }

    public TeacherId(int id)
    {
        if(id<=0) throw new ArgumentException("Teacher Id cannot be less than or equal to 0");
    }
}