using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace WEBMVC.Models
{
    [Table("Cursos")]
    public class Curso
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo descrição é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
