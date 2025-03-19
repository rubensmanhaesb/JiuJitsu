using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly IPessoaJuridicaApplicationService? _pessoaJuridicaApplicationService;

        public PessoaJuridicaController(IPessoaJuridicaApplicationService pessoaJuridicaApplicationService)
        {
            _pessoaJuridicaApplicationService = pessoaJuridicaApplicationService;

        }
        

        [HttpPost]
        [ProducesResponseType(typeof(PessoaJuridicaDto), 201)]
        public async Task<IActionResult> Post(PessoaJuridicaCreateCommand command)
        {
            var dto = await _pessoaJuridicaApplicationService!.AddAsync(command);
            return StatusCode(201, dto);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PessoaJuridicaDto), 200)]
        public async Task<IActionResult> Put(PessoaJuridicaUpdateCommand command)
        {
            var dto = await _pessoaJuridicaApplicationService!.UpdateAsync(command);
            return StatusCode(200, dto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PessoaJuridicaDto), 200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new PessoaJuridicaDeleteCommand { Id = id };
            var dto = await _pessoaJuridicaApplicationService!.DeleteAsync(command);

            return StatusCode(200, dto);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PessoaJuridicaDto>), 200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetAll()
            => Ok(await _pessoaJuridicaApplicationService!.GetAllAsync());


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PessoaJuridicaDto), 200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
            => Ok(await _pessoaJuridicaApplicationService.GetByIdAsync(id));

        

    }
}
