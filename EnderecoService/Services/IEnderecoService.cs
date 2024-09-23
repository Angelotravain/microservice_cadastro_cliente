using EnderecoService.DTOs;

namespace EnderecoService.Services
{
    public interface IEnderecoService
    {
        Task<string> Salvar(List<EnderecoDTO> enderecos);
        Task<string> Editar(List<EnderecoDTO> enderecos);
        Task<string> Excluir(long id);
        Task<IEnumerable<EnderecoDTO>> ListarTodos();
        Task<IEnumerable<EnderecoDTO>> ListarEnderecoPorClienteId(long clienteId);
        Task<string> ExcluirEnderecoPorCliente(long clienteId);
    }
}
