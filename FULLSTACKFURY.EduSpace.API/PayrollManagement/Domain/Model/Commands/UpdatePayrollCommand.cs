namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Commands
{
    public class UpdatePayrollCommand
    {
        public int Id { get; }
        public decimal SalaryAmount { get; }
        public decimal PensionContribution { get; }
        public decimal SalaryBonus { get; }
        public decimal OtherDeductions { get; }
        public DateTime DatePayment { get; }
        public string PaymentMethod { get; }
        public string Account { get; }
        public string Observation { get; }

        public UpdatePayrollCommand(
            int id,
            decimal salaryAmount,
            decimal pensionContribution,
            decimal salaryBonus,
            decimal otherDeductions,
            DateTime datePayment,
            string paymentMethod,
            string account,
            string observation)
        {
            Id = id;
            SalaryAmount = salaryAmount;
            PensionContribution = pensionContribution;
            SalaryBonus = salaryBonus;
            OtherDeductions = otherDeductions;
            DatePayment = datePayment;
            PaymentMethod = paymentMethod ?? throw new ArgumentException("El método de pago no puede ser nulo o vacío.");
            Account = account ?? throw new ArgumentException("La cuenta no puede ser nula o vacía.");
            Observation = observation; // Puede ser nulo o vacío
        }
    }
}