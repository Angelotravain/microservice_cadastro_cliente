using ClienteService.DTOs;
using ClienteService.Models;
using ClienteService.Repositories.Generic;


namespace ClienteService.Tests
{
    public class ClienteServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IGeneric<ClienteModel>> _genericRepositoryMock;
        private readonly ClienteService.Services.ClienteService _clienteService;

        public ClienteServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _genericRepositoryMock = new Mock<IGeneric<ClienteModel>>();
            _clienteService = new ClienteService.Services.ClienteService(_mapperMock.Object, _genericRepositoryMock.Object);
        }

        [Fact]
        public async Task Salvar_ClienteValido_RetornaMensagemDeSucesso()
        {
            var clienteDto = ClienteDTOFactoryFake.ClienteDtoMock();
            var clienteModel = ClienteModelFactoryFake.ClienteModelMock();

            _mapperMock.Setup(m => m.Map<ClienteModel>(clienteDto)).Returns(clienteModel);
            _genericRepositoryMock.Setup(g => g.Salvar(clienteModel)).ReturnsAsync(1);

            var result = await _clienteService.Salvar(clienteDto);

            Assert.Equal(1, result);
        }


        [Fact]
        public async Task Editar_ClienteValido_RetornaMensagemDeSucesso()
        {
            var clienteDto = ClienteDTOFactoryFake.ClienteDtoMock();
            var clienteModel = ClienteModelFactoryFake.ClienteModelMock();

            _mapperMock.Setup(m => m.Map<ClienteModel>(clienteDto)).Returns(clienteModel);
            _genericRepositoryMock.Setup(g => g.Atualizar(clienteModel)).ReturnsAsync(true);

            var result = await _clienteService.Editar(clienteDto);

            Assert.Equal("Cliente editado com sucesso!", result);
        }

        [Fact]
        public async Task Excluir_ClienteNaoExistente_RetornaErro()
        {
            _genericRepositoryMock.Setup(g => g.FiltrarPorId(1)).ReturnsAsync((ClienteModel)null);

            var exception = await Assert.ThrowsAsync<ArgumentException>(async () => await _clienteService.Excluir(1));
            Assert.Equal("Não encontrado na base de dados", exception.Message);
        }

        [Fact]
        public async Task ListarTodos_ClientesExistentes_RetornaListaDeClientes()
        {
            var listaClientes = ClienteModelFactoryFake.ListaClienteModelMock();
            var listaClientesDto = ClienteDTOFactoryFake.ListaClienteDtoMock();

            _genericRepositoryMock.Setup(g => g.Listar()).ReturnsAsync(listaClientes);
            _mapperMock.Setup(m => m.Map<List<ClienteDTO>>(listaClientes)).Returns(listaClientesDto);

            var result = await _clienteService.ListarTodos();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}
