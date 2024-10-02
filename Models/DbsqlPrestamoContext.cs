using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_PRESTAMOS.Models;

public partial class DbsqlPrestamoContext : DbContext
{
    public DbsqlPrestamoContext()
    {
    }

    public DbsqlPrestamoContext(DbContextOptions<DbsqlPrestamoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientHistory> ClientHistories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PenaltySetting> PenaltySettings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=BD-SQL\\DBSQL_PRESTAMO.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClienteId);

            entity.HasIndex(e => e.CompanyId, "IX_Clients_company_id");

            entity.HasIndex(e => e.Email, "IX_Clients_email").IsUnique();

            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("creation_date");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IdCard).HasColumnName("id_card");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Passport).HasColumnName("passport");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.PuntajeCredito).HasColumnName("puntaje_credito");

            entity.HasOne(d => d.Company).WithMany(p => p.Clients)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ClientHistory>(entity =>
        {
            entity.HasKey(e => e.HistorialId);

            entity.ToTable("ClientHistory");

            entity.HasIndex(e => e.ClienteId, "IX_ClientHistory_cliente_id");

            entity.HasIndex(e => e.PrestamoId, "IX_ClientHistory_prestamo_id");

            entity.Property(e => e.HistorialId).HasColumnName("historial_id");
            entity.Property(e => e.Accion).HasColumnName("accion");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.PrestamoId).HasColumnName("prestamo_id");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Cliente).WithMany(p => p.ClientHistories)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Prestamo).WithMany(p => p.ClientHistories).HasForeignKey(d => d.PrestamoId);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.EmailContacto).HasColumnName("email_contacto");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.TelefonoContacto).HasColumnName("telefono_contacto");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId);

            entity.HasIndex(e => e.CompanyId, "IX_Employees_company_id");

            entity.HasIndex(e => e.Email, "IX_Employees_email").IsUnique();

            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.Contrasena).HasColumnName("contrasena");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("creation_date");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("DATETIME")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IdCard).HasColumnName("id_card");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Passport)
                .HasColumnType("INTEGER")
                .HasColumnName("passport");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Rol)
                .HasColumnType("NUMERIC")
                .HasColumnName("rol");

            entity.HasOne(d => d.Company).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.PrestamoId);

            entity.HasIndex(e => e.ClienteId, "IX_Loans_cliente_id");

            entity.HasIndex(e => e.CompanyId, "IX_Loans_company_id");

            entity.HasIndex(e => e.EmpleadoId, "IX_Loans_empleado_id");

            entity.Property(e => e.PrestamoId).HasColumnName("prestamo_id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnType("BOOLEAN")
                .HasColumnName("activo");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaFin)
                .HasColumnType("DATE")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("DATE")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.MontoRestante).HasColumnName("monto_restante");
            entity.Property(e => e.MoraActiva)
                .HasDefaultValue(false)
                .HasColumnType("BOOLEAN")
                .HasColumnName("mora_activa");
            entity.Property(e => e.PlazoMeses).HasColumnName("plazo_meses");
            entity.Property(e => e.TasaInteres).HasColumnName("tasa_interes");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Loans)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Company).WithMany(p => p.Loans)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Loans)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Login");

            entity.Property(e => e.Active)
                .HasColumnType("NUMERIC")
                .HasColumnName("active");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.EmpleadoId).HasColumnName("empleado_id");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.User).HasColumnName("user");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PagoId);

            entity.HasIndex(e => e.PrestamoId, "IX_Payments_prestamo_id");

            entity.Property(e => e.PagoId).HasColumnName("pago_id");
            entity.Property(e => e.ATiempo)
                .HasDefaultValue(true)
                .HasColumnType("BOOLEAN")
                .HasColumnName("a_tiempo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaPago)
                .HasColumnType("DATE")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.Mora)
                .HasDefaultValue(0.0)
                .HasColumnName("mora");
            entity.Property(e => e.PrestamoId).HasColumnName("prestamo_id");

            entity.HasOne(d => d.Prestamo).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PrestamoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PenaltySetting>(entity =>
        {
            entity.HasKey(e => e.MoraId);

            entity.HasIndex(e => e.PrestamoId, "IX_PenaltySettings_prestamo_id");

            entity.Property(e => e.MoraId).HasColumnName("mora_id");
            entity.Property(e => e.Activa)
                .HasDefaultValue(true)
                .HasColumnType("BOOLEAN")
                .HasColumnName("activa");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.MontoMora)
                .HasDefaultValue(100.0)
                .HasColumnName("monto_mora");
            entity.Property(e => e.PrestamoId).HasColumnName("prestamo_id");

            entity.HasOne(d => d.Prestamo).WithMany(p => p.PenaltySettings)
                .HasForeignKey(d => d.PrestamoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
