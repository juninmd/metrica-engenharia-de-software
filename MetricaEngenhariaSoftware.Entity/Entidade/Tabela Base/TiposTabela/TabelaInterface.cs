namespace MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base.TiposTabela
{
    public class TabelaInterface
    {
        public int NumeroOcorrencia { get; set; }
        public TabelaInterfacePeso Complexidade { get; set; }
        public int Peso => (int)Complexidade;
        public int Resultado => NumeroOcorrencia * Peso;
    }

    public enum TabelaInterfacePeso
    {
        Simples = 5,
        Medio = 7,
        Complexo = 10,
    }
}
