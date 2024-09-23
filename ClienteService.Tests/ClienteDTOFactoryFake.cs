using ClienteService.DTOs;

namespace ClienteService.Tests
{
    public static class ClienteDTOFactoryFake
    {
        public static ClienteDTO ClienteDtoMock()
        {
            return new ClienteDTO
            {
                Id = 1,
                DataNascimento = DateTime.Now.AddYears(-27),
                Nome = "Test",
                Sexo = Utils.TipoSexo.Masculino
            };
        }

        public static List<ClienteDTO> ListaClienteDtoMock()
        {
            return new List<ClienteDTO>
            {
                new ClienteDTO
                {
                    Id = 1,
                    DataNascimento = DateTime.Now.AddYears(-27),
                    Nome = "Test",
                    Sexo = Utils.TipoSexo.Masculino
                },
                new ClienteDTO
                {
                    Id = 2,
                    DataNascimento = DateTime.Now.AddYears(-26),
                    Nome = "Test",
                    Sexo = Utils.TipoSexo.Masculino
                }
            };
        }
    }
}
