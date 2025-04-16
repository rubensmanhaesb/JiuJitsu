using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using CRM.Application.Interfaces;
using CRM.Application.Services.Email;
using Microsoft.AspNetCore.Mvc;
using RMB.Abstractions.Shared.Contracts.Paginations.Requests;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly IPessoaJuridicaApplicationService? _pessoaJuridicaApplicationService;
        private readonly EmailConfirmationService _emailConfirmationService;

        public PessoaJuridicaController(IPessoaJuridicaApplicationService pessoaJuridicaApplicationService, EmailConfirmationService emailConfirmationService)
        {
            _pessoaJuridicaApplicationService = pessoaJuridicaApplicationService;
            _emailConfirmationService = emailConfirmationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PessoaJuridicaDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(PessoaJuridicaCreateCommand command, CancellationToken cancellationToken = default)
        {
            var dto = await _pessoaJuridicaApplicationService!.AddAsync(command, cancellationToken);
            return StatusCode(201, dto);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PessoaJuridicaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(PessoaJuridicaUpdateCommand command, CancellationToken cancellationToken = default)
        {
            var dto = await _pessoaJuridicaApplicationService!.UpdateAsync(command, cancellationToken);
            return StatusCode(200, dto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PessoaJuridicaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var command = new PessoaJuridicaDeleteCommand { Id = id };
            var dto = await _pessoaJuridicaApplicationService!.DeleteAsync(command, cancellationToken);

            return StatusCode(200, dto);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PessoaJuridicaDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
            => Ok(await _pessoaJuridicaApplicationService!.GetAllAsync(cancellationToken));


        [HttpGet("paginated")]
        [ProducesResponseType(typeof(List<PessoaJuridicaDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaginated([FromQuery] PaginationRequest pagination, CancellationToken cancellationToken = default)
        {
            var resultado = await _pessoaJuridicaApplicationService.GetPaginatedAsync<PessoaJuridicaDto>(
                predicate: null,
                paginationRequest: pagination,
                cancellationToken: cancellationToken
            );

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PessoaJuridicaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            =>Ok(await _pessoaJuridicaApplicationService.GetByIdAsync(id, cancellationToken));
        
        [HttpGet("Mail_teste")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Mail_teste(CancellationToken cancellationToken = default)
        {

            _emailConfirmationService.SendAsync("ana@hotmail.com", Guid.NewGuid());

            return Ok();
        }

    }
}
