namespace MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base.TiposTabela
{
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
