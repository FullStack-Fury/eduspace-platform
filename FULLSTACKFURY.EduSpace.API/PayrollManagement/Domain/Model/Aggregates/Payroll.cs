using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using System;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates
{
    public class Payroll
    {
        public int Id { get; private set; }
        public int TeacherId { get; private set; }
        public Teacher Teacher { get; private set; }  // Relación con Teacher

        public decimal SalaryAmount { get; private set; }  
        public decimal PensionContribution { get; private set; }  
        public decimal SalaryBonus { get; private set; }  
        public decimal OtherDeductions { get; private set; }  
        public decimal SalaryNet { get; private set; }  // Propiedad calculada
        public DateTime DatePayment { get; private set; }
        public string PaymentMethod { get; private set; }
        public string Account { get; private set; }
        public string Observation { get; private set; }

        // Constructor sin parámetros para EF Core
        private Payroll() { }

        public Payroll(int teacherId, decimal salaryAmount, decimal pensionContribution, decimal salaryBonus, decimal otherDeductions,
                       DateTime datePayment, string paymentMethod, string account, string observation)
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

            // Calcular SalaryNet
            CalculateNetSalary();
        }

        public void UpdatePayroll(decimal salaryAmount, decimal pensionContribution, decimal salaryBonus, decimal otherDeductions,
                                  DateTime datePayment, string paymentMethod, string account, string observation)
        {
            SalaryAmount = salaryAmount;
            PensionContribution = pensionContribution;
            SalaryBonus = salaryBonus;
            OtherDeductions = otherDeductions;
            DatePayment = datePayment;
            PaymentMethod = paymentMethod;
            Account = account;
            Observation = observation;

            // Calcular SalaryNet
            CalculateNetSalary();
        }

        private void CalculateNetSalary()
        {
            SalaryNet = SalaryAmount + SalaryBonus - PensionContribution - OtherDeductions;
        }
    }
}
