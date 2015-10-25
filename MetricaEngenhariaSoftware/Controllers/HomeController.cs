using System.Web.Mvc;

namespace MetricaEngenhariaSoftware.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult InserirTabelas()
        {
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