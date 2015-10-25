using System.Collections.Generic;
using MetricaEngenhariaSoftware.Core.Constants;

namespace MetricaEngenhariaSoftware.Core.Entidade.Tabela_Base
{
    public class TabelaDominioContainer
    {
        /* ------------------- ITENS VIA INPUT -------------------*/
        public List<TabelaDominio> TabelaDominio { get; set; }

        /// <summary>
        ///  JAVA / VB / GC
        /// </summary>
        public int LinguagemDoSistema { get; set; }
        public string NomeLinguagemDoSistema { get; set; }

        /// <summary>
        /// WEB / COMERCIAL 
        /// </summary>
        public int TipoDoSistema { get; set; }
        public string NomeTipoDoSistema { get; set; }

        /* ------------------- ITENS DO SISTEMA -------------------*/

        public double PrecoDaLinguagem { get; set; }
        public double TempoTotal { get; set; }
        public double ValorIso => TempoTotal * Iso.ISO9126;
        public double CustoProjeto => ValorIso * 90;
        public TabelasBrutas TabelasBrutas { get; set; }
    }
}
