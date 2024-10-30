using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
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

            // Mapeo de propiedades primitivas directamente
            entity.Property(p => p.SalaryAmount).HasColumnName("salary_amount").IsRequired();
            entity.Property(p => p.PensionContribution).HasColumnName("pension_contribution").IsRequired();
            entity.Property(p => p.SalaryBonus).HasColumnName("salary_bonus").IsRequired();
            entity.Property(p => p.OtherDeductions).HasColumnName("other_deductions").IsRequired();
            entity.Property(p => p.SalaryNet).HasColumnName("salary_net").IsRequired();
            entity.Property(p => p.DatePayment).HasColumnName("date_payment").IsRequired();
            entity.Property(p => p.PaymentMethod).HasColumnName("payment_method").HasMaxLength(50).IsRequired();
            entity.Property(p => p.Account).HasColumnName("account").HasMaxLength(50).IsRequired();
            entity.Property(p => p.Observation).HasColumnName("observation").HasMaxLength(250);
        });

        // Agregar datos de seeding para Teacher
        builder.Entity<Teacher>().HasData(
            new Teacher("John Doe") { Id = 1 },
            new Teacher("Jane Smith") { Id = 2 },
            new Teacher("Michael Johnson") { Id = 3 }
        );

        //Teacher Profiles Context
        builder.Entity<TeacherProfile>().HasKey(tp => tp.Id);
        builder.Entity<TeacherProfile>().Property(tp => tp.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TeacherProfile>().Property(tp => tp.AdministratorId).IsRequired();
        builder.Entity<TeacherProfile>().OwnsOne(tp => tp.ProfileName,
            pn =>
            {
                pn.WithOwner().HasForeignKey("Id");
                pn.Property(tp => tp.FirstName).HasColumnName("FirstName");
                pn.Property(tp => tp.LastName).HasColumnName("LastName");
            });

        builder.Entity<TeacherProfile>().OwnsOne(tp => tp.ProfilePrivateInformation,
            pi =>
            {
                pi.WithOwner().HasForeignKey("Id");
                pi.Property(tp => tp.Email).HasColumnName("Email");
                pi.Property(tp => tp.Dni).HasColumnName("Dni");
                pi.Property(tp => tp.Address).HasColumnName("Address");
                pi.Property(tp => tp.Phone).HasColumnName("Phone");

            });
        
        
        
        base.OnModelCreating(builder);
        
        //#TODO Add configurations here
        
        builder.UseSnakeCaseNamingConvention();
    }
}