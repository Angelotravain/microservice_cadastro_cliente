using EnderecoService.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnderecoService.Models
{
    [Table("ENDERECO")]
    public class EnderecoModel : IEntity
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }

        [Required]
        [Column("CEP")]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Required]
        [Column("LOGRADOURO")]
        [MaxLength(150)]
        public string Logradouro { get; set; }

        [Required]
        [Column("NUMERO")]
        [MaxLength(10)]
        public string Numero { get; set; }

        [Column("COMPLEMENTO")]
        [MaxLength(100)]
        public string? Complemento { get; set; }

        [Column("BAIRRO")]
        [MaxLength(100)]
        public string? Bairro { get; set; }

        [Required]
        [Column("CIDADE")]
        [MaxLength(100)]
        public string Cidade { get; set; }

        [Required]
        [Column("UF")]
        [MaxLength(2)]
        public string Uf { get; set; }

        [Required]
        [Column("CLIENTE_ID")]
        public long ClienteId { get; set; }
        [Required]
        [Column("TIPO_ENDERECO")]
        public TipoEndereco TipoEndereco { get; set; }
    }
}
