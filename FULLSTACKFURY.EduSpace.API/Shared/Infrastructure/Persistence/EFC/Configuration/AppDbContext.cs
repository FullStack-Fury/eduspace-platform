using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.IAM.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.Profiles.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509.Qualified;

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
        
        // Administrators Profile Context

        builder.Entity<AdminProfile>().HasKey(ap => ap.Id);
        builder.Entity<AdminProfile>().Property(ap => ap.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<AdminProfile>().OwnsOne(ap => ap.ProfileName,
            pn =>
            {
                pn.WithOwner().HasForeignKey("Id");
                pn.Property(ap => ap.FirstName).HasColumnName("FirstName");
                pn.Property(ap => ap.LastName).HasColumnName("LastName");
            });
        builder.Entity<AdminProfile>().OwnsOne(ap => ap.ProfilePrivateInformation,
            pi =>
            {
                pi.WithOwner().HasForeignKey("Id");
                pi.Property(tp => tp.Email).HasColumnName("Email");
                pi.Property(tp => tp.Dni).HasColumnName("Dni");
                pi.Property(tp => tp.Address).HasColumnName("Address");
                pi.Property(tp => tp.Phone).HasColumnName("Phone");
            });
        
        //IAM CONTEXT

        builder.Entity<Account>().HasKey(a => a.Id);
        builder.Entity<Account>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Account>().Property(a => a.Username).IsRequired();
        builder.Entity<Account>().Property(a => a.Password).IsRequired();
        builder.Entity<Account>().Property(a => a.Role).IsRequired();
        
        
        //Reservations Context

        builder.Entity<Reservation>().HasKey(r => r.Id);
        builder.Entity<Reservation>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reservation>().Property(r => r.Title).IsRequired();
        builder.Entity<Reservation>().OwnsOne(r => r.ReservationDate,
            rd =>
            {
                rd.WithOwner().HasForeignKey("Id");
                rd.Property(r => r.Start).HasColumnName("Start");
                rd.Property(r => r.End).HasColumnName("End");
            });
        builder.Entity<Reservation>().OwnsOne(r => r.AreaId,
            ai =>
            {
                ai.WithOwner().HasForeignKey("Id");
                ai.Property(r => r.Identifier).HasColumnName("AreaId");
            });
        builder.Entity<Reservation>().OwnsOne(r => r.TeacherId,
            ti =>
            {
                ti.WithOwner().HasForeignKey("Id");
                ti.Property(r => r.TeacherIdentifier).HasColumnName("TeacherId");
            });
        
        // Payroll Context
        builder.Entity<Payroll>().HasKey(p => p.Id);
        builder.Entity<Payroll>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payroll>().Property(p => p.TeacherId).IsRequired();
        builder.Entity<Payroll>().Property(p => p.SalaryNet).IsRequired();

        // Configuración de SalaryAmount como Owned Type
        builder.Entity<Payroll>().OwnsOne(p => p.SalaryAmount, sa =>
            {
                sa.WithOwner().HasForeignKey("Id");
                sa.Property(p => p.Value).HasColumnName("SalaryAmount").IsRequired();
            });

        // Configuración de PayrollAdjustment como Owned Type
        builder.Entity<Payroll>().OwnsOne(p => p.PayrollAdjustment, pa =>
            {
                pa.WithOwner().HasForeignKey("Id");
                pa.Property(p => p.PensionContribution).HasColumnName("PensionContribution").IsRequired();
                pa.Property(p => p.SalaryBonus).HasColumnName("SalaryBonus").IsRequired();
            });

        // Configuración de DatePayment como Owned Type sin clave
        builder.Entity<Payroll>().OwnsOne(p => p.DatePayment, dp =>
            {
                dp.WithOwner().HasForeignKey("Id");
                dp.Property(d => d.Value).HasColumnName("DatePayment").IsRequired();
            });

        
        
        // Configuración para la entidad Report
        builder.Entity<Report>().HasKey(r => r.Id);
        builder.Entity<Report>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Report>().Property(r => r.ResourceId).IsRequired();
        builder.Entity<Report>().Property(r => r.KindOfReport).IsRequired();
        builder.Entity<Report>().Property(r => r.Description).IsRequired();
        builder.Entity<Report>().Property(r => r.CreatedAt).IsRequired();
        builder.Entity<Report>().Property(r => r.Status).IsRequired(); 

        base.OnModelCreating(builder);
        
        //#TODO Add configurations here
        
        builder.UseSnakeCaseNamingConvention();
    }
}