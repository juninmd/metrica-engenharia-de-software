using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetricaEngenhariaSoftware.Entity.Entidade.MES
{
    public class MES_ISO
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IntIdIso { get; set; }
        public string StrNomeIso { get; set; }
        public int IntValorIso { get; set; }
    }
}
