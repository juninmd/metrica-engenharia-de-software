using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MetricaEngenhariaSoftware.Core.Entidade.Tabela_Base;
using MetricaEngenhariaSoftware.Core.Entidade.Tabela_Base.TiposTabela;
using MetricaEngenhariaSoftware.Core.Utilidades;

namespace MetricaEngenhariaSoftware.Core.CalcularMetricas
{
    public class MetricasInterface
    {
        public List<TabelaInterface> CalcularInterface(TabelaDominioContainer tabelaDominioContainer)
        {
            Debug.WriteLine("######## INTERFACE ########");

            var contador = new Contador();

            /* 1 a 19 - Atributos */
            ColunaA(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 1 && x.QuantidadeAtributos <= 19).ToList(), contador);

            /* 20 a 50 - Atributos */
            ColunaB(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 20 && x.QuantidadeAtributos <= 50).ToList(), contador);

            /* 51 ou mais - Atributos */
            ColunaC(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 51).ToList(), contador);

            Debug.WriteLine("######## FIM INTERFACE ########");

            return new List<TabelaInterface>
            {
                new TabelaInterface
                {
                    Complexidade = TabelaInterfacePeso.Simples,
                    NumeroOcorrencia = contador.simples
                },
                 new TabelaInterface
                {
                    Complexidade = TabelaInterfacePeso.Medio,
                    NumeroOcorrencia = contador.medio
                },
                  new TabelaInterface
                {
                    Complexidade = TabelaInterfacePeso.Complexo,
                    NumeroOcorrencia = contador.complexo
                }
            };

        }


        private void ColunaA(List<TabelaDominio> itens, Contador contador)
        {
            itens.Caguetar();
            var count = itens.Select(x => x.QuantidadeAtributos).Count();
            contador.Simples(count, 1, 5);
            contador.Medio(count, 6, 99999);
        }

        private void ColunaB(List<TabelaDominio> itens, Contador contador)
        {
            itens.Caguetar();
            var count = itens.Select(x => x.QuantidadeAtributos).Count();
            contador.Simples(count, 1, 1);
            contador.Medio(count, 2, 5);
            contador.Complexo(count, 6, 99999);
        }

        private void ColunaC(List<TabelaDominio> itens, Contador contador)
        {
            itens.Caguetar();
            var count = itens.Select(x => x.QuantidadeAtributos).Count();
            contador.Medio(count, 1, 1);
            contador.Complexo(count, 2, 99999);
        }

    }
}
