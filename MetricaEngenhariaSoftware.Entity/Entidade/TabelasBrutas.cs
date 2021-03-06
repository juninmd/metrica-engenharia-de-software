﻿using System.Collections.Generic;
using MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base.TiposTabela;

namespace MetricaEngenhariaSoftware.Entity.Entidade
{
    public class TabelasBrutas
    {
        public List<TabelaArquivo> TabelaArquivo { get; set; }
        public List<TabelaConsulta> TabelaConsulta { get; set; }
        public List<TabelaEntrada> TabelaEntrada { get; set; }
        public List<TabelaInterface> TabelaInterface { get; set; }
        public List<TabelaSaida> TabelaSaida { get; set; }
    }
}
