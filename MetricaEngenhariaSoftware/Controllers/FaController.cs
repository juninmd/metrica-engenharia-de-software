using System.Web.Mvc;
using MetricaEngenhariaSoftware.DataBase.Repository;
using MetricaEngenhariaSoftware.Entity.Entidade.MES;

namespace MetricaEngenhariaSoftware.Controllers
{
    public class FaController : Controller
    {
        public GenericRepository<MES_FA> GenericRepository => new GenericRepository<MES_FA>();

        [HttpGet]
        public ActionResult Grid()
        {
            var request = GenericRepository.GetAll();
            return View(request);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var request = GenericRepository.GetById(id);
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            GenericRepository.Delete(id);
            return RedirectToAction("Grid");
        }

        [HttpPost]
        public ActionResult Create(MES_FA MES_FA)
        {
            GenericRepository.Add(MES_FA);

            return RedirectToAction("Grid");
        }

        [HttpPost]
        public ActionResult Edit(MES_FA MES_FA)
        {

            GenericRepository.Update(MES_FA);

            return RedirectToAction("Grid");
        }
    }
}
