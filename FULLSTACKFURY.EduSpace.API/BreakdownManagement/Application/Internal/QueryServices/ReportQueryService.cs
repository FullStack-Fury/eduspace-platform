using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Application.Internal.QueryServices
{
    public class ReportQueryService : IReportQueryService
    {
        private readonly IReportRepository _reportRepository;

        // Constructor
        public ReportQueryService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

      
        public async Task<IEnumerable<Report>> Handle(GetAllReportsQuery query)
        {
            return await _reportRepository.GetAllAsync();
        }

       
        public async Task<Report?> Handle(GetReportByResourceIdQuery query)
        {
            return (await _reportRepository.FindByResourceIdAsync(query.ResourceId)).FirstOrDefault();
        }
    }
}