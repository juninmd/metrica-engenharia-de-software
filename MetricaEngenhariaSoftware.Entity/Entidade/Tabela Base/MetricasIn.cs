using System.Collections.Generic;

namespace MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base
{
    public class MetricasIn
    {
        /// <summary>
        /// Lista com nomes das Tabelas e sua quantidade de atributos
        /// </summary>
        public List<TabelaDominio> TabelaDominio { get; set; }

        /// <summary>
        /// Fa Selecionado No DropDown
        /// </summary>
        public int IntIdFa { get; set; }

        /// <summary>
        /// Iso Selecionada no DropDown
        /// </summary>
        public int IntIdIso { get; set; }

        /// <summary>
        /// Linguagem de Programação Selecionada no DropDown
        /// </summary>
        public int IntIdLinguagemProgramacao { get; set; }

        /// <summary>
        /// Tipo do Sistema Selecionado no DropDown
        /// </summary>
        public int IntIdTipoSistema { get; set; }

    }
}
