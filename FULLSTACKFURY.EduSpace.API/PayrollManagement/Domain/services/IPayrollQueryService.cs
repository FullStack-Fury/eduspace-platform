using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Queries;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Services
{
    public interface IPayrollQueryService
    {
        Task<IEnumerable<Payroll>> Handle(GetAllPayrollsQuery query);
        Task<Payroll?> Handle(GetPayrollByTeacherIdQuery query);
    }
}