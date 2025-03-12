using AutoMapper;
using CRM.Domain.Entities;
using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;  


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
            
            CreateMap<PessoaJuridicaDeleteCommand, PessoaJuridica>();

            CreateMap<PessoaJuridica, PessoaJuridicaDto>();


        }
    }
}
