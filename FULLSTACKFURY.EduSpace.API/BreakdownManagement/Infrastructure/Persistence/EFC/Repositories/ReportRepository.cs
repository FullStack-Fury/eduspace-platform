using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(AppDbContext context) : base(context) { }

        // Implementación de GetByIdAsync
        public async Task<Report?> GetByIdAsync(int id)
        {
            // Busca un informe por su ID
            return await Context.Set<Report>().FindAsync(id);
        }

        // Implementación de FindAllByResourceIdAsync
        public async Task<IEnumerable<Report>> FindAllByResourceIdAsync(int resourceId)
        {
            // Obtiene todos los informes asociados a un ResourceId
            return await Context.Set<Report>()
                .Where(report => report.ResourceId == resourceId)
                .ToListAsync();
        }

        // Implementación de DeleteAsync
        public async Task DeleteAsync(Report report)
        {
            // Elimina el informe de la base de datos
            Context.Set<Report>().Remove(report);
            await Context.SaveChangesAsync();
        }

        // Implementación de UpdateAsync
        public async Task UpdateAsync(Report report)
        {
            // Actualiza la entidad Report
            Context.Set<Report>().Update(report);
            await Context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Report>> FindAllByTeacherIdAsync(int teacherId)
        {
            return await Context.Set<Report>()
                .Where(p => p.TeacherId == teacherId)
                .ToListAsync();
        }
        
    }
}