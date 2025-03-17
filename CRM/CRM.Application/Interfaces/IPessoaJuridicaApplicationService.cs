using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using RMB.Abstractions.UseCases;


namespace CRM.Application.Interfaces
{
    public interface IPessoaJuridicaApplicationService  
    {
        Task<PessoaJuridicaDto> AddAsync(PessoaJuridicaCreateCommand command);
        Task<PessoaJuridicaDto> UpdateAsync(PessoaJuridicaUpdateCommand command);
        Task<PessoaJuridicaDto> DeleteAsync(PessoaJuridicaDeleteCommand command);
        Task<List<PessoaJuridicaDto>?> GetAllAsync();
        Task<PessoaJuridicaDto?> GetByIdAsync(Guid id);

    }
}
