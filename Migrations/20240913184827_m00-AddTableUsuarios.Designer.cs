﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using gerenciamentoapirest.Data;

#nullable disable

namespace gerenciamentoapirest.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20240913184827_m00-AddTableUsuarios")]
    partial class m00AddTableUsuarios
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("gerenciamentoapirest.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Perfil")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@email.com.br",
                            Nome = "Administrator",
                            Perfil = 0,
                            Senha = "$2a$11$GbP0e.pm/yOZgovto29pWuUe4Nfq6OrUp284mpOVJPD3zdybCO0mW"
                        },
                        new
                        {
                            Id = 2,
                            Email = "cliente@email.com.br",
                            Nome = "Cliente",
                            Perfil = 1,
                            Senha = "$2a$11$XxY7IAEW.4hCC6XTBk3l4eQgCz28S1JBkxMfNLVIPX.sYh/8uUxV6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}