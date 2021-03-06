﻿namespace MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base.TiposTabela
{
    public class TabelaArquivo
    {
        public int NumeroOcorrencia { get; set; }
        public TabelaArquivoPeso Complexidade { get; set; }
        public int Peso => (int)Complexidade;
        public int Resultado => NumeroOcorrencia * Peso;
    }

    public enum TabelaArquivoPeso
    {
        Simples = 7,
        Medio = 10,
        Complexo = 15,
    }
}
