using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MetricaEngenhariaSoftware.Core.Utilidades;
using MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base;
using MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base.TiposTabela;

namespace MetricaEngenhariaSoftware.Core.CalcularMetricas
{
    public class MetricasConsulta
    {
        public List<TabelaConsulta> CalcularConsulta(MetricasIn tabelaDominioContainer)
        {
            Debug.WriteLine("######## CONSULTA ########");

            //tabelaDominioContainer.TabelaDominio = tabelaDominioContainer.TabelaDominio.Where(x => x.NomeTabela != "Geral").ToList();

            var contador = new Contador();

            /* 1 a 4 - Atributos */
            ColunaA(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 1 && x.QuantidadeAtributos <= 4).ToList(), contador);

            /* 5 a 15 - Atributos */
            ColunaB(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 5 && x.QuantidadeAtributos <= 15).ToList(), contador);

            /* 16 ou mais - Atributos */
            ColunaC(tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 16).ToList(), contador);

            Debug.WriteLine("######## FIM CONSULTA ########");

            return new List<TabelaConsulta>
            {
                new TabelaConsulta
                {
                    Complexidade = TabelaConsultaPeso.Simples,
                    NumeroOcorrencia = contador.simples
                },
                 new TabelaConsulta
                {
                    Complexidade = TabelaConsultaPeso.Medio,
                    NumeroOcorrencia = contador.medio
                },
                  new TabelaConsulta
                {
                    Complexidade = TabelaConsultaPeso.Complexo,
                    NumeroOcorrencia = contador.complexo
                }
            };

        }


        private void ColunaA(List<TabelaDominio> itens, Contador contador)
        {
            itens.Caguetar();
            var count = itens.Select(x => x.QuantidadeAtributos).Count();
            contador.Simples(count, 0, 2);
            contador.Medio(count, 3, 99);
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
