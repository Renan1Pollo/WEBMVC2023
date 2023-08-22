using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBMVC.Models
{
    [Table("Salas")]
    public class Sala
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(35)]
        public string descricao { get; set; }

        public int equipamentos { get; set; }

        public char situacao { get; set; }
    }
}
