using ClienteService.DTOs;

namespace ClienteService.Services
{
    public interface IClienteService
    {
        Task<long> Salvar(ClienteDTO cliente);
        Task<string> Editar(ClienteDTO endereco);
        Task<string> Excluir(long id);
        Task<IEnumerable<ClienteDTO>> ListarTodos();
        Task<ClienteDTO> BuscarClientePorId(long clienteId);
    }
}
