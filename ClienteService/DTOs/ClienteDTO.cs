using ClienteService.Utils;

namespace ClienteService.DTOs
{
    public class ClienteDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public TipoSexo Sexo { get; set; }
    }
}
