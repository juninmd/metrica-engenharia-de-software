﻿using System.Collections.Generic;
using System.Linq;
using MetricaEngenhariaSoftware.Core.Entidade;

namespace MetricaEngenhariaSoftware.Core
{
    public class MetricasConsulta
    {
        // TODO : Calcular Geral
        public List<TabelaConsulta> CalcularConsulta(TabelaDominioContainer tabelaDominioContainer)
        {
            //tabelaDominioContainer.TabelaDominio = tabelaDominioContainer.TabelaDominio.Where(x => x.NomeTabela != "Geral").ToList();

            var contador = new Contador();

            /* 1 a 4 - Atributos */
            var a = tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 1 && x.QuantidadeAtributos <= 4).Select(x => x.QuantidadeAtributos).Count();
            ColunaA(a, contador);

            /* 5 a 15 - Atributos */
            var b = tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 5 && x.QuantidadeAtributos <= 15).Select(x => x.QuantidadeAtributos).Count();
            ColunaB(b, contador);

            /* 16 ou mais - Atributos */
            var c = tabelaDominioContainer.TabelaDominio.Where(x => x.QuantidadeAtributos >= 16).Select(x => x.QuantidadeAtributos).Count();
            ColunaC(c, contador);

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

        private void ColunaA(int count, Contador contador)
        {
            if (count >= 0 && count <= 2)
            {
                contador.simples += count;
            }
            if (count >= 3)
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
                contador.medio += count;
            }
            if (count >= 2)
            {
                contador.complexo += count;
            }
        }

        private void Geral(int count, Contador contador)
        {
            if (count >= 1 && count <= 15)
            {
                contador.simples += count;
            }
            if (count >= 16)
            {
                contador.medio += count;
            }
        }
    }
}
