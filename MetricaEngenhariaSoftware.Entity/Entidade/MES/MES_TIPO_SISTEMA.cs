using System.ComponentModel.DataAnnotations;

namespace MetricaEngenhariaSoftware.Entity.Entidade.MES
{
    public class MES_TIPO_SISTEMA
    {
        [Key]
        public int IntIdTipoSistema { get; set; }
        public string StrNomeTipoSistema { get; set; }
        public decimal DecValorTipoSistema { get; set; }
    }
}
