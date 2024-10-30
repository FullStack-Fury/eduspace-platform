﻿using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Repositories
{
    public interface IReportRepository : IBaseRepository<Report>
    {
        Task<Report> FindByIdAsync(int id);

        Task<IEnumerable<Report>> FindAllAsync();

        Task<IEnumerable<Report>> FindAllByResourceIdAsync(int resourceId);

        
    }
}