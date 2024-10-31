namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Commands;

/// <summary>
/// Command to create a payroll entry.
/// </summary>
/// <param name="TeacherId">
/// The unique identifier for the teacher associated with this payroll.
/// </param>
/// <param name="SalaryAmount">
/// The base salary amount for the payroll entry.
/// </param>
/// <param name="PensionContribution">
/// The amount contributed to the pension fund.
/// </param>
/// <param name="SalaryBonus">
/// The bonus amount added to the base salary.
/// </param>
/// <param name="OtherDeductions">
/// Other deductions applied to the payroll.
/// </param>
/// <param name="DatePayment">
/// The date when the payroll is issued.
/// </param>
/// <param name="PaymentMethod">
/// The payment method used for the payroll.
/// </param>
/// <param name="Account">
/// The account number or identifier for the payment destination.
/// </param>
/// <param name="Observation">
/// Additional notes or observations related to the payroll entry.
/// </param>
public record CreatePayrollCommand(
    int TeacherId,
    decimal SalaryAmount,
    decimal PensionContribution,
    decimal SalaryBonus,
    decimal OtherDeductions,
    DateTime DatePayment,
    string PaymentMethod,
    string Account,
    string Observation);