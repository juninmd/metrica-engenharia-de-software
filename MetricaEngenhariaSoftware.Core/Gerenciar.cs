using System.Collections.Generic;
using System.Linq;
using MetricaEngenhariaSoftware.Core.CalcularMetricas;
using MetricaEngenhariaSoftware.Core.Constants;
using MetricaEngenhariaSoftware.Core.Entidade;
using MetricaEngenhariaSoftware.Core.Entidade.Tabela_Base;

namespace MetricaEngenhariaSoftware.Core
{
    public class Gerenciar
    {
        public TabelaDominioContainer Inserir(List<TabelaDominio> TabelaDominio, int linguagem, int tipo)
        {
            var TabelaDominioContainer = new TabelaDominioContainer
            {
                TabelaDominio = TabelaDominio,
                LinguagemDoSistema = linguagem,
                TipoDoSistema = tipo
            };

            var geral = TabelaDominioContainer.TabelaDominio.Select(x => x.QuantidadeAtributos).Sum();

            TabelaDominioContainer.TabelaDominio.Add(new TabelaDominio
            {
                NomeTabela = "Geral",
                QuantidadeAtributos = geral
            });

            CalcularTabelasBrutas(TabelaDominioContainer);

            CalcularCusto(TabelaDominioContainer);


            return TabelaDominioContainer;
        }

        private void CalcularTabelasBrutas(TabelaDominioContainer tabelaDominioContainer)
        {

            var TabelasBrutas = new TabelasBrutas
            {
                TabelaEntrada = new MetricasEntrada().CalcularEntrada(tabelaDominioContainer),
                TabelaSaida = new MetricasSaida().CalcularSaida(tabelaDominioContainer),
                TabelaConsulta = new MetricasConsulta().CalcularConsulta(tabelaDominioContainer),
                TabelaArquivo = new MetricasArquivo().CalcularArquivo(tabelaDominioContainer),
                TabelaInterface = new MetricasInterface().CalcularInterface(tabelaDominioContainer)
            };

            tabelaDominioContainer.TabelasBrutas = TabelasBrutas;
        }

        private void CalcularCusto(TabelaDominioContainer tabelaDominioContainer)
        {
            /* Calcula por tipo Linguagem  1 -java 2 -vb 3 -gc*/
            switch (tabelaDominioContainer.LinguagemDoSistema)
            {
                case 1:
                    tabelaDominioContainer.PrecoDaLinguagem = tabelaDominioContainer.TabelasBrutas.CalculoBase * Linguagens.Java;
                    break;
                case 2:
                    tabelaDominioContainer.PrecoDaLinguagem = tabelaDominioContainer.TabelasBrutas.CalculoBase * Linguagens.VB;
                    break;
                case 3:
                    tabelaDominioContainer.PrecoDaLinguagem = tabelaDominioContainer.TabelasBrutas.CalculoBase * Linguagens.GC;
                    break;
            }
            /* Calcula por tipo de sistema 1web 2comercial*/
            switch (tabelaDominioContainer.TipoDoSistema)
            {
                case 1:
                    tabelaDominioContainer.TempoTotal = tabelaDominioContainer.PrecoDaLinguagem / Sistema.Web;
                    break;
                case 2:
                    tabelaDominioContainer.TempoTotal = tabelaDominioContainer.PrecoDaLinguagem / Sistema.Comercial;
                    break;
            }

        }


    }
}
