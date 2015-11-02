using System.ComponentModel.DataAnnotations;

namespace MetricaEngenhariaSoftware.Entity.Entidade.MES
{
    public class MES_LINGUAGEM_PROGRAMACAO
    {
        [Key]
        public int IntIdLinguagemProgramacao { get; set; }
        public string StrNomeLinguagemProgramacao { get; set; }
        public string DecValorLinguagemProgramacao { get; set; }
    }
}
