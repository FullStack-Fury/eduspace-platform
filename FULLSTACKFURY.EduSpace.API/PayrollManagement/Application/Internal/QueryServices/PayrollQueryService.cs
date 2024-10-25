using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Application.Internal.QueryServices
{
    public class PayrollQueryService : IPayrollQueryService
    {
        private readonly IPayrollRepository _payrollRepository;

        public PayrollQueryService(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<IEnumerable<Payroll>> Handle(GetAllPayrollsQuery query)
        {
            return await _payrollRepository.GetAllAsync();
        }

        public async Task<Payroll?> Handle(GetPayrollByTeacherIdQuery query)
        {
            return (await _payrollRepository.FindByTeacherIdAsync(query.TeacherId)).FirstOrDefault();
        }
    }
}