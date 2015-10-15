using System;
using System.Collections.Generic;
using MetricaEngenhariaSoftware.Core;
using MetricaEngenhariaSoftware.Core.Entidade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetricaEngenhariaSoftware.Test
{
    [TestClass]
    public class MetricasTest
    {
        public MetricasEntrada Metricas => new MetricasEntrada();

        [TestMethod]
        public void CalcularEntrada()
        {
            var TabelaDominioContainer = new TabelaDominioContainer
            {
                TabelaDominio = new List<TabelaDominio>
                {
                    new TabelaDominio
                    {
                        NomeTabela = "Cliente",
                        QuantidadeAtributos = 7,
                    },
                     new TabelaDominio
                    {
                        NomeTabela = "Viagem",
                        QuantidadeAtributos = 7,
                    },
                      new TabelaDominio
                    {
                        NomeTabela = "Rota",
                        QuantidadeAtributos = 4,
                    }
                      , new TabelaDominio
                    {
                        NomeTabela = "PontoParada",
                        QuantidadeAtributos = 2,
                    },
                           new TabelaDominio
                    {
                        NomeTabela = "Atendente",
                        QuantidadeAtributos = 2,
                    },
                           new TabelaDominio
                    {
                        NomeTabela = "Funcionario",
                        QuantidadeAtributos = 5,
                    }, new TabelaDominio
                    {
                        NomeTabela = "Motorista",
                        QuantidadeAtributos = 2,
                    },
                     new TabelaDominio
                     {
                         NomeTabela = "Onibus",
                         QuantidadeAtributos = 5,
                     },
                      new TabelaDominio
                     {
                         NomeTabela = "Localização",
                         QuantidadeAtributos = 6,
                     }

                }
            };

            var retorno = Metricas.CalcularEntrada(TabelaDominioContainer);

        }
    }
}
