﻿// <auto-generated />
using System;
using CRM.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRM.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250408145839_ConfirmacaoEmail")]
    partial class ConfirmacaoEmail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("crm")
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CRM.Domain.Entities.ConfirmacaoEmail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ConfirmadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiraEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.ToTable("ConfirmacoesEmail", "crm");
                });

            modelBuilder.Entity("CRM.Domain.Entities.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("EmailConfirmado")
                        .HasColumnType("bit");

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.HasKey("Id");

                    b.ToTable("PessoaJuridica", "crm");

                    b.HasDiscriminator<string>("TipoPessoa").HasValue("Pessoa");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CRM.Domain.Entities.PessoaJuridica", b =>
                {
                    b.HasBaseType("CRM.Domain.Entities.Pessoa");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasDiscriminator().HasValue("PessoaJuridica");
                });

            modelBuilder.Entity("CRM.Domain.Entities.ConfirmacaoEmail", b =>
                {
                    b.HasOne("CRM.Domain.Entities.Pessoa", "Pessoa")
                        .WithMany("ConfirmacoesEmail")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CRM.Domain.Entities.Pessoa", b =>
                {
                    b.OwnsOne("RMB.Core.ValuesObjects.Logradouro.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("PessoaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("nvarchar(60)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Complemento")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Complemento");

                            b1.Property<string>("Ibge")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)")
                                .HasColumnName("Ibge");

                            b1.Property<string>("Localidade")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("nvarchar(60)")
                                .HasColumnName("Localidade");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Logradouro");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)")
                                .HasColumnName("Numero");

                            b1.Property<string>("Uf")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("nvarchar(2)")
                                .HasColumnName("Uf");

                            b1.HasKey("PessoaId");

                            b1.ToTable("PessoaJuridica", "crm");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("CRM.Domain.Entities.Pessoa", b =>
                {
                    b.Navigation("ConfirmacoesEmail");
                });
#pragma warning restore 612, 618
        }
    }
}
