using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Repositories
{
    public interface IPayrollRepository
    {
        Task<IEnumerable<Payroll>> GetAllAsync();
        Task<Payroll?> GetByIdAsync(int id);
        Task AddAsync(Payroll payroll);
        void Update(Payroll payroll);
        void Delete(Payroll payroll);
        Task<IEnumerable<Payroll>> FindByTeacherIdAsync(int teacherId);
    }
}
