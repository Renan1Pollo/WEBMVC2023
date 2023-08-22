﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEBMVC.Models;

#nullable disable

namespace WEBMVC.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20230820230553_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WEBMVC.Models.Aluno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("aniversario")
                        .HasColumnType("datetime2");

                    b.Property<int?>("cursoid")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("periodo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("cursoid");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("WEBMVC.Models.Atendimento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("alunoid")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("salaid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("alunoid");

                    b.HasIndex("salaid");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("WEBMVC.Models.Curso", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("WEBMVC.Models.Sala", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("equipamentos")
                        .HasColumnType("int");

                    b.Property<string>("situacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("id");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("WEBMVC.Models.Aluno", b =>
                {
                    b.HasOne("WEBMVC.Models.Curso", "curso")
                        .WithMany()
                        .HasForeignKey("cursoid");

                    b.Navigation("curso");
                });

            modelBuilder.Entity("WEBMVC.Models.Atendimento", b =>
                {
                    b.HasOne("WEBMVC.Models.Aluno", "aluno")
                        .WithMany()
                        .HasForeignKey("alunoid");

                    b.HasOne("WEBMVC.Models.Sala", "sala")
                        .WithMany()
                        .HasForeignKey("salaid");

                    b.Navigation("aluno");

                    b.Navigation("sala");
                });
#pragma warning restore 612, 618
        }
    }
}
