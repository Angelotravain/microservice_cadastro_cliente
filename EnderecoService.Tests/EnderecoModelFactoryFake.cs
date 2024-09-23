using EnderecoService.Models;

namespace EnderecoService.Tests
{
    public static class EnderecoModelFactoryFake
    {
        public static EnderecoModel EnderecoModelMock()
        {
            return new EnderecoModel
            {
                Id = 1,
                Cep = "12345678",
                Logradouro = "Rua Teste",
                Numero = "123",
                Complemento = "Apto 10",
                Bairro = "Bairro Teste",
                Cidade = "Cidade Teste",
                Uf = "TS",
                ClienteId = 10,
                TipoEndereco = Utils.TipoEndereco.Residencial
            };
        }

        public static List<EnderecoModel> ListEnderecoModelMock()
        {
            return new List<EnderecoModel>
            {
                new EnderecoModel
                {
                    Id = 1,
                    Cep = "12345678",
                    Logradouro = "Rua 1",
                    Numero = "100",
                    Complemento = "Apto 1",
                    Bairro = "Bairro 1",
                    Cidade = "Cidade 1",
                    Uf = "SP",
                    ClienteId = 1,
                    TipoEndereco = Utils.TipoEndereco.Residencial
                },
                new EnderecoModel
                {
                    Id = 2,
                    Cep = "87654321",
                    Logradouro = "Rua 2",
                    Numero = "200",
                    Complemento = "Apto 2",
                    Bairro = "Bairro 2",
                    Cidade = "Cidade 2",
                    Uf = "RJ",
                    ClienteId = 2,
                    TipoEndereco = Utils.TipoEndereco.Comercial
                }
            };
        }
    }
}
