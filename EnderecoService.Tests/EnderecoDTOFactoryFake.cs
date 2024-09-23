using EnderecoService.DTOs;

namespace EnderecoService.Tests
{
    public static class EnderecoDTOFactoryFake
    {
        public static EnderecoDTO EnderecoDtoMock()
        {
            return new EnderecoDTO
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

        public static List<EnderecoDTO> ListarEnderecoDtoMock()
        {
            return new List<EnderecoDTO>
            {
                new EnderecoDTO
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
                new EnderecoDTO
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
