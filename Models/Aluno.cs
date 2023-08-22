using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WEBMVC.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(35)]
        public string nome { get; set; }

        public DateTime aniversario { get; set; }

        public Curso curso { get; set; }

        public string periodo { get; set; }
    }
}
