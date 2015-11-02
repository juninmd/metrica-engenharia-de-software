using System.Web.Mvc;
using MetricaEngenhariaSoftware.DataBase.Repository;
using MetricaEngenhariaSoftware.Entity.Entidade.MES;

namespace MetricaEngenhariaSoftware.Controllers
{
    public class LinguagemController : Controller
    {
        public GenericRepository<MES_LINGUAGEM_PROGRAMACAO> GenericRepository => new GenericRepository<MES_LINGUAGEM_PROGRAMACAO>();

        [HttpGet]
        public ActionResult Grid()
        {
            var request = GenericRepository.GetAll();
            return View(request);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var request = id.HasValue ? GenericRepository.GetById(id.Value) : new MES_LINGUAGEM_PROGRAMACAO();
            return View(request);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            GenericRepository.Delete(id);
            return RedirectToAction("Grid");
        }

        [HttpPost]
        public ActionResult AddOrUpdate(MES_LINGUAGEM_PROGRAMACAO MES_LINGUAGEM_PROGRAMACAO)
        {
            GenericRepository.AddOrUpdate(MES_LINGUAGEM_PROGRAMACAO);

            return RedirectToAction("Grid");
        }
       
    }
}
