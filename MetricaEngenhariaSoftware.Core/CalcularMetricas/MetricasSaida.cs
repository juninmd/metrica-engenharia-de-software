using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MetricaEngenhariaSoftware.Core.Utilidades;
using MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base;
using MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base.TiposTabela;

namespace MetricaEngenhariaSoftware.Core.CalcularMetricas
{
    public class MetricasSaida
    {
        public List<TabelaSaida> CalcularSaida(TabelaDominioContainer tabelaDominioContainer)
        {
            Debug.WriteLine("######## SAIDA ########");

            var contador = new Contador();

            /* 1 a 5 - Atributos */
            ColunaA(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 1 && x.QuantidadeAtributos <= 5).ToList(), contador);

            /* 6 a 19 - Atributos */
            ColunaB(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 6 && x.QuantidadeAtributos <= 19).ToList(), contador);

            /* 20 ou mais - Atributos */
            ColunaC(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 20).ToList(), contador);

            Debug.WriteLine("######## FIM SAIDA ########");

            return new List<TabelaSaida>
            {
                new TabelaSaida
                {
                    Complexidade = TabelaSaidaPeso.Simples,
                    NumeroOcorrencia = contador.simples
                },
                 new TabelaSaida
                {
                    Complexidade = TabelaSaidaPeso.Medio,
                    NumeroOcorrencia = contador.medio
                },
                  new TabelaSaida
                {
                    Complexidade = TabelaSaidaPeso.Complexo,
                    NumeroOcorrencia = contador.complexo
                }
            };

        }


        private void ColunaA(List<TabelaDominio> itens, Contador contador)
        {
            itens.Caguetar();
            var count = itens.Select(x => x.QuantidadeAtributos).Count();
            contador.Simples(count, 1, 3);
            contador.Medio(count, 4, 99999);
        }

        private void ColunaB(List<TabelaDominio> itens, Contador contador)
        {
            itens.Caguetar();
            var count = itens.Select(x => x.QuantidadeAtributos).Count();
            contador.Simples(count, 1, 1);
            contador.Medio(count, 2, 3);
            contador.Complexo(count, 4, 99999);
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
