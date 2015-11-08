using System.Linq;
using System.Web.Mvc;
using MetricaEngenhariaSoftware.Core;
using MetricaEngenhariaSoftware.Entity.Entidade.Tabela_Base;

namespace MetricaEngenhariaSoftware.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult InserirTabelas()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InserirTabelas(FormCollection form, MetricasIn metricasIn)
        {
            var nomeSplit = form["NomeTabela"].Split(',');
            var atributosSplit = form["QuantidadeAtributos"].Split(',');

            metricasIn.TabelaDominio = nomeSplit.Select((t, i) => new TabelaDominio
            {
                NomeTabela = t,
                QuantidadeAtributos = int.Parse(atributosSplit[i]),
            }).ToList();

            /* Adiciona Tabela Geral, calculando como base a quantidade de atributos GERAL*/
            metricasIn.TabelaDominio.Add(new TabelaDominio
            {
                NomeTabela = "Geral",
                QuantidadeAtributos = metricasIn.TabelaDominio.Select(x => x.QuantidadeAtributos).Sum()
            });

            var TabelaDominioContainer = new Gerenciar().Inserir(metricasIn);

            /* Armazena em Session */
            HttpContext.Session["TabelaDominioContainer"] = TabelaDominioContainer;

            return View();
        }

        [HttpGet]
        public ActionResult Parametros()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Resultados()
        {
            if (HttpContext.Session["TabelaDominioContainer"] == null)
                return View();

            var tabelaDominio = (MetricasOut)HttpContext.Session["TabelaDominioContainer"];
            return View(tabelaDominio);
        }

    }
}