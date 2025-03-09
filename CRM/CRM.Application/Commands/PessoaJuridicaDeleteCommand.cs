using CRM.Application.Dtos.PessoaJuridica;
using MediatR;

namespace CRM.Application.Commands
{
    public class PessoaJuridicaDeleteCommand : PessoaJuridicaCommand, IRequest<PessoaJuridicaDto>
    {

    }
}
