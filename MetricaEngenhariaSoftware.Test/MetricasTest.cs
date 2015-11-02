using System;
using System.Collections.Generic;
using System.Linq;
using MetricaEngenhariaSoftware.Core.CalcularMetricas;
using MetricaEngenhariaSoftware.Entity.Entidade;
using MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base;
using MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base.TiposTabela;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetricaEngenhariaSoftware.Test
{
    [TestClass]
    public class MetricasTest
    {
        public MetricasEntrada MetricasEntrada => new MetricasEntrada();
        public MetricasArquivo MetricasArquivo => new MetricasArquivo();
        public MetricasInterface MetricasInterface => new MetricasInterface();
        public MetricasConsulta MetricasConsulta => new MetricasConsulta();
        public MetricasSaida MetricasSaida => new MetricasSaida();
        public MetricasBase MetricasBase => new MetricasBase();

        private TabelaDominioContainer TabelaDefault()
        {
            var TabelaDominioContainer = new TabelaDominioContainer
            {
                TabelaDominio = new List<TabelaDominio>
                {
                    new TabelaDominio
                    {
                        NomeTabela = "Cliente",
                        QuantidadeAtributos = 6,
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
                     },
                }
            };
            var geral = TabelaDominioContainer.TabelaDominio.Select(x => x.QuantidadeAtributos).Sum();

            TabelaDominioContainer.TabelaDominio.Add(new TabelaDominio
            {
                NomeTabela = "Geral",
                QuantidadeAtributos = geral
            });
            return TabelaDominioContainer;
        }


        [TestMethod]
        public void CalcularTiposTabela()
        {
            var TabelaDominioContainer = TabelaDefault();

            var calcularEntrada = MetricasEntrada.CalcularEntrada(TabelaDominioContainer);
            ValidarEntrada(calcularEntrada);

            var calcularSaida = MetricasSaida.CalcularSaida(TabelaDominioContainer);
            ValidarSaida(calcularSaida);

            var calcularConsulta = MetricasConsulta.CalcularConsulta(TabelaDominioContainer);
            ValidarConsulta(calcularConsulta);

            var calcularArquivo = MetricasArquivo.CalcularArquivo(TabelaDominioContainer);
            ValidarArquivo(calcularArquivo);

            var calcularInterface = MetricasInterface.CalcularInterface(TabelaDominioContainer);
            ValidarInterface(calcularInterface);

            var TabelasBrutas = new TabelasBrutas
            {
                TabelaEntrada = calcularEntrada,
                TabelaSaida = calcularSaida,
                TabelaConsulta = calcularConsulta,
                TabelaArquivo = calcularArquivo,
                TabelaInterface = calcularInterface
            };

            var totalFPB = TabelasBrutas.FPB;
            ValidarFPB(totalFPB);


            var valorBase = Math.Round(MetricasBase.CalcularBase(totalFPB));
 
        }



        private void ValidarEntrada(List<TabelaEntrada> lista)
        {
            Assert.AreEqual(lista[0].NumeroOcorrencia, 0);
            Assert.AreEqual(lista[0].Complexidade, TabelaEntradaPeso.Simples);
            Assert.AreEqual(lista[0].Peso, 3);
            Assert.AreEqual(lista[0].Resultado, 0);

            Assert.AreEqual(lista[1].NumeroOcorrencia, 4);
            Assert.AreEqual(lista[1].Complexidade, TabelaEntradaPeso.Medio);
            Assert.AreEqual(lista[1].Peso, 4);
            Assert.AreEqual(lista[1].Resultado, 16);

            Assert.AreEqual(lista[2].NumeroOcorrencia, 5);
            Assert.AreEqual(lista[2].Complexidade, TabelaEntradaPeso.Complexo);
            Assert.AreEqual(lista[2].Peso, 6);
            Assert.AreEqual(lista[2].Resultado, 30);
        }

        private void ValidarSaida(List<TabelaSaida> lista)
        {
            Assert.AreEqual(lista[0].NumeroOcorrencia, 0);
            Assert.AreEqual(lista[0].Complexidade, TabelaSaidaPeso.Simples);
            Assert.AreEqual(lista[0].Peso, 4);
            Assert.AreEqual(lista[0].Resultado, 0);

            Assert.AreEqual(lista[1].NumeroOcorrencia, 10);
            Assert.AreEqual(lista[1].Complexidade, TabelaSaidaPeso.Medio);
            Assert.AreEqual(lista[1].Peso, 5);
            Assert.AreEqual(lista[1].Resultado, 50);

            Assert.AreEqual(lista[2].NumeroOcorrencia, 0);
            Assert.AreEqual(lista[2].Complexidade, TabelaSaidaPeso.Complexo);
            Assert.AreEqual(lista[2].Peso, 7);
            Assert.AreEqual(lista[2].Resultado, 0);
        }

        private void ValidarConsulta(List<TabelaConsulta> lista)
        {
            Assert.AreEqual(lista[0].NumeroOcorrencia, 0);
            Assert.AreEqual(lista[0].Complexidade, TabelaConsultaPeso.Simples);
            Assert.AreEqual(lista[0].Peso, 3);
            Assert.AreEqual(lista[0].Resultado, 0);

            Assert.AreEqual(lista[1].NumeroOcorrencia, 5);
            Assert.AreEqual(lista[1].Complexidade, TabelaConsultaPeso.Medio);
            Assert.AreEqual(lista[1].Peso, 4);
            Assert.AreEqual(lista[1].Resultado, 20);

            Assert.AreEqual(lista[2].NumeroOcorrencia, 5);
            Assert.AreEqual(lista[2].Complexidade, TabelaConsultaPeso.Complexo);
            Assert.AreEqual(lista[2].Peso, 6);
            Assert.AreEqual(lista[2].Resultado, 30);
        }

        private void ValidarArquivo(List<TabelaArquivo> lista)
        {
            Assert.AreEqual(lista[0].NumeroOcorrencia, 0);
            Assert.AreEqual(lista[0].Complexidade, TabelaArquivoPeso.Simples);
            Assert.AreEqual(lista[0].Peso, 7);
            Assert.AreEqual(lista[0].Resultado, 0);

            Assert.AreEqual(lista[1].NumeroOcorrencia, 9);
            Assert.AreEqual(lista[1].Complexidade, TabelaArquivoPeso.Medio);
            Assert.AreEqual(lista[1].Peso, 10);
            Assert.AreEqual(lista[1].Resultado, 90);

            Assert.AreEqual(lista[2].NumeroOcorrencia, 0);
            Assert.AreEqual(lista[2].Complexidade, TabelaArquivoPeso.Complexo);
            Assert.AreEqual(lista[2].Peso, 15);
            Assert.AreEqual(lista[2].Resultado, 0);
        }

        private void ValidarInterface(List<TabelaInterface> lista)
        {
            Assert.AreEqual(lista[0].NumeroOcorrencia, 1);
            Assert.AreEqual(lista[0].Complexidade, TabelaInterfacePeso.Simples);
            Assert.AreEqual(lista[0].Peso, 5);
            Assert.AreEqual(lista[0].Resultado, 5);

            Assert.AreEqual(lista[1].NumeroOcorrencia, 9);
            Assert.AreEqual(lista[1].Complexidade, TabelaInterfacePeso.Medio);
            Assert.AreEqual(lista[1].Peso, 7);
            Assert.AreEqual(lista[1].Resultado, 63);

            Assert.AreEqual(lista[2].NumeroOcorrencia, 0);
            Assert.AreEqual(lista[2].Complexidade, TabelaInterfacePeso.Complexo);
            Assert.AreEqual(lista[2].Peso, 10);
            Assert.AreEqual(lista[2].Resultado, 0);
        }

        private void ValidarFPB(int fpb)
        {
            Assert.AreEqual(fpb, 304);
        }
        private void validarBase(double intBase)
        {
            Assert.AreEqual(intBase, 359);
        }

    }
}
