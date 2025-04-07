using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Data.Mappings
{
    public class PessoaJuridicaMap : IEntityTypeConfiguration<PessoaJuridica>
    {
        public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder.ToTable("PessoaJuridica");

            builder.HasKey(p => p.Id);

            //campos de pessoa
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
            //endereço
            builder.OwnsOne(p => p.Endereco, endereco =>
            {

                endereco.Property(e => e.Cep)
                    .HasColumnName("Cep")
                    .HasMaxLength(10);

                endereco.Property(e => e.Logradouro)
                    .HasColumnName("Logradouro")
                    .HasMaxLength(100);

                endereco.Property(e => e.Numero)
                    .HasColumnName("Numero")
                    .HasMaxLength(20);

                endereco.Property(e => e.Complemento)
                    .HasColumnName("Complemento")
                    .HasMaxLength(100);

                endereco.Property(e => e.Bairro)
                    .HasColumnName("Bairro")
                    .HasMaxLength(60);

                endereco.Property(e => e.Localidade)
                    .HasColumnName("Localidade")
                    .HasMaxLength(60);

                endereco.Property(e => e.Uf)
                    .HasColumnName("Uf")
                    .HasMaxLength(2);

                endereco.Property(e => e.Ibge)
                    .HasColumnName("Ibge")
                    .HasMaxLength(10);
            });


            //campos de pessoa jurídica
            builder.Property(p => p.RazaoSocial).IsRequired().HasMaxLength(100);
            builder.Property(p => p.NomeFantasia).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Cnpj).IsRequired().HasMaxLength(18);

            builder.HasDiscriminator<string>("TipoPessoa")
                .HasValue<PessoaJuridica>("PessoaJuridica");


        }

    }
}
