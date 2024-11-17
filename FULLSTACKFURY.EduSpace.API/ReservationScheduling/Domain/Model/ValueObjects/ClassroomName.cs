namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;

public record ClassroomName
{
    public string ClassroomN { get; init; }

    public ClassroomName(string classroomIdentifier)
    {
        if(ClassroomN == null) throw new ArgumentOutOfRangeException("Classroom Id cannot be null");
        this.ClassroomN = ClassroomN;
    }
    
    ClassroomName() {}
}