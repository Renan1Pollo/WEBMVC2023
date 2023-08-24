using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBMVC.Models
{
    [Table("Atendimentos")]
    public class Atendimento
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        public int alunoID { get; set; }
        [Display(Name = "Aluno")]
        [ForeignKey("alunoID")]
        public Aluno aluno { get; set; }

        public int salaID { get; set; }

        [Display(Name = "Sala")]
        [ForeignKey("salaID")]
        public Sala sala { get; set; }

        [Required(ErrorMessage = "Campo data e hora é obrigatório")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data e hora")]
        public DateTime data { get; set; }
    }
}
