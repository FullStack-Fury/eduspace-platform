using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly AppDbContext _context;

        public PayrollRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payroll>> GetAllAsync()
        {
            return await _context.Set<Payroll>().ToListAsync();
        }

        public async Task<Payroll?> GetByIdAsync(int id)
        {
            return await _context.Set<Payroll>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Payroll payroll)
        {
            await _context.Set<Payroll>().AddAsync(payroll);
            await _context.SaveChangesAsync();
        }

        public void Update(Payroll payroll)
        {
            _context.Set<Payroll>().Update(payroll);
            _context.SaveChangesAsync();
        }

        public void Delete(Payroll payroll)
        {
            _context.Set<Payroll>().Remove(payroll);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Payroll>> FindByTeacherIdAsync(int teacherId)
        {
            return await _context.Set<Payroll>().Where(p => p.TeacherId == teacherId).ToListAsync();
        }
    }
}