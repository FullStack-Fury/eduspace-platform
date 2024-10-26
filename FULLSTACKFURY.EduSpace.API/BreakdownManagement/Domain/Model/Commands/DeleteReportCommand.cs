namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Commands
{
    public class DeleteReportCommand
    {
        public int Id { get; }

        public DeleteReportCommand(int id)
        {
            Id = id;
        }
    }
}