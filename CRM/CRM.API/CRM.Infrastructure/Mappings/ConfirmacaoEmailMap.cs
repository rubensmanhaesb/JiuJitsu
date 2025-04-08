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
    public class ConfirmacaoEmailMap : IEntityTypeConfiguration<ConfirmacaoEmail>
    {
        public void Configure(EntityTypeBuilder<ConfirmacaoEmail> builder)
        {

            builder.ToTable("ConfirmacoesEmail");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Token)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(x => x.ExpiraEm)
                .IsRequired();

            builder.Property(x => x.ConfirmadoEm)
                .IsRequired(false);

            builder.HasIndex(x => x.Token)
                .IsUnique();

            builder.HasOne(c => c.Pessoa)
                   .WithMany(p => p.ConfirmacoesEmail)
                   .HasForeignKey(c => c.PessoaId)
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
