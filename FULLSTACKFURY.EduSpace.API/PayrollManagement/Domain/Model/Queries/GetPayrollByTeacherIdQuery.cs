namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Queries
{
    public class GetPayrollByTeacherIdQuery
    {
        public int TeacherId { get; }

        public GetPayrollByTeacherIdQuery(int teacherId)
        {
            TeacherId = teacherId;
        }
    }
}