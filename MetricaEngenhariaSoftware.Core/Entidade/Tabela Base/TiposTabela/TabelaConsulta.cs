using System.Collections.Generic;

namespace MetricaEngenhariaSoftware.Core.Entidade.Tabela_Base.TiposTabela
{
    public class ListaTabelaConsulta
    {
        public List<TabelaConsulta> TabelaConsulta { get; set; }
    }

    public class TabelaConsulta
    {
        public int NumeroOcorrencia { get; set; }
        public TabelaConsultaPeso Complexidade { get; set; }
        public int Peso => (int)Complexidade;
        public int Resultado => NumeroOcorrencia * Peso;
    }

    public enum TabelaConsultaPeso
    {
        Simples = 3,
        Medio = 4,
        Complexo = 6,
    }
}
