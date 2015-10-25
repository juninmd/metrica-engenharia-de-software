using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MetricaEngenhariaSoftware.Core.Entidade.Tabela_Base;

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
        public ActionResult InserirTabelas(FormCollection form)
        {
            var nomeSplit = form["NomeTabela"].Split(',');
            var atributosSplit = form["QuantidadeAtributos"].Split(',');

            var tabelaDominio = nomeSplit.Select((t, i) => new TabelaDominio
            {
                NomeTabela = t, QuantidadeAtributos = int.Parse(atributosSplit[i]),
            }).ToList();

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
            return View();
        }

    }
}