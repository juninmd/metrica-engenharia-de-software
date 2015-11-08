using MetricaEngenhariaSoftware.Entity.Entidade.MES;

namespace MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base
{
    public class MetricasOut
    {
        /// <summary>
        /// Calculo do FB apartir de todas as tabelas
        /// </summary>
        public double FPB { get; set; }

        /// <summary>
        /// Valor Constante de uma tabela Predefinida
        /// </summary>
        public double FA { get; set; }

        /// <summary>
        /// Multiplicação entre FA * FPB
        /// </summary>
        public double CalculoBaseFA_FPB { get; set; }

        /// <summary>
        /// Calculo Base
        /// </summary>
        public double CalculoBase { get; set; }

        /// <summary>
        /// Request do Tipo de Linguagem de Programação
        /// </summary>
        public MES_LINGUAGEM_PROGRAMACAO LinguagemProgramacao { get; set; }

        /// <summary>
        /// Request de tipo de sistema / [web/intranet/etc]
        /// </summary>
        public MES_TIPO_SISTEMA TipoSistema { get; set; }

        /// <summary>
        /// Atribui a Entidade de ISO
        /// </summary>
        public MES_ISO MesIso { get; set; }

        /// <summary>
        /// Preço da Linguagem
        /// </summary>
        public double PrecoDaLinguagem { get; set; }

        /// <summary>
        /// Preço do Sistema
        /// </summary>
        public double ValorEmTempoPorDivisaodoSistema { get; set; }

        /// <summary>
        /// Calculo da ISO
        /// </summary>
        public double CalculoISO { get; set; }

        /// <summary>
        /// Tempo estipulado em extenso
        /// </summary>
        public string TempoTotalSistemaEmExtenso { get; set; }

        /// <summary>
        /// Tempo estipulado em extenso
        /// </summary>
        public double PrecoDoSistema{ get; set; }


        /// <summary>
        /// Tabelas com seus pesos e resultados
        /// </summary>
        public TabelasBrutas TabelasBrutas { get; set; }
    }
}
