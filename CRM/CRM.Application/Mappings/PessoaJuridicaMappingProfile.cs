using AutoMapper;
using CRM.Domain.Entities;
using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Mappings
{
    public class PessoaJuridicaMappingProfile : Profile
    {
        public PessoaJuridicaMappingProfile()
        {
            CreateMap<PessoaJuridicaCreateCommand, PessoaJuridica>()
                .AfterMap((command, entity) =>
                {
                    entity.Id = Guid.NewGuid();
                });

            CreateMap<PessoaJuridicaUpdateCommand, PessoaJuridica>();

            CreateMap<PessoaJuridica, PessoaJuridicaDto>();
        }
    }
}
