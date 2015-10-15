using System.Collections.Generic;

namespace MetricaEngenhariaSoftware.Core.Entidade
{
    public class ListaTabelaEntrada
    {
        public List<TabelaEntrada> TabelaEntrada { get; set; }
    }

    public class TabelaEntrada
    {
        public int NumeroOcorrencia { get; set; }
        public TabelaEntradaPeso Complexidade { get; set; }
        public int Peso => (int)Complexidade;
        public int Resultado => NumeroOcorrencia * Peso;
    }

    public enum TabelaEntradaPeso
    {
        Simples = 3,
        Medio = 4,
        Complexo = 6,
    }
}
