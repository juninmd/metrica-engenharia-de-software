using System.ComponentModel.DataAnnotations;

namespace MetricaEngenhariaSoftware.Entity.Entidade.MES
{
    public class MES_FA
    {
        [Key]
        public int IntIdFa { get; set; }
        public decimal DecValorFa { get; set; }
    }
}
