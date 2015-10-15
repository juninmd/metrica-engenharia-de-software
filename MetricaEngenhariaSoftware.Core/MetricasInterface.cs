using System.Collections.Generic;
using System.Linq;
using MetricaEngenhariaSoftware.Core.Entidade;

namespace MetricaEngenhariaSoftware.Core
{
    public class MetricasInterface
    {
        // TODO : Calcular Geral
        public List<TabelaInterface> CalcularInterface(TabelaDominioContainer tabelaDominioContainer)
        {
            var contador = new Contador();

            /* 1 a 19 - Atributos */
            var a = tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 1 && x.QuantidadeAtributos <= 19).Select(x => x.QuantidadeAtributos).Count();
            ColunaA(a, contador);

            /* 20 a 50 - Atributos */
            var b = tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 20 && x.QuantidadeAtributos <= 50).Select(x => x.QuantidadeAtributos).Count();
            ColunaB(b, contador);

            /* 51 ou mais - Atributos */
            var c = tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 51).Select(x => x.QuantidadeAtributos).Count();
            ColunaC(c, contador);


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

        private void ColunaA(int count, Contador contador)
        {
            if (count >= 6)
            {
                contador.medio += count;
            }
            else
            {
                contador.simples += count;
            }
        }
        private void ColunaB(int count, Contador contador)
        {
            if (count == 1)
            {
                contador.simples += count;
            }
            if (count >= 2 && count <= 5)
            {
                contador.medio += count;
            }
            if (count >= 6)
            {
                contador.complexo += count;
            }
        }

        private void ColunaC(int count, Contador contador)
        {
            if (count == 1)
            {
                contador.simples += count;
            }
            if (count >= 2)
            {
                contador.complexo += count;
            }
        }
    }
}
