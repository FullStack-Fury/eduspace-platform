using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.ValueObjects;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates; // Asegúrate de que las referencias estén correctas
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

        // Configuración de la entidad Report
        builder.Entity<Report>(entity =>
        {
            entity.HasKey(r => r.Id); // Clave principal

            entity.Property(r => r.KindOfReport).HasColumnName("kind_of_report").IsRequired(); // Configuración para KindOfReport
            entity.Property(r => r.Description).HasColumnName("description").IsRequired(); // Configuración para Description

            entity.OwnsOne(r => r.ResourceId, ri =>
            {
                ri.Property(r => r.Id).HasColumnName("resource_id").IsRequired();
            });

            // Usando un convertidor de valor para mapear ReportDate a DateTime
            entity.Property(r => r.CreatedAt)
                .HasConversion(
                    v => v.CreatedAt, // Convertir ReportDate a DateTime
                    v => new ReportDate(v) // Convertir DateTime a ReportDate
                )
                .HasColumnName("created_at")
                .IsRequired();
        });

        base.OnModelCreating(builder);
    }

}
