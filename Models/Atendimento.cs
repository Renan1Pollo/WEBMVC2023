using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBMVC.Models
{
    [Table("Atendimentos")]
    public class Atendimento
    {
        [Key]
        public int id { get; set; }

        public Aluno aluno { get; set; }

        public Sala sala { get; set; }

        public DateTime data { get; set; }
    }
}
