using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MetricaEngenhariaSoftware.Core.Entidade;

namespace MetricaEngenhariaSoftware.Core
{
    public class MetricasSaida
    {
        public List<TabelaSaida> CalcularSaida(TabelaDominioContainer tabelaDominioContainer)
        {
            //tabelaDominioContainer.TabelaDominio = tabelaDominioContainer.TabelaDominio.Where(x => x.NomeTabela != "Geral").ToList();

            var contador = new Contador();

            /* 1 a 5 - Atributos */
            var a = tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 1 && x.QuantidadeAtributos <= 5).Select(x => x.QuantidadeAtributos).Count();
            ColunaA(a, contador);

            /* 6 a 19 - Atributos */
            var b = tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 6 && x.QuantidadeAtributos <= 19).Select(x => x.QuantidadeAtributos).Count();
            ColunaB(b, contador);

            /* 20 ou mais - Atributos */
            var c = tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 20).Select(x => x.QuantidadeAtributos).Count();
            ColunaC(c, contador);

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

        private void ColunaA(int count, Contador contador)
        {
            if (count >= 0 && count <= 3)
            {
                contador.simples += count;
            }
            if (count >= 4)
            {
                contador.medio += count;

            }
        }
        private void ColunaB(int count, Contador contador)
        {
            if (count == 1)
            {
                contador.simples += count;
            }
            if (count >= 2 && count <= 3)
            {
                contador.medio += count;
            }
            if (count >= 4)
            {
                contador.complexo += count;
            }
        }

        private void ColunaC(int count, Contador contador)
        {
            if (count >= 0 && count <= 1)
            {
                contador.medio += count;
            }
            if (count >= 2)
            {
                contador.complexo += count;
            }
        }

    }
}
