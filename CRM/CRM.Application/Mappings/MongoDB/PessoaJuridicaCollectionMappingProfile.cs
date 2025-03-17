using AutoMapper;
using CRM.Application.Dtos.PessoaJuridica;
using CRM.Domain.MongoDB.Collection.Logs;


namespace CRM.Application.Mappings.MongoDB
{
    public class PessoaJuridicaCollectionMappingProfile: Profile
    {
        public PessoaJuridicaCollectionMappingProfile()
        {
            CreateMap<PessoaJuridicaCollection, PessoaJuridicaDto>().ReverseMap();
        }
    }
}
