using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace WEBMVC.Models
{
    [Table("Cursos")]
    public class Curso
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(35)]
        public string descricao { get; set; }
    }
}
