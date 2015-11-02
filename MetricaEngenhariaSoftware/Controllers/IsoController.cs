using System.Web.Mvc;
using MetricaEngenhariaSoftware.DataBase.Repository;
using MetricaEngenhariaSoftware.Entity.Entidade.MES;

namespace MetricaEngenhariaSoftware.Controllers
{
    public class IsoController : Controller
    {
        public GenericRepository<MES_ISO> GenericRepository => new GenericRepository<MES_ISO>();

        [HttpGet]
        public ActionResult Grid()
        {
            var request = GenericRepository.GetAll();
            return View(request);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var request = id.HasValue ? GenericRepository.GetById(id.Value) : new MES_ISO();
            return View(request);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            GenericRepository.Delete(id);
            return RedirectToAction("Grid");
        }

        [HttpPost]
        public ActionResult AddOrUpdate(MES_ISO MES_ISO)
        {
            GenericRepository.AddOrUpdate(MES_ISO);

            return RedirectToAction("Grid");
        }
       
    }
}
