using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.ValueObjects;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Services;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.PayrollManagement.Application.Internal.CommandServices;

public class PayrollCommandService : IPayrollCommandService
{
    private readonly IPayrollRepository _payrollRepository;
    private readonly IUnitOfWork _unitOfWork;

    // Constructor
    public PayrollCommandService(IPayrollRepository payrollRepository, IUnitOfWork unitOfWork)
    {
        _payrollRepository = payrollRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Payroll?> Handle(CreatePayrollCommand command)
    {
        var payroll = new Payroll(
            command.TeacherId,
            new SalaryAmount(command.SalaryAmount),
            new PensionContribution(command.PensionContribution),
            new SalaryBonus(command.SalaryBonus),
            new OtherDeductions(command.OtherDeductions),
            new DatePayment(command.DatePayment),
            new PaymentMethod(command.PaymentMethod),
            new Account(command.Account),
            new Observation(command.Observation)
        );

        await _payrollRepository.AddAsync(payroll);
        await _unitOfWork.CompleteAsync(); // Aquí ya puedes usar _unitOfWork
        return payroll;
    }

    public async Task<Payroll?> Handle(UpdatePayrollCommand command)
    {
        var payroll = await _payrollRepository.GetByIdAsync(command.Id);
        if (payroll == null) return null;

        payroll.UpdatePayroll(
            new SalaryAmount(command.SalaryAmount),
            new PensionContribution(command.PensionContribution),
            new SalaryBonus(command.SalaryBonus),
            new OtherDeductions(command.OtherDeductions),
            new DatePayment(command.DatePayment),
            new PaymentMethod(command.PaymentMethod),
            new Account(command.Account),
            new Observation(command.Observation)
        );

        _payrollRepository.Update(payroll);
        await _unitOfWork.CompleteAsync();
        return payroll;
    }
}
