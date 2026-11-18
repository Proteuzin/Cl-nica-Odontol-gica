using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace appClinicaOdontologica.Models;

public partial class DbClinicaOdontologicaContext : DbContext
{
    public DbClinicaOdontologicaContext()
    {
    }

    public DbClinicaOdontologicaContext(DbContextOptions<DbClinicaOdontologicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agendamento> Agendamentos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Procedimento> Procedimentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SENAI; Database=dbClinicaOdontologica; User Id=sa; Password=senai.123; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agendame__3214EC077C252C0B");

            entity.ToTable("Agendamento");

            entity.Property(e => e.Observacoes)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Paciente).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agendamento_Paciente");

            entity.HasOne(d => d.Procedimento).WithMany(p => p.Agendamentos)
                .HasForeignKey(d => d.ProcedimentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agendamento_Procedimento");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paciente__3214EC07A9D11C01");

            entity.ToTable("Paciente");

            entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1F8973104110C6A").IsUnique();

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NomeCompleto)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Procedimento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Procedim__3214EC077F3D95F6");

            entity.ToTable("Procedimento");

            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NomeProcedimento)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Procedimentos)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Procedimento_Paciente");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07801E8967");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Login, "UQ__Usuario__5E55825B385AB076").IsUnique();

            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
