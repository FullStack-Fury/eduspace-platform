using FULLSTACKFURY.EduSpace.API.IAM.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;

/// <summary>
/// Payroll aggregate root entity.
/// </summary>
/// <remarks>
/// This class is used to represent payroll details for a teacher in the application.
/// </remarks>
public partial class Payroll
{
    public int Id { get; private set; }
    public int TeacherId { get; private set; }
    public SalaryAmount SalaryAmount { get; private set; }
    public PensionContribution PensionContribution { get; private set; }
    public SalaryBonus SalaryBonus { get; private set; }
    public OtherDeductions OtherDeductions { get; private set; }
    public DatePayment DatePayment { get; private set; }
    public PaymentMethod PaymentMethod { get; private set; }
    public Observation? Observation { get; private set; }
    public SalaryNet SalaryNet { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Payroll"/> class based on the specified command.
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreatePayrollCommand"/> containing payroll details to initialize this instance.
    /// </param>
    public Payroll(CreatePayrollCommand command)
    {
        TeacherId = command.TeacherId;
        SalaryAmount = new SalaryAmount(command.SalaryAmount);
        PensionContribution = new PensionContribution(command.PensionContribution);
        SalaryBonus = new SalaryBonus(command.SalaryBonus);
        OtherDeductions = new OtherDeductions(command.OtherDeductions);
        DatePayment = new DatePayment(command.DatePayment);
        PaymentMethod = new PaymentMethod(command.PaymentMethod);
        Observation = command.Observation != null ? new Observation(command.Observation) : null;
        CalculateNetSalary();
    }

    /// <summary>
    /// Updates the current payroll instance with new details from the specified command.
    /// </summary>
    /// <param name="command">
    /// The <see cref="UpdatePayrollCommand"/> containing updated payroll details.
    /// </param>
    public void UpdatePayroll(UpdatePayrollCommand command)
    {
        SalaryAmount = new SalaryAmount(command.SalaryAmount);
        PensionContribution = new PensionContribution(command.PensionContribution);
        SalaryBonus = new SalaryBonus(command.SalaryBonus);
        OtherDeductions = new OtherDeductions(command.OtherDeductions);
        DatePayment = new DatePayment(command.DatePayment);
        PaymentMethod = new PaymentMethod(command.PaymentMethod);
        Observation = command.Observation != null ? new Observation(command.Observation) : null;
        CalculateNetSalary();
    }

    /// <summary>
    /// Calculates the net salary based on the following formula:
    /// Net Salary = SalaryAmount - PensionContribution + SalaryBonus - OtherDeductions
    /// </summary>
    private void CalculateNetSalary()
    {
        SalaryNet = new SalaryNet(SalaryAmount.Value - PensionContribution.Value + SalaryBonus.Value - OtherDeductions.Value);
    }
}
