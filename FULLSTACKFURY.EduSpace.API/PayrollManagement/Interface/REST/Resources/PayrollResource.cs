namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Interface.REST.Resources;

/// <summary>
/// Represents a payroll resource.
/// </summary>
/// <param name="Id">
/// The unique identifier for the payroll entry.
/// </param>
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
/// <param name="Observation">
/// Additional notes or observations related to the payroll entry.
/// </param>
/// <param name="SalaryNet">
/// The net salary amount after all deductions and contributions.
/// </param>
public record PayrollResource(
    int Id,
    int TeacherId,
    decimal SalaryAmount,
    decimal PensionContribution,
    decimal SalaryBonus,
    decimal OtherDeductions,
    DateTime DatePayment,
    string PaymentMethod,
    string? Observation,
    decimal SalaryNet);