using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Application.Internal.QueryServices
{
    public class TeacherQueryService
    {
        private readonly AppDbContext _context;

        public TeacherQueryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }
    }
}