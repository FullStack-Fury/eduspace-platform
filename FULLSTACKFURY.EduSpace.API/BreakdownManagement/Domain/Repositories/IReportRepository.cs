using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllAsync();
        Task<Report?> GetByIdAsync(int id);
        Task AddAsync(Report report);
        void Update(Report report);
        void Delete(Report report);
        Task<IEnumerable<Report>> FindByResourceIdAsync(int resourceId);
    }
}