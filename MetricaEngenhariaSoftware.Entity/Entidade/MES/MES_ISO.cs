using System.ComponentModel.DataAnnotations;

namespace MetricaEngenhariaSoftware.Entity.Entidade.MES
{
    public class MES_ISO
    {
        [Key]
        public int IntIdIso { get; set; }
        public string StrNomeIso { get; set; }
        public int IntValorIso { get; set; }
    }
}
