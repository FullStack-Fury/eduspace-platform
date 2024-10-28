using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects;
using System;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates
{
    public class Payroll
    {
        public int Id { get; private set; }
        public int TeacherId { get; private set; }
        public SalaryAmount? SalaryAmount { get; private set; }
        public PensionContribution? PensionContribution { get; private set; }
        public SalaryBonus? SalaryBonus { get; private set; }
        public OtherDeductions? OtherDeductions { get; private set; }
        public SalaryNet SalaryNet { get; private set; } // Usamos el ValueObject para SalaryNet

        public Teacher Teacher { get; private set; }

        public DatePayment? DatePayment { get; private set; }
        public PaymentMethod? PaymentMethod { get; private set; }
        public Account? Account { get; private set; }
        public Observation? Observation { get; private set; }

        private Payroll() { }

        public Payroll(int teacherId, SalaryAmount salaryAmount, PensionContribution pensionContribution, SalaryBonus salaryBonus, OtherDeductions otherDeductions,
                       DatePayment datePayment, PaymentMethod paymentMethod, Account account, Observation observation)
        {
            TeacherId = teacherId;
            SalaryAmount = salaryAmount;
            PensionContribution = pensionContribution;
            SalaryBonus = salaryBonus;
            OtherDeductions = otherDeductions;
            DatePayment = datePayment;
            PaymentMethod = paymentMethod;
            Account = account;
            Observation = observation;
            CalculateSalaryNet();
        }

        public void UpdatePayroll(SalaryAmount salaryAmount, PensionContribution pensionContribution, SalaryBonus salaryBonus, OtherDeductions otherDeductions,
                                  DatePayment datePayment, PaymentMethod paymentMethod, Account account, Observation observation)
        {
            SalaryAmount = salaryAmount;
            PensionContribution = pensionContribution;
            SalaryBonus = salaryBonus;
            OtherDeductions = otherDeductions;
            DatePayment = datePayment;
            PaymentMethod = paymentMethod;
            Account = account;
            Observation = observation;
            CalculateSalaryNet();
        }

        private void CalculateSalaryNet()
        {
            var netValue = (SalaryAmount?.Value ?? 0) + (SalaryBonus?.Value ?? 0) - (PensionContribution?.Value ?? 0) - (OtherDeductions?.Value ?? 0);
            SalaryNet = new SalaryNet(netValue);
        }
    }
}
