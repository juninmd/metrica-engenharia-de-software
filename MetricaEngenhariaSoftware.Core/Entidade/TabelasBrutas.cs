using System.Collections.Generic;
using System.Linq;
using MetricaEngenhariaSoftware.Core.Constants;
using MetricaEngenhariaSoftware.Core.Entidade.Tabela_Base.TiposTabela;

namespace MetricaEngenhariaSoftware.Core.Entidade
{
    public class TabelasBrutas
    {
        public List<TabelaArquivo> TabelaArquivo { get; set; }
        public List<TabelaConsulta> TabelaConsulta { get; set; }
        public List<TabelaEntrada> TabelaEntrada { get; set; }
        public List<TabelaInterface> TabelaInterface { get; set; }
        public List<TabelaSaida> TabelaSaida { get; set; }

        public int FPB
            =>
                TabelaArquivo.Select(x => x.Resultado).Sum() +
                TabelaConsulta.Select(x => x.Resultado).Sum() +
                TabelaEntrada.Select(x => x.Resultado).Sum() +
                TabelaInterface.Select(x => x.Resultado).Sum() +
                TabelaSaida.Select(x => x.Resultado).Sum();

        public double CalculoBase => FPB*Constant.FA;
    }
}
