using EnderecoService.DTOs;

namespace EnderecoService.Services.Validation
{
    public static class ValidacaoEnderecoService
    {
        public static void Validar(EnderecoDTO endereco)
        {
            if (endereco == null)
                throw new ArgumentNullException(nameof(endereco), "Endereço não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(endereco.Logradouro))
                throw new ArgumentException("Logradouro é obrigatório.", nameof(endereco.Logradouro));

            if (string.IsNullOrWhiteSpace(endereco.Numero))
                throw new ArgumentException("Número é obrigatório.", nameof(endereco.Numero));

            if (string.IsNullOrWhiteSpace(endereco.Cidade))
                throw new ArgumentException("Cidade é obrigatória.", nameof(endereco.Cidade));

            if (string.IsNullOrWhiteSpace(endereco.Uf))
                throw new ArgumentException("UF é obrigatória.", nameof(endereco.Uf));
            if (endereco.Complemento == string.Empty)
                endereco.Complemento = null;
            if (endereco.Bairro == string.Empty)
                endereco.Bairro = null;
        }
    }
}
