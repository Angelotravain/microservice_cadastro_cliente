using EnderecoService.Utils;

namespace EnderecoService.DTOs
{
    public class EnderecoDTO
    {
        public long Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public long ClienteId { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
    }
}
