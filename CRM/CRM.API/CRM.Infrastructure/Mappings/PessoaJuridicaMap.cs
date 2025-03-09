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
            
            //campos de pessoa jurídica
            builder.Property(p => p.RazaoSocial).IsRequired().HasMaxLength(100);
            builder.Property(p => p.NomeFantasia).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Cnpj).IsRequired().HasMaxLength(14);

            builder.HasDiscriminator<string>("TipoPessoa")
                .HasValue<PessoaJuridica>("PessoaJuridica");
                //.HasValue<PessoaFisica>("PessoaFisica");


        }

    }
}
