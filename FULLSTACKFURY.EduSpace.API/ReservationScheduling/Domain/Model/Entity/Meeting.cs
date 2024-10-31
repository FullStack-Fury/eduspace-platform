using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;

public partial class Meeting(EMeetingStatus type) : IMeeting
{
    public int Id { get; }
    
    public MeetingIdentifier MeetingIdentifier { get; private set; } = new();
    public EMeetingStatus Status { get; private set; } = EMeetingStatus.Scheduled;
    
    public void ScheduleMeeting()
    {

        Status = EMeetingStatus.Scheduled;
    }
    
    public void CancelMeeting()
    {
        Status = EMeetingStatus.Canceled;
    }
    
    public void UpdateMeetingDetails()
    {
        Status = EMeetingStatus.Update;
    }
    
    public virtual object GetContent()
    {
        return string.Empty;
    }
}