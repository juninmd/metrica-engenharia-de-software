using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetricaEngenhariaSoftware.Entity.Entidade.MES
{
    public class MES_TIPO_SISTEMA
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IntIdTipoSistema { get; set; }
        public string StrNomeTipoSistema { get; set; }
        public decimal DecValorTipoSistema { get; set; }
    }
}
