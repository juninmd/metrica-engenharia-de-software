using System.Linq;
using MetricaEngenhariaSoftware.Core.CalcularMetricas;
using MetricaEngenhariaSoftware.Entity.Entidade;
using MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base;

namespace MetricaEngenhariaSoftware.Core
{
    public class Gerenciar
    {
        public MetricasOut Inserir(MetricasIn metricasIn)
        {
            var tabelasBrutas = CalcularTabelasBrutas(metricasIn);
            var metricasOut = new MetricasOut
            {
                TabelasBrutas = tabelasBrutas,
                FPB = CalcularFPB(tabelasBrutas)
            };

/*
            CalcularCusto(tabelaDominioContainer);

            tabelaDominioContainer.TempoTotalGeral = CalcularTempo(tabelaDominioContainer.Meses);
            tabelaDominioContainer.TempoTotal = double.Parse((tabelaDominioContainer.Meses).ToString().Substring(0, tabelaDominioContainer.Meses.ToString().IndexOf(",") + 3));
            tabelaDominioContainer.CalculoFinal = tabelaDominioContainer.TempoTotal * tabelaDominioContainer.PrecoDaLinguagem * 20.0;
            return tabelaDominioContainer;*/

            return metricasOut;
        }


        private string CalcularTempo(double containerMeses)
        {
            var mesesTotal = (containerMeses).ToString().Substring(0, containerMeses.ToString().IndexOf(",") + 3);
            var meses = mesesTotal.Split(',')[0];
            var porcMeses = mesesTotal.Split(',')[1];

            var diasTotal = 22 * double.Parse("0," + porcMeses);
            var dias = diasTotal.ToString().Split(',')[0];

            var horasTotal = 6 * double.Parse("0," + diasTotal.ToString().Split(',')[1]);
            var horas = horasTotal.ToString().Split(',')[0];

            var minutosTotal = 60 * double.Parse("0," + horasTotal.ToString().Split(',')[1]);
            var minutos = minutosTotal.ToString().Split(',')[0];

            var segundosTotal = 60 * double.Parse("0," + minutosTotal.ToString().Split(',')[1]);
            var segundos = segundosTotal.ToString().Split(',')[0];

            return $"Meses : {meses} | Dias: {dias} | Horas: {horas} | Minutos: {minutos} | Segundos: {segundos}";
        }

        private TabelasBrutas CalcularTabelasBrutas(MetricasIn tabelaDominioContainer)
        {

            return new TabelasBrutas
            {
                TabelaEntrada = new MetricasEntrada().CalcularEntrada(tabelaDominioContainer),
                TabelaSaida = new MetricasSaida().CalcularSaida(tabelaDominioContainer),
                TabelaConsulta = new MetricasConsulta().CalcularConsulta(tabelaDominioContainer),
                TabelaArquivo = new MetricasArquivo().CalcularArquivo(tabelaDominioContainer),
                TabelaInterface = new MetricasInterface().CalcularInterface(tabelaDominioContainer)
            };

        }

        public int CalcularFPB(TabelasBrutas tabelasBrutas)
        {
            return (tabelasBrutas.TabelaEntrada.Select(x => x.Resultado).Sum() +
                tabelasBrutas.TabelaSaida.Select(x => x.Resultado).Sum() +
                tabelasBrutas.TabelaConsulta.Select(x => x.Resultado).Sum() +
                tabelasBrutas.TabelaArquivo.Select(x => x.Resultado).Sum() +
                tabelasBrutas.TabelaInterface.Select(x => x.Resultado).Sum());
        }


        private void CalcularTipoLinguagem()
        {
            
        }
        private void CalcularCusto(MetricasIn tabelaDominioContainer)
        {
            /*  /* Calcula por tipo Linguagem  1 -java 2 -vb 3 -gc#1#
              switch (tabelaDominioContainer.LinguagemDoSistema)
              {
                  case 1:
                      tabelaDominioContainer.PrecoDaLinguagem = tabelaDominioContainer.TabelasBrutas.CalculoBase * Linguagens.Java;
                      tabelaDominioContainer.NomeLinguagemDoSistema = "JAVA";
                      break;
                  case 2:
                      tabelaDominioContainer.PrecoDaLinguagem = tabelaDominioContainer.TabelasBrutas.CalculoBase * Linguagens.VB;
                      tabelaDominioContainer.NomeLinguagemDoSistema = "VISUAL BASIC";
                      break;
                  case 3:
                      tabelaDominioContainer.PrecoDaLinguagem = tabelaDominioContainer.TabelasBrutas.CalculoBase * Linguagens.GC;
                      tabelaDominioContainer.NomeLinguagemDoSistema = "GERADOR DE CÓDIGO";
                      break;
              }
              /* Calcula por tipo de sistema 1web 2comercial#1#
              switch (tabelaDominioContainer.TipoDoSistema)
              {
                  case 1:
                      tabelaDominioContainer.Meses = tabelaDominioContainer.PrecoDaLinguagem / Sistema.Web;
                      tabelaDominioContainer.NomeTipoDoSistema = "SISTEMA WEB";

                      break;
                  case 2:
                      tabelaDominioContainer.Meses = tabelaDominioContainer.PrecoDaLinguagem / Sistema.Comercial;
                      tabelaDominioContainer.NomeTipoDoSistema = "SISTEMA COMERCIAL";
                      break;
                  case 3:
                      tabelaDominioContainer.Meses = tabelaDominioContainer.PrecoDaLinguagem / Sistema.ComercioEletronico;
                      tabelaDominioContainer.NomeTipoDoSistema = "E-comerce";
                      break;
              }
  */
        }


    }
}
