namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;

public interface IMeeting
{
    void ScheduleMeeting();
    void CancelMeeting();
    void UpdateMeetingDetails();
}