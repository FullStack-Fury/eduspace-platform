namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Queries
{
    public class GetPayrollByIdQuery
    {
        public int PayrollId { get; }

        public GetPayrollByIdQuery(int payrollId)
        {
            PayrollId = payrollId;
        }
    }
}