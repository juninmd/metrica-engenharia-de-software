using System.Collections.Generic;

namespace MetricaEngenhariaSoftware.Core.Entidade
{
    public class ListaTabelaInteface
    {
        public List<TabelaInteface> TabelaInteface { get; set; }
    }

    public class TabelaInteface
    {
        public int NumeroOcorrencia { get; set; }
        public TabelaIntefacePeso Complexidade { get; set; }
        public int Peso => (int)Complexidade;
        public int Resultado => NumeroOcorrencia * Peso;
    }

    public enum TabelaIntefacePeso
    {
        Simples = 5,
        Medio = 7,
        Complexo = 10,
    }
}
