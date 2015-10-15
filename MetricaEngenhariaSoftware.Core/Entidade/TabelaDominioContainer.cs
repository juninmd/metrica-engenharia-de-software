using System.Collections.Generic;
using System.Linq;

namespace MetricaEngenhariaSoftware.Core.Entidade
{
    public class TabelaDominioContainer
    {
        public List<TabelaDominio> TabelaDominio { get; set; }
        public TabelaDominio Geral  => new TabelaDominio
        {
            NomeTabela = "Geral",
            QuantidadeAtributos = TabelaDominio.Select(x=> x.QuantidadeAtributos).Sum()
        };
    }
}
