namespace FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.ValueObjects;

public record AreaId
{
    public int Id { get; init; }

    public AreaId(int id)
    {
        if(id <= 0) throw new ArgumentException("Area Id cannot be less than or equal to 0");
        Id = id;
    }
}