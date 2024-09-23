using AutoMapper;
using ClienteService.DTOs;
using ClienteService.Models;
using ClienteService.Repositories.Generic;
using ClienteService.Repositories.HttpRequest;
using ClienteService.Services.Persistence;

namespace ClienteService.Services
{
    public class ClienteService : BaseEntity<ClienteModel>, IClienteService
    {
        private readonly IMapper _mapper;
        public ClienteService(IMapper mapper, IGeneric<ClienteModel> generic) : base(generic)
        {
            _mapper = mapper;
        }

        public async Task<long> Salvar(ClienteDTO cliente)
        {
            try
            {
                var res = await Salvar(_mapper.Map<ClienteModel>(cliente));
                if (res != 0)
                    return res;
                else
                    throw new ArgumentException("Erro ao salvar");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> Editar(ClienteDTO endereco)
        {
            try
            {
                var res = await Atualizar(_mapper.Map<ClienteModel>(endereco));
                if (res)
                    return "Cliente editado com sucesso!";
                else
                    throw new ArgumentException("Erro ao editar");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> Excluir(long id)
        {
            var cliente = await FiltrarPorId(id) ?? throw new ArgumentException("Não encontrado na base de dados");
            var res = await Excluir(cliente);
            if (res)
            {
                var response = await Repositories.HttpRequest.HttpRequest.Delete("Endereco/Cliente", id);
                if (response != null && response.IsSuccessStatusCode)
                    return "Cliente excluido com sucesso!";

                throw new ArgumentException("Erro ao excluir dados");
            }
            else
                throw new ArgumentException("Erro ao excluir");
        }

        public async Task<IEnumerable<ClienteDTO>> ListarTodos()
        {
            var lista = await Listar();
            if (lista != null)
                return _mapper.Map<List<ClienteDTO>>(lista);
            else
                return new List<ClienteDTO>();
        }

        public async Task<ClienteDTO> BuscarClientePorId(long clienteId)
        {
            return _mapper.Map<ClienteDTO>(await FiltrarPorId(clienteId));
        }
    }
}
