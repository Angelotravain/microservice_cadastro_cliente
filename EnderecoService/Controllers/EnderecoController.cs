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
        private const string ERROR_CADASTRO = "Erro ao buscar endere�os.";
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        /// <summary>
        /// Obt�m todos os endere�os.
        /// </summary>
        /// <returns>Uma lista de endere�os.</returns>
        [HttpGet]
        //[Authorize] // Ative quando implementar JWT
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> Listar()
        {
            try
            {
                var dados = await _enderecoService.ListarTodos();
                if (dados == null || !dados.Any())
                    return NotFound(new { Message = "Nenhum endere�o encontrado." });

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Obt�m os endere�os pelo ID do cliente informado.
        /// </summary>
        /// <returns>retorna o endere�o com o ID informado.</returns>
        [HttpGet("{clienteId}")]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> BuscarPorId(long clienteId)
        {
            try
            {
                var dados = await _enderecoService.ListarEnderecoPorClienteId(clienteId);
                if (dados == null)
                    return NotFound(new { Message = $"Endere�o com ID {clienteId} n�o encontrado." });

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Salva o endere�o e persiste no banco de dados.
        /// </summary>
        /// <returns>Mensagem de sucesso ou falha na opera��o</returns>
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
        /// Atualiza o endere�o e persiste no banco de dados.
        /// </summary>
        /// <returns>Mensagem de sucesso ou falha na opera��o</returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] List<EnderecoDTO> dto)
        {
            try
            {
                var dados = await _enderecoService.Editar(dto);
                if (dados == null)
                    return NotFound(new { Message = $"Endere�o com ID {dto} n�o encontrado." });

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Exclui o endere�o e persiste no banco de dados.
        /// </summary>
        /// <returns>Mensagem de sucesso ou falha na opera��o</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var dados = await _enderecoService.Excluir(id);
                if (dados == null)
                    return NotFound(new { Message = $"Endere�o com ID {id} n�o encontrado." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }

        /// <summary>
        /// Exclui os endere�os vinculados a um cliente que est� excluido.
        /// </summary>
        /// <returns>Mensagem de sucesso ou falha na opera��o</returns>
        [HttpDelete("Cliente/{clienteId}")]
        public async Task<ActionResult> DeletePorCliente(long clienteId)
        {
            try
            {
                var dados = await _enderecoService.ExcluirEnderecoPorCliente(clienteId);
                if (dados == null)
                    return NotFound(new { Message = $"Endere�o com ID de cliente {clienteId} n�o encontrado." });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ERROR_CADASTRO, Details = ex.Message });
            }
        }
    }
}
