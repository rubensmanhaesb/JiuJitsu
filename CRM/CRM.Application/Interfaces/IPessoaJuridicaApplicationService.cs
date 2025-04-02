using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using CRM.Domain.Entities;
using RMB.Abstractions.Application;
using RMB.Abstractions.Shared.Contracts.Paginations.Responses;

namespace CRM.Application.Interfaces
{
   public interface IPessoaJuridicaApplicationService :
        IBaseAddApplication<PessoaJuridicaCreateCommand, PessoaJuridicaDto>,
        IBaseUpdateApplication<PessoaJuridicaUpdateCommand, PessoaJuridicaDto>,
        IBaseDeleteApplication<PessoaJuridicaDeleteCommand, PessoaJuridicaDto>,
        IBaseQueryApplication<PessoaJuridica, PessoaJuridicaDto>,
        IBasePaginatedQueryApplication<PessoaJuridica, PaginatedResult<PessoaJuridicaDto>>
    {
    }

}
