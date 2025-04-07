using AutoMapper;
using CRM.Domain.Entities;
using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using RMB.Core.ValuesObjects.Logradouro;


namespace CRM.Application.Mappings.SqlServer
{
    public class PessoaJuridicaMappingProfile : Profile
    {
        public PessoaJuridicaMappingProfile()
        {
            // Mapeia EnderecoCommand para Endereco
            CreateMap<EnderecoCommand, Endereco>();

            CreateMap<PessoaJuridicaCreateCommand, PessoaJuridica>()
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                .AfterMap((command, entity) =>
                {
                    entity.Id = Guid.NewGuid();
                });

            CreateMap<PessoaJuridicaUpdateCommand, PessoaJuridica>()
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));

            CreateMap<PessoaJuridicaDeleteCommand, PessoaJuridica>();

            CreateMap<PessoaJuridica, PessoaJuridicaDto>();


        }
    }
}
