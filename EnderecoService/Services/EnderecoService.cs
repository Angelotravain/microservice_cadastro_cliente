using AutoMapper;
using EnderecoService.DTOs;
using EnderecoService.Models;
using EnderecoService.Repositories.Generic;
using EnderecoService.Services.Persistense;
using EnderecoService.Services.Validation;
using System.Text;

namespace EnderecoService.Services
{
    public class EnderecoService : BaseEntity<EnderecoModel>, IEnderecoService
    {
        private readonly IMapper _mapper;
        public EnderecoService(IMapper mapper, IGeneric<EnderecoModel> generic) : base(generic)
        {
            _mapper = mapper;
        }

        public async Task<string> Salvar(List<EnderecoDTO> enderecos)
        {
            StringBuilder retorno = new();
            if (enderecos.Count > 0)
            {
                foreach (var endereco in enderecos)
                {
                    try
                    {

                        ValidacaoEnderecoService.Validar(endereco);
                        var res = await Salvar(_mapper.Map<EnderecoModel>(endereco));
                        if (res)
                            continue;
                        else
                            retorno.Append($"Erro ao editar com id: {endereco.Logradouro}");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                retorno.Append("Endereço salvo com Sucesso!");
                return retorno.ToString();
            }
            else
            {
                return "Sem endereços para salvar";
            }
        }

        public async Task<string> Editar(List<EnderecoDTO> enderecos)
        {
            StringBuilder retorno = new();

            if (enderecos.Count > 0)
            {
                foreach (var endereco in enderecos)
                {
                    try
                    {
                        ValidacaoEnderecoService.Validar(endereco);
                        var res = await Atualizar(_mapper.Map<EnderecoModel>(endereco));
                        if (res)
                            continue;
                        else
                            retorno.Append($"Erro ao editar com id: {endereco.Logradouro}");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                retorno.Append("Endereço editado com sucesso!");
                return retorno.ToString();
            }
            else
            {
                return "Sem endereços para salvar";
            }
        }

        public async Task<string> Excluir(long id)
        {
            var endereco = await FiltrarPorId(id) ?? throw new ArgumentException("Não encontrado na base de dados");
            var res = await Excluir(endereco);
            if (res)
                return "Endereço excluido com sucesso!";
            else
                throw new ArgumentException("Erro ao salvar");
        }

        public async Task<IEnumerable<EnderecoDTO>> ListarTodos()
        {
            var lista = await Listar();
            if (lista != null)
                return _mapper.Map<List<EnderecoDTO>>(lista);
            else
                return new List<EnderecoDTO>();
        }

        public async Task<string> ExcluirEnderecoPorCliente(long clienteId)
        {
            try
            {
                var status = false;
                var enderecos = await ListarEnderecoPorClienteId(clienteId) ?? throw new ArgumentException("Não encontrado na base de dados");
                foreach (var endereco in enderecos)
                {
                    status = await Excluir(_mapper.Map<EnderecoModel>(endereco));
                }
                if (status)
                    return "Endereço excluido com sucesso!";
                else
                    throw new ArgumentException("Erro ao salvar");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao salvar" + ex.Message);
            }
        }
        public async Task<IEnumerable<EnderecoDTO>> ListarEnderecoPorClienteId(long clienteId)
        {
            return _mapper.Map<List<EnderecoDTO>>(await Filtrar(e => e.ClienteId == clienteId));
        }
    }
}
