namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Commands
{
    public class UpdatePayrollCommand
    {
        public int Id { get; }
        public decimal SalaryAmount { get; }
        public decimal PensionContribution { get; }
        public decimal SalaryBonus { get; }
        public decimal OtherDeductions { get; }

        public UpdatePayrollCommand(int id, decimal salaryAmount, decimal pensionContribution, decimal salaryBonus, decimal otherDeductions)
        {
            Id = id;
            SalaryAmount = salaryAmount;
            PensionContribution = pensionContribution;
            SalaryBonus = salaryBonus;
            OtherDeductions = otherDeductions;
        }
    }
}