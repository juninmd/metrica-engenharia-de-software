using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetricaEngenhariaSoftware.Entity.Entidade.MES
{
    public class MES_FA
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IntIdFa { get; set; }
        public decimal DecValorFa { get; set; }
    }
}
