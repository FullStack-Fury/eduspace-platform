
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Application.Internal.QueryServices
{
    /// <summary>
    /// Service to handle report queries.
    /// </summary>
    public class ReportQueryService : IReportQueryService
    {
        private readonly IReportRepository _reportRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportQueryService"/> class.
        /// </summary>
        /// <param name="reportRepository">The report repository for accessing report data.</param>
        public ReportQueryService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Report>> HandleAllReportsQuery(GetAllReportsQuery query)
        {
            // Returns all reports
            return await _reportRepository.ListAsync();
        }

        /// <inheritdoc />
        public async Task<Report?> HandleReportByIdQuery(GetReportByIdQuery query)
        {
            // Retrieve a report by its ID
            return await _reportRepository.FindByIdAsync(query.ReportId);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Report>> HandleReportsByResourceIdQuery(GetReportByResourceIdQuery query)
        {
            // Retrieve all reports by resource ID
            return await _reportRepository.FindAllByResourceIdAsync(query.ResourceId);
        }
    }
}