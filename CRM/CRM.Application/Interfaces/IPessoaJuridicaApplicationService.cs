using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using CRM.Domain.Entities;
using RMB.Abstractions.Application;
using RMB.Abstractions.Shared.Contracts.Responses;
using RMB.Abstractions.UseCases;


namespace CRM.Application.Interfaces
{

    /*    public interface IPessoaJuridicaApplicationService  
        {
            Task<PessoaJuridicaDto> AddAsync(PessoaJuridicaCreateCommand command);
            Task<PessoaJuridicaDto> UpdateAsync(PessoaJuridicaUpdateCommand command);
            Task<PessoaJuridicaDto> DeleteAsync(PessoaJuridicaDeleteCommand command);
            Task<List<PessoaJuridicaDto>?> GetAllAsync();
            Task<PessoaJuridicaDto?> GetByIdAsync(Guid id);

        }
    */
    public interface IPessoaJuridicaApplicationService :
        IBaseAddApplication<PessoaJuridicaCreateCommand, PessoaJuridicaDto>,
        IBaseUpdateApplication<PessoaJuridicaUpdateCommand, PessoaJuridicaDto>,
        IBaseDeleteApplication<PessoaJuridicaDeleteCommand, PessoaJuridicaDto>,
        IBaseQueryApplication<PessoaJuridica, PessoaJuridicaDto>,
        IBasePaginatedQueryApplication<PessoaJuridica, PaginatedResult<PessoaJuridicaDto>>
    {
    }

}
