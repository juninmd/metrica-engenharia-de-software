namespace MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base.TiposTabela
{
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
