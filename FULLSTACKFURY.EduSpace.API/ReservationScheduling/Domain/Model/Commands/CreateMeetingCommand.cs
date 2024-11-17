namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;

public record CreateMeetingCommand(string Title, 
                                    string Description, 
                                    DateOnly Date,
                                    TimeOnly Start, 
                                    TimeOnly End,  
                                    List<(int Id, string FirstName, string LastName)> Teachers,
                                    int AdminId, 
                                    string ClassroomName);