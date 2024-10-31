using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Interface.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Interface.REST.Transform;

/// <summary>
/// Assembler class to transform Payroll to PayrollResource
/// </summary>
public static class PayrollResourceFromEntityAssembler
{
    /// <summary>
    /// Transform Payroll entity to PayrollResource
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Payroll"/> entity to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="PayrollResource"/> with the values from the entity
    /// </returns>
    public static PayrollResource ToResourceFromEntity(Payroll entity)
    {
        return new PayrollResource(
            entity.Id,
            entity.TeacherId,
            entity.SalaryAmount.Value,
            entity.PensionContribution.Value,
            entity.SalaryBonus.Value,
            entity.OtherDeductions.Value,
            entity.DatePayment.Value,
            entity.PaymentMethod.Value,
            entity.Observation?.Value,  // Sin Account
            entity.SalaryNet.Value);
    }
}