﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(TareasContext))]
    [Migration("20240212205740_initialData")]
    partial class initialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c11"),
                            Nombre = "Trabajo",
                            Peso = 10
                        },
                        new
                        {
                            CategoriaId = new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c12"),
                            Nombre = "Ocio",
                            Peso = 1
                        });
                });

            modelBuilder.Entity("api.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Prioridad")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c13"),
                            CategoriaId = new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c11"),
                            Fecha = new DateTime(2024, 2, 12, 15, 57, 39, 849, DateTimeKind.Local).AddTicks(7544),
                            Prioridad = 0,
                            Titulo = "Aprender .NET"
                        },
                        new
                        {
                            TareaId = new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c15"),
                            CategoriaId = new Guid("c5a32371-0b2a-4694-84ce-6d08fa053c12"),
                            Fecha = new DateTime(2024, 2, 12, 15, 57, 39, 849, DateTimeKind.Local).AddTicks(7557),
                            Prioridad = 2,
                            Titulo = "Jugar Play"
                        });
                });

            modelBuilder.Entity("api.Models.Tarea", b =>
                {
                    b.HasOne("api.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("api.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
