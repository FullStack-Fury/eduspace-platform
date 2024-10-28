using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Application.Internal.QueryServices
{
    public class PayrollQueryService : IPayrollQueryService
    {
        private readonly IPayrollRepository _payrollRepository;
        private readonly AppDbContext _context;

        public PayrollQueryService(IPayrollRepository payrollRepository, AppDbContext context)
        {
            _payrollRepository = payrollRepository;
            _context = context;
        }

        public async Task<IEnumerable<Payroll>> Handle(GetAllPayrollsQuery query)
        {
            // Usar Include para cargar la entidad Teacher relacionada con Payroll
            return await _context.Payrolls
                .Include(p => p.Teacher) // Cargar la entidad Teacher
                .ToListAsync();
        }

        public async Task<Payroll?> Handle(GetPayrollByTeacherIdQuery query)
        {
            return await _context.Payrolls
                .Include(p => p.Teacher) // Cargar la entidad Teacher
                .FirstOrDefaultAsync(p => p.TeacherId == query.TeacherId);
        }
    }
}