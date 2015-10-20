using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MetricaEngenhariaSoftware.Core.Entidade.Tabela_Base;
using MetricaEngenhariaSoftware.Core.Entidade.Tabela_Base.TiposTabela;
using MetricaEngenhariaSoftware.Core.Utilidades;

namespace MetricaEngenhariaSoftware.Core.CalcularMetricas
{
    public class MetricasEntrada
    {
        public List<TabelaEntrada> CalcularEntrada(TabelaDominioContainer tabelaDominioContainer)
        {
            Debug.WriteLine("######## ENTRADA ########");
            var contador = new Contador();

            /* 1 a 4 - Atributos */
            ColunaA(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 1 && x.QuantidadeAtributos <= 4 && x.NomeTabela != "Geral").ToList(), contador);

            /* 5 a 15 - Atributos */
            ColunaB(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 5 && x.QuantidadeAtributos <= 15 && x.NomeTabela != "Geral").ToList(), contador);

            /* 16 ou mais - Atributos */
            ColunaC(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 16 && x.NomeTabela != "Geral").ToList(), contador);

            Debug.WriteLine("######## FIM  ENTRADA ########");

            return new List<TabelaEntrada>
            {
                new TabelaEntrada
                {
                    Complexidade = TabelaEntradaPeso.Simples,
                    NumeroOcorrencia = contador.simples
                },
                 new TabelaEntrada
                {
                    Complexidade = TabelaEntradaPeso.Medio,
                    NumeroOcorrencia = contador.medio
                },
                  new TabelaEntrada
                {
                    Complexidade = TabelaEntradaPeso.Complexo,
                    NumeroOcorrencia = contador.complexo
                }
            };

        }


        private void ColunaA(List<TabelaDominio> itens, Contador contador)
        {
            itens.Caguetar();
            var count = itens.Select(x => x.QuantidadeAtributos).Count();
            contador.Simples(count, 0, 2);
            contador.Medio(count, 3, 9999);
        }

        private void ColunaB(List<TabelaDominio> itens, Contador contador)
        {
            itens.Caguetar();
            var count = itens.Select(x => x.QuantidadeAtributos).Count();
            contador.Simples(count, 0, 1);
            contador.Medio(count, 2, 2);
            contador.Complexo(count, 3, 99999);
        }

        private void ColunaC(List<TabelaDominio> itens, Contador contador)
        {
            itens.Caguetar();
            var count = itens.Select(x => x.QuantidadeAtributos).Count();
            contador.Medio(count, 0, 1);
            contador.Complexo(count, 2, 99999);
        }
    }
}
