using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Configuración de la entidad Payroll
        builder.Entity<Payroll>(entity =>
        {
            entity.HasKey(p => p.Id); // Clave principal

            // Configurar los objetos de valor con nombres de columnas específicos
            entity.OwnsOne(p => p.SalaryAmount, sa =>
            {
                sa.Property(p => p.Value).HasColumnName("salary_amount").IsRequired();
            });

            entity.OwnsOne(p => p.PensionContribution, pc =>
            {
                pc.Property(p => p.Value).HasColumnName("pension_contribution").IsRequired();
            });

            entity.OwnsOne(p => p.SalaryBonus, sb =>
            {
                sb.Property(p => p.Value).HasColumnName("salary_bonus").IsRequired();
            });

            entity.OwnsOne(p => p.OtherDeductions, od =>
            {
                od.Property(p => p.Value).HasColumnName("other_deductions").IsRequired();
            });

            // Ignoramos SalaryNet ya que es calculado dinámicamente
            entity.Ignore(p => p.SalaryNet);
        });

        base.OnModelCreating(builder);
    }

}
