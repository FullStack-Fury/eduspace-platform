using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.ValueObjects;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Application.Internal.CommandServices
{
    public class ReportCommandService : IReportCommandService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IUnitOfWork _unitOfWork;

        // Constructor
        public ReportCommandService(IReportRepository reportRepository, IUnitOfWork unitOfWork)
        {
            _reportRepository = reportRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Report?> Handle(CreateReportCommand command)
        {
            
            var resourceId = new ResourceId(command.ResourceId); 
            
            var createdAt = new ReportDate(command.CreatedAt); 

            var report = new Report(
                command.KindOfReport,
                command.Description,
                resourceId,
                createdAt
            );

            await _reportRepository.AddAsync(report);
            await _unitOfWork.CompleteAsync();
            return report;
        }

        public async Task<Report?> Handle(DeleteReportCommand command)
        {
            var report = await _reportRepository.GetByIdAsync(command.Id);
            if (report == null) return null;

            _reportRepository.Delete(report);
            await _unitOfWork.CompleteAsync();
            return report;
        }
    }
}