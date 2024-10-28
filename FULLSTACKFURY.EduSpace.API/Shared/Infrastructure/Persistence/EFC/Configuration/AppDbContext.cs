using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; } // Agregar DbSet para Teacher
    public DbSet<Payroll> Payrolls { get; set; } // DbSet para Payroll

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
        // Configuración de la entidad Teacher
        builder.Entity<Teacher>(entity =>
        {
            entity.HasKey(t => t.Id); // Clave principal para Teacher
            entity.Property(t => t.Name).HasColumnName("name").IsRequired(); // Nombre de profesor
        });

        // Configuración de la entidad Payroll
        builder.Entity<Payroll>(entity =>
        {
            entity.HasKey(p => p.Id); // Clave principal

            // Configurar la relación entre Payroll y Teacher
            entity.HasOne(p => p.Teacher)
                  .WithMany()
                  .HasForeignKey(p => p.TeacherId)
                  .IsRequired(); // Clave foránea hacia Teacher

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

            // Configurar los nuevos objetos de valor
            entity.OwnsOne(p => p.DatePayment, dp =>
            {
                dp.Property(p => p.Value).HasColumnName("date_payment").IsRequired();
            });

            entity.OwnsOne(p => p.PaymentMethod, pm =>
            {
                pm.Property(p => p.Value).HasColumnName("payment_method").IsRequired().HasMaxLength(50);
            });

            entity.OwnsOne(p => p.Account, a =>
            {
                a.Property(p => p.Value).HasColumnName("account").IsRequired().HasMaxLength(50);
            });

            entity.OwnsOne(p => p.Observation, obs =>
            {
                obs.Property(p => p.Value).HasColumnName("observation").HasMaxLength(250);
            });

            // Mapeo de SalaryNet como un ValueObject persistente
            entity.OwnsOne(p => p.SalaryNet, sn =>
            {
                sn.Property(p => p.Value).HasColumnName("salary_net").IsRequired();
            });
        });

        // Agregar datos de seeding para Teacher
        builder.Entity<Teacher>().HasData(
            new Teacher("John Doe") { Id = 1 },
            new Teacher("Jane Smith") { Id = 2 },
            new Teacher("Michael Johnson") { Id = 3 }
        );

        base.OnModelCreating(builder);
    }
}
