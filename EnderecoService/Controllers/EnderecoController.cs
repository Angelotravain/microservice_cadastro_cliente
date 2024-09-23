using EnderecoService.DTOs;
using EnderecoService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EnderecoService.Controllers
{
    [ApiController]
    [Route("Logistica/v1/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private const string ERROR_CADASTRO = "Erro ao buscar endereços.";
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        /// <summary>
        /// Obtém todos os endereços.
        /// </summary>
        /// <returns>Uma lista de endereços.</returns>
        [HttpGet]
        //[Authorize] // Ative quando implementar JWT
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> Listar()
        {
            try
            {
                var dados = await _enderecoService.ListarTodos();
                if (dados == null || !dados.Any())
                    return NotFound(new { Message = "Nenhum endereço encontrado." });

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Obtém os endereços pelo ID do cliente informado.
        /// </summary>
        /// <returns>retorna o endereço com o ID informado.</returns>
        [HttpGet("{clienteId}")]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> BuscarPorId(long clienteId)
        {
            try
            {
                var dados = await _enderecoService.ListarEnderecoPorClienteId(clienteId);
                if (dados == null)
                    return NotFound(new { Message = $"Endereço com ID {clienteId} não encontrado." });

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Salva o endereço e persiste no banco de dados.
        /// </summary>
        /// <returns>Mensagem de sucesso ou falha na operação</returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] List<EnderecoDTO> dto)
        {
            try
            {
                var retorno = await _enderecoService.Salvar(dto);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza o endereço e persiste no banco de dados.
        /// </summary>
        /// <returns>Mensagem de sucesso ou falha na operação</returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] List<EnderecoDTO> dto)
        {
            try
            {
                var dados = await _enderecoService.Editar(dto);
                if (dados == null)
                    return NotFound(new { Message = $"Endereço com ID {dto} não encontrado." });

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Exclui o endereço e persiste no banco de dados.
        /// </summary>
        /// <returns>Mensagem de sucesso ou falha na operação</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var dados = await _enderecoService.Excluir(id);
                if (dados == null)
                    return NotFound(new { Message = $"Endereço com ID {id} não encontrado." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Exclui os endereços vinculados a um cliente que está excluido.
        /// </summary>
        /// <returns>Mensagem de sucesso ou falha na operação</returns>
        [HttpDelete("Cliente/{clienteId}")]
        public async Task<ActionResult> DeletePorCliente(long clienteId)
        {
            try
            {
                var dados = await _enderecoService.ExcluirEnderecoPorCliente(clienteId);
                if (dados == null)
                    return NotFound(new { Message = $"Endereço com ID de cliente {clienteId} não encontrado." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }
    }
}
