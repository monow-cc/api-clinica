﻿// <auto-generated />
using System;
using BackEnd_Clinica.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd_Clinica.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230416073400_add-resultado")]
    partial class addresultado
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("BackEnd_Clinica.Model.Agendamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClinicaId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Metodo")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Pago")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ProfissionalClinicaId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("TratamentoClinicaId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("ProfissionalClinicaId");

                    b.HasIndex("TratamentoClinicaId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Clinica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProprietarioId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProprietarioId");

                    b.ToTable("Clinicas");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.GeradorPaciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClinicaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.HasIndex("PacienteId");

                    b.ToTable("GeradorPacientes");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Altura")
                        .HasColumnType("TEXT");

                    b.Property<string>("Bairro")
                        .HasColumnType("TEXT");

                    b.Property<long>("Cadastro")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cidade")
                        .HasColumnType("TEXT");

                    b.Property<long>("Cpf")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Nacimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Peso")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rua")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sexo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.PacienteClinica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClinicaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.HasIndex("PacienteId");

                    b.ToTable("PacientesClinica");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Profissional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Profissional");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.ProfissionalClinica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClinicaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProfissionalId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("ProfissionalClinicas");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Proprietario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Proprietarios");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Receita", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PacienteClinicaId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PacienteClinicaId");

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.ReceitaArquivos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ReceitaId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReceitaId");

                    b.ToTable("ReceitaArquivos");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Resultado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PacienteClinicaId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PacienteClinicaId");

                    b.ToTable("Resultados");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.ResultadoArquivo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResultadoId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ResultadoId");

                    b.ToTable("ResultadoArquivos");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.TratamentoClinica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClinicaId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deletado")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("MostrarApp")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Valor")
                        .HasColumnType("REAL");

                    b.Property<float>("ValorCusto")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.ToTable("TratamentoClinicas");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClinicaId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Agendamento", b =>
                {
                    b.HasOne("BackEnd_Clinica.Model.Clinica", "Clinica")
                        .WithMany()
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_Clinica.Model.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_Clinica.Model.ProfissionalClinica", "ProfissionalClinica")
                        .WithMany()
                        .HasForeignKey("ProfissionalClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_Clinica.Model.TratamentoClinica", "TratamentoClinica")
                        .WithMany("Agendamentos")
                        .HasForeignKey("TratamentoClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Paciente");

                    b.Navigation("ProfissionalClinica");

                    b.Navigation("TratamentoClinica");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Clinica", b =>
                {
                    b.HasOne("BackEnd_Clinica.Model.Proprietario", "Proprietario")
                        .WithMany()
                        .HasForeignKey("ProprietarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proprietario");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.GeradorPaciente", b =>
                {
                    b.HasOne("BackEnd_Clinica.Model.Clinica", "Clinica")
                        .WithMany()
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_Clinica.Model.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.PacienteClinica", b =>
                {
                    b.HasOne("BackEnd_Clinica.Model.Clinica", "Clinica")
                        .WithMany("PacienteClinicas")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_Clinica.Model.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.ProfissionalClinica", b =>
                {
                    b.HasOne("BackEnd_Clinica.Model.Clinica", "Clinica")
                        .WithMany("ProfissionalClinicas")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd_Clinica.Model.Profissional", "Profissional")
                        .WithMany("Clinicas")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Receita", b =>
                {
                    b.HasOne("BackEnd_Clinica.Model.PacienteClinica", "PacienteClinica")
                        .WithMany("Receitas")
                        .HasForeignKey("PacienteClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PacienteClinica");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.ReceitaArquivos", b =>
                {
                    b.HasOne("BackEnd_Clinica.Model.Receita", "Receita")
                        .WithMany("ReceitaArquivos")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receita");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Resultado", b =>
                {
                    b.HasOne("BackEnd_Clinica.Model.PacienteClinica", "PacienteClinica")
                        .WithMany()
                        .HasForeignKey("PacienteClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PacienteClinica");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.ResultadoArquivo", b =>
                {
                    b.HasOne("BackEnd_Clinica.Model.Resultado", "Resultado")
                        .WithMany("ResultadoArquivos")
                        .HasForeignKey("ResultadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resultado");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.TratamentoClinica", b =>
                {
                    b.HasOne("BackEnd_Clinica.Model.Clinica", "Clinica")
                        .WithMany("TratamentoClinicas")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.User", b =>
                {
                    b.HasOne("BackEnd_Clinica.Model.Clinica", "Clinica")
                        .WithMany()
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Clinica", b =>
                {
                    b.Navigation("PacienteClinicas");

                    b.Navigation("ProfissionalClinicas");

                    b.Navigation("TratamentoClinicas");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.PacienteClinica", b =>
                {
                    b.Navigation("Receitas");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Profissional", b =>
                {
                    b.Navigation("Clinicas");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Receita", b =>
                {
                    b.Navigation("ReceitaArquivos");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.Resultado", b =>
                {
                    b.Navigation("ResultadoArquivos");
                });

            modelBuilder.Entity("BackEnd_Clinica.Model.TratamentoClinica", b =>
                {
                    b.Navigation("Agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
