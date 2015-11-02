using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MetricaEngenhariaSoftware.Core.Utilidades;
using MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base;
using MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base.TiposTabela;

namespace MetricaEngenhariaSoftware.Core.CalcularMetricas
{
    public class MetricasArquivo
    {
        public List<TabelaArquivo> CalcularArquivo(TabelaDominioContainer tabelaDominioContainer)
        {
            Debug.WriteLine("######## ARQUIVO ########");

            var contador = new Contador();

            /* 1 a 19 - Atributos */
            ColunaA(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 1 && x.QuantidadeAtributos <= 19 && x.NomeTabela != "Geral").ToList(), contador);

            /* 20 a 50 - Atributos */
            ColunaB(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 20 && x.QuantidadeAtributos <= 50 && x.NomeTabela != "Geral").ToList(), contador);

            /* 51 ou mais - Atributos */
            ColunaC(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 51 && x.NomeTabela != "Geral").ToList(), contador);

            Debug.WriteLine("######## FIM ARQUIVO ########");

            return new List<TabelaArquivo>
            {
                new TabelaArquivo
                {
                    Complexidade = TabelaArquivoPeso.Simples,
                    NumeroOcorrencia = contador.simples
                },
                 new TabelaArquivo
                {
                    Complexidade = TabelaArquivoPeso.Medio,
                    NumeroOcorrencia = contador.medio
                },
                  new TabelaArquivo
                {
                    Complexidade = TabelaArquivoPeso.Complexo,
                    NumeroOcorrencia = contador.complexo
                }
            };

        }

        private void ColunaA(List<TabelaDominio> itens, Contador contador)
        {
            itens.Caguetar();
            var count = itens.Select(x => x.QuantidadeAtributos).Count();
            contador.Simples(count, 1, 5);
            contador.Medio(count, 6, 9999);
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
            contador.Medio(count, 0, 1);
            contador.Complexo(count, 2, 99999);
        }

    }
}
