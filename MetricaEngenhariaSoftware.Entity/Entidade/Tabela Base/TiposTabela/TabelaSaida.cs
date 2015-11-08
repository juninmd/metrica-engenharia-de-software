namespace MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base.TiposTabela
{
    public class TabelaSaida
    {
        public int NumeroOcorrencia { get; set; }
        public TabelaSaidaPeso Complexidade { get; set; }
        public int Peso => (int)Complexidade;
        public int Resultado => NumeroOcorrencia * Peso;
    }

    public enum TabelaSaidaPeso
    {
        Simples = 4,
        Medio = 5,
        Complexo = 7,
    }
}
