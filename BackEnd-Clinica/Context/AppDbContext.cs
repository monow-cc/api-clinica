using BackEnd_Clinica.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Clinica.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profissional> Profissional { get; set;}
        public DbSet<ProfissionalClinica> ProfissionalClinicas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<PacienteClinica> PacientesClinica { get; set; }
        public DbSet<TratamentoClinica> TratamentoClinicas { get; set; }
        public DbSet<Agendamento> Agendamento { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração das chaves estrangeiras
            modelBuilder.Entity<Agendamento>()
               .HasOne(a => a.Clinica)
               .WithMany()
               .HasForeignKey(a => a.ClinicaId);

            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.ProfissionalClinica)
                .WithMany()
                .HasForeignKey(a => a.ProfissionalClinicaId);

            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Paciente)
                .WithMany()
                .HasForeignKey(a => a.PacienteId);
            modelBuilder.Entity<Agendamento>()
               .HasOne(a => a.TratamentoClinica)
               .WithMany(a => a.Agendamentos)
               .HasForeignKey(a => a.TratamentoClinicaId);
        }
    }
}
