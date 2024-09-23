using System.ComponentModel.DataAnnotations;

namespace ClienteService.Models
{
    public interface IEntity
    {
        [Key]
        long Id { get; set; }
    }
}
