using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetricaEngenhariaSoftware.Entity.Entidade.MES
{
    public class MES_LINGUAGEM_PROGRAMACAO
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IntIdLinguagemProgramacao { get; set; }
        public string StrNomeLinguagemProgramacao { get; set; }
        public decimal DecValorLinguagemProgramacao { get; set; }
    }
}
