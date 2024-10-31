namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Commands;

/// <summary>
/// Command to update an existing payroll entry.
/// </summary>
/// <param name="PayrollId">
/// The unique identifier for the payroll entry to be updated.
/// </param>
/// <param name="SalaryAmount">
/// The updated base salary amount for the payroll entry.
/// </param>
/// <param name="PensionContribution">
/// The updated amount contributed to the pension fund.
/// </param>
/// <param name="SalaryBonus">
/// The updated bonus amount added to the base salary.
/// </param>
/// <param name="OtherDeductions">
/// Updated other deductions applied to the payroll.
/// </param>
/// <param name="DatePayment">
/// The updated date when the payroll is issued.
/// </param>
/// <param name="PaymentMethod">
/// The updated payment method used for the payroll.
/// </param>
/// <param name="Account">
/// The updated account number or identifier for the payment destination.
/// </param>
/// <param name="Observation">
/// Additional notes or observations related to the payroll entry.
/// </param>
public record UpdatePayrollCommand(
    int PayrollId,
    decimal SalaryAmount,
    decimal PensionContribution,
    decimal SalaryBonus,
    decimal OtherDeductions,
    DateTime DatePayment,
    string PaymentMethod,
    string Account,
    string Observation);