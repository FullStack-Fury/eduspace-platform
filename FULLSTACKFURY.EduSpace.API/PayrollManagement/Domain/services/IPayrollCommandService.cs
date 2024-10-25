using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Services
{
    public interface IPayrollCommandService
    {
        Task<Payroll?> Handle(CreatePayrollCommand command);
        Task<Payroll?> Handle(UpdatePayrollCommand command);
    }
}   