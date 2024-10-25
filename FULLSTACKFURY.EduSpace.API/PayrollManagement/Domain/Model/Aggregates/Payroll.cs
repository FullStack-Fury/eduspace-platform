using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates
{
    public class Payroll
    {
        public int Id { get; private set; }
        public int TeacherId { get; private set; }
        public SalaryAmount? SalaryAmount { get; private set; }  // Anulable
        public PensionContribution? PensionContribution { get; private set; }  // Anulable
        public SalaryBonus? SalaryBonus { get; private set; }  // Anulable
        public OtherDeductions? OtherDeductions { get; private set; }  // Anulable
    
        public decimal SalaryNet => SalaryAmount?.Value ?? 0 + SalaryBonus?.Value ?? 0 - PensionContribution?.Value ?? 0 - OtherDeductions?.Value ?? 0;

        // Constructor sin parámetros para EF Core
        private Payroll() { }

        public Payroll(int teacherId, SalaryAmount salaryAmount, PensionContribution pensionContribution, SalaryBonus salaryBonus, OtherDeductions otherDeductions)
        {
            TeacherId = teacherId;
            SalaryAmount = salaryAmount;
            PensionContribution = pensionContribution;
            SalaryBonus = salaryBonus;
            OtherDeductions = otherDeductions;
        }

        public void UpdatePayroll(SalaryAmount salaryAmount, PensionContribution pensionContribution, SalaryBonus salaryBonus, OtherDeductions otherDeductions)
        {
            SalaryAmount = salaryAmount;
            PensionContribution = pensionContribution;
            SalaryBonus = salaryBonus;
            OtherDeductions = otherDeductions;
        }
    }

}