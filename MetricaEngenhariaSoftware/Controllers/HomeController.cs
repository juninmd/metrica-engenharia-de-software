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
        public ActionResult InserirTabelas(FormCollection form)
        {
            var nomeSplit = form["NomeTabela"].Split(',');
            var atributosSplit = form["QuantidadeAtributos"].Split(',');

            var tabelaDominio = nomeSplit.Select((t, i) => new TabelaDominio
            {
                NomeTabela = t,
                QuantidadeAtributos = int.Parse(atributosSplit[i]),
            }).ToList();

            var TabelaDominioContainer = new Gerenciar().Inserir(tabelaDominio, int.Parse(form["LinguagemDoSistema"]), int.Parse(form["TipoDoSistema"]));

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

            var tabelaDominio = (TabelaDominioContainer)HttpContext.Session["TabelaDominioContainer"];
            return View(tabelaDominio);
        }

    }
}