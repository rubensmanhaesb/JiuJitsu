using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using RMB.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces
{
    public interface IPessoaJuridicaApplicationService
    {
        Task<PessoaJuridicaDto> CreateAsync(PessoaJuridicaCreateCommand command);
        Task<PessoaJuridicaDto> UpdateAsync(PessoaJuridicaUpdateCommand command);
        Task<PessoaJuridicaDto> DeleteAsync(PessoaJuridicaDeleteCommand command);
        Task<List<PessoaJuridicaDto>?> GetAllAsync();
        Task<PessoaJuridicaDto?> GetByIdAsync(Guid id);

    }
}
