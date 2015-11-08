namespace MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base
{
    public class MetricasOut
    {
        public double FPB { get; set; }
        public double PrecoDaLinguagem { get; set; }
        public double Meses { get; set; }
        public double TempoTotal { get; set; }
        public double CalculoFinal { get; set; }
        public string TempoTotalGeral { get; set; }
        public TabelasBrutas TabelasBrutas { get; set; }
    }
}
