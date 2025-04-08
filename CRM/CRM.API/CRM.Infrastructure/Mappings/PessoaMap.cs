using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Data.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("PessoaJuridica"); // toda a hierarquia vai pra essa tabela

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.EmailConfirmado);

            builder.OwnsOne(p => p.Endereco, endereco =>
            {
                endereco.Property(e => e.Cep).HasColumnName("Cep").HasMaxLength(10);
                endereco.Property(e => e.Logradouro).HasColumnName("Logradouro").HasMaxLength(100);
                endereco.Property(e => e.Numero).HasColumnName("Numero").HasMaxLength(20);
                endereco.Property(e => e.Complemento).HasColumnName("Complemento").HasMaxLength(100);
                endereco.Property(e => e.Bairro).HasColumnName("Bairro").HasMaxLength(60);
                endereco.Property(e => e.Localidade).HasColumnName("Localidade").HasMaxLength(60);
                endereco.Property(e => e.Uf).HasColumnName("Uf").HasMaxLength(2);
                endereco.Property(e => e.Ibge).HasColumnName("Ibge").HasMaxLength(10);
            });

            builder.HasMany(p => p.ConfirmacoesEmail)
                   .WithOne(c => c.Pessoa)
                   .HasForeignKey(c => c.PessoaId);
        }
    }
}
