using System;
using System.Linq;
using MetricaEngenhariaSoftware.Core.CalcularMetricas;
using MetricaEngenhariaSoftware.DataBase.Repository;
using MetricaEngenhariaSoftware.Entity.Entidade;
using MetricaEngenhariaSoftware.Entity.Entidade.MES;
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
                FPB = CalcularFPB(tabelasBrutas),
                FA = CalcularFA(metricasIn.IntIdFa),
                LinguagemProgramacao = GetLinguagem(metricasIn.IntIdLinguagemProgramacao),
                TipoSistema = GetSistema(metricasIn.IntIdTipoSistema),
                MesIso = GetISO(metricasIn.IntIdIso)
            };

            metricasOut.CalculoBaseFA_FPB = CalcularBaseFAcomFPB(metricasOut.FA, metricasOut.FPB);

            metricasOut.PrecoDaLinguagem = CalcularPrecoLinguagem(metricasOut.CalculoBaseFA_FPB, metricasOut.LinguagemProgramacao);

            metricasOut.PrecoSistema = CalcularTipoSistema(metricasOut.PrecoDaLinguagem, metricasOut.TipoSistema);

            metricasOut.TempoTotalSistemaEmExtenso = CalcularTempo(metricasOut.PrecoSistema);

            metricasOut.CalculoISO = CalcularISO(metricasOut.PrecoSistema, metricasOut.MesIso);

            metricasOut.PrecoSistema = CalcularPrecoSistema(metricasOut.CalculoISO);


            return metricasOut;
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

        private double CalcularFA(int intIdFa)
        {
            return (double)new GenericRepository<MES_FA>().GetById(intIdFa).DecValorFa;
        }

        /// <summary>
        /// FA * FPB
        /// </summary>
        /// <param name="Fa"></param>
        /// <param name="FPB"></param>
        /// <returns></returns>
        private double CalcularBaseFAcomFPB(double Fa, double FPB)
        {
            return Math.Round(Fa * FPB);
        }

        private MES_LINGUAGEM_PROGRAMACAO GetLinguagem(int intIdLinguagem) => new GenericRepository<MES_LINGUAGEM_PROGRAMACAO>().GetById(intIdLinguagem);
        private MES_TIPO_SISTEMA GetSistema(int intIdSistema) => new GenericRepository<MES_TIPO_SISTEMA>().GetById(intIdSistema);
        private MES_ISO GetISO(int intIdIso) => new GenericRepository<MES_ISO>().GetById(intIdIso);

        /// <summary>
        /// Calculo Base * Preço da Linguagem
        /// </summary>
        /// <param name="calculoBaseFA_FPB"></param>
        /// <param name="mesLinguagemProgramacao"></param>
        /// <returns></returns>
        private double CalcularPrecoLinguagem(double calculoBaseFA_FPB, MES_LINGUAGEM_PROGRAMACAO mesLinguagemProgramacao) => calculoBaseFA_FPB * (double)mesLinguagemProgramacao.DecValorLinguagemProgramacao;

        /// <summary>
        /// <para>Retorna o tempo necessário para desenvolvedor por aquele tipo de sistema</para>
        /// <para>Preço da Linguagem / Tipo do Sistema</para>
        /// </summary>
        /// <param name="precoLinguagem"></param>
        /// <param name="mesTipoSistema"></param>
        /// <returns></returns>
        private double CalcularTipoSistema(double precoLinguagem, MES_TIPO_SISTEMA mesTipoSistema)
        {
            return precoLinguagem / (double)mesTipoSistema.DecValorTipoSistema;
        }

        private double CalcularISO(double precoTipoSistema, MES_ISO mesIso)
        {
            var mesesTotal = (precoTipoSistema).ToString().Substring(0, precoTipoSistema.ToString().IndexOf(",") + 3);

            return double.Parse(mesesTotal) * mesIso.IntValorIso;
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

        private double CalcularPrecoSistema(double valorIso)
        {

            return valorIso * 90;
        }
    }
}
