using ClienteService.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClienteService.Models
{
    [Table("CLIENTE")]
    public class ClienteModel : IEntity
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [Column("NOME")]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [Column("DATA_NASCIMENTO")]
        public DateTime DataNascimento {  get; set; }

        [Required]
        [Column("SEXO_CLIENTE")]
        public TipoSexo Sexo {  get; set; }
    }
}
