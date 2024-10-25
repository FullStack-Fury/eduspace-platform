namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Commands
{
    public class CreatePayrollCommand
    {
        public int TeacherId { get; }
        public decimal SalaryAmount { get; }
        public decimal PensionContribution { get; }
        public decimal SalaryBonus { get; }
        public decimal OtherDeductions { get; }

        public CreatePayrollCommand(int teacherId, decimal salaryAmount, decimal pensionContribution, decimal salaryBonus, decimal otherDeductions)
        {
            TeacherId = teacherId;
            SalaryAmount = salaryAmount;
            PensionContribution = pensionContribution;
            SalaryBonus = salaryBonus;
            OtherDeductions = otherDeductions;
        }
    }
}