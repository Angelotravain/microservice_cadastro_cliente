using ClienteService.DTOs;
using ClienteService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClienteService.Controllers
{
    [ApiController]
    [Route("Logistica/v1/[controller]")]
    public class ClienteController : ControllerBase
    {
        private const string ERROR_CADASTRO = "Erro ao buscar cadastro do cliente.";
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Obt�m todos os clientes.
        /// </summary>
        /// <returns>Uma lista de endere�os.</returns>
        [HttpGet]
        //[Authorize] // Ative quando implementar JWT
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Listar()
        {
            try
            {
                var dados = await _clienteService.ListarTodos();
                if (dados == null || !dados.Any())
                    return NotFound(new { Message = "Nenhum cliente encontrado." });

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Obt�m os clientes pelo ID informado.
        /// </summary>
        /// <returns>retorna o endere�o com o ID informado.</returns>
        [HttpGet("{clienteId}")]
        public async Task<ActionResult<ClienteDTO>> BuscarPorId(long clienteId)
        {
            try
            {
                var dados = await _clienteService.BuscarClientePorId(clienteId);
                if (dados == null)
                    return NotFound(new { Message = $"Cliente com ID {clienteId} n�o encontrado." });

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Salva o cliente e persiste no banco de dados.
        /// </summary>
        /// <returns>Mensagem de sucesso ou falha na opera��o</returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var retorno = await _clienteService.Salvar(dto);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza o cliente e persiste no banco de dados.
        /// </summary>
        /// <returns>Mensagem de sucesso ou falha na opera��o</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] ClienteDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (id != dto.Id)
                    return BadRequest(new { Message = "ID do cliente n�o coincide." });

                var dados = await _clienteService.Editar(dto);
                if (dados == null)
                    return NotFound(new { Message = $"Cliente com ID {id} n�o encontrado." });

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Exclui o cliente e persiste no banco de dados.
        /// </summary>
        /// <returns>Mensagem de sucesso ou falha na opera��o</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var dados = await _clienteService.Excluir(id);
                if (dados == null)
                    return NotFound(new { Message = $"Cliente com ID {id} n�o encontrado." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }
    }
}