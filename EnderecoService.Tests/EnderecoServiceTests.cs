using EnderecoService.DTOs;
using EnderecoService.Models;
using EnderecoService.Repositories.Generic;


namespace EnderecoService.Tests
{
    public class EnderecoServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IGeneric<EnderecoModel>> _genericRepositoryMock;
        private readonly EnderecoService.Services.EnderecoService _enderecoService;

        public EnderecoServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _genericRepositoryMock = new Mock<IGeneric<EnderecoModel>>();

            _enderecoService = new EnderecoService.Services.EnderecoService(_mapperMock.Object, _genericRepositoryMock.Object);
        }

        [Fact]
        public async Task Excluir_EnderecoExistente_RetornaMensagemSucesso()
        {
            var enderecoId = 1;
            var enderecoDto = EnderecoDTOFactoryFake.EnderecoDtoMock();
            var enderecoModel = EnderecoModelFactoryFake.EnderecoModelMock();

            _genericRepositoryMock.Setup(r => r.FiltrarPorId(enderecoId)).ReturnsAsync(enderecoModel);
            _genericRepositoryMock.Setup(r => r.Excluir(enderecoModel)).ReturnsAsync(true);

            var resultado = await _enderecoService.Excluir(enderecoId);

            Assert.Equal("Endereço excluido com sucesso!", resultado);
        }

        [Fact]
        public async Task ListarTodos_ExistemEnderecos_RetornaListaDeEnderecos()
        {
            var listaEnderecos = EnderecoModelFactoryFake.ListEnderecoModelMock();

            _genericRepositoryMock.Setup(r => r.Listar()).ReturnsAsync(listaEnderecos);
            _mapperMock.Setup(m => m.Map<List<EnderecoDTO>>(listaEnderecos)).Returns(EnderecoDTOFactoryFake.ListarEnderecoDtoMock());

            var resultado = await _enderecoService.ListarTodos();

            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
        }

        [Fact]
        public async Task ListarEnderecoPorCliente_ClienteIdValido_RetornaListaDeEnderecos()
        {
            var clienteId = 10;
            var listaEnderecos = EnderecoModelFactoryFake.ListEnderecoModelMock();
            var listaEnderecosDto = EnderecoDTOFactoryFake.ListarEnderecoDtoMock();

            _genericRepositoryMock
                .Setup(r => r.Filtrar(It.IsAny<Expression<Func<EnderecoModel, bool>>>()))
                .ReturnsAsync(listaEnderecos);

            _mapperMock.Setup(m => m.Map<List<EnderecoDTO>>(listaEnderecos))
                .Returns(listaEnderecosDto);

            var resultado = await _enderecoService.ListarEnderecoPorClienteId(clienteId);

            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
            Assert.Equal("12345678", resultado.First().Cep);
            Assert.Equal("87654321", resultado.Last().Cep);
        }

    }
}
