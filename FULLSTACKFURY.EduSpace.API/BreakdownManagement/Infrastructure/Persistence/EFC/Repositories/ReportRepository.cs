using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            return await _context.Set<Report>().ToListAsync();
        }

        public async Task<Report?> GetByIdAsync(int id)
        {
            return await _context.Set<Report>().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Report report)
        {
            await _context.Set<Report>().AddAsync(report);
            await _context.SaveChangesAsync();
        }

        public void Update(Report report)
        {
            _context.Set<Report>().Update(report);
            _context.SaveChangesAsync();
        }

        public void Delete(Report report)
        {
            _context.Set<Report>().Remove(report);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Report>> FindByResourceIdAsync(int resourceId)
        {
            return await _context.Set<Report>().Where(r => r.ResourceId.Id == resourceId).ToListAsync();
        }
    }
}