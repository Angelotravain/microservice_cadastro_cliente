using System.ComponentModel.DataAnnotations;

namespace EnderecoService.Models
{
    public interface IEntity
    {
        [Key]
        long Id { get; set; }
    }
}
