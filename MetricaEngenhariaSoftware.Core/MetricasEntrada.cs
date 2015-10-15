using System.Collections.Generic;
using System.Linq;
using MetricaEngenhariaSoftware.Core.Entidade;

namespace MetricaEngenhariaSoftware.Core
{
    public class MetricasEntrada
    {
        public List<TabelaEntrada> CalcularEntrada(TabelaDominioContainer tabelaDominioContainer)
        {
            var contador = new Contador();

            /* 1 a 4 - Atributos */
            var umAquatro = tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 1 && x.QuantidadeAtributos <= 4).Select(x => x.QuantidadeAtributos).Count();
            ColunaA(umAquatro, contador);

            /* 5 a 15 - Atributos */
            var cincoAquinze = tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 5 && x.QuantidadeAtributos <= 15).Select(x => x.QuantidadeAtributos).Count();
            ColunaB(cincoAquinze, contador);

            /* 16 ou mais - Atributos */
            var dezesseisOuMais = tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 16).Select(x => x.QuantidadeAtributos).Count();
            ColunaC(dezesseisOuMais, contador);

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

        private void ColunaA(int count, Contador contador)
        {
            if (count >= 3)
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
            if (count == 2)
            {
                contador.medio += count;
            }
            if (count >= 3)
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
