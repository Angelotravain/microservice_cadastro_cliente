using ClienteService.Models;

namespace ClienteService.Tests
{
    public static class ClienteModelFactoryFake
    {
        public static ClienteModel ClienteModelMock()
        {
            return new ClienteModel
            {
                Id = 1,
                DataNascimento = DateTime.Now.AddYears(-27),
                Nome = "Test",
                Sexo = Utils.TipoSexo.Masculino
            };
        }

        public static List<ClienteModel> ListaClienteModelMock()
        {
            return new List<ClienteModel>
            {
                new ClienteModel
                {
                    Id = 1,
                    DataNascimento = DateTime.Now.AddYears(-27),
                    Nome = "Test",
                    Sexo = Utils.TipoSexo.Masculino
                },
                new ClienteModel
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
