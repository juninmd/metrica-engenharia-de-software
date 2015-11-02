using System.Web.Mvc;
using MetricaEngenhariaSoftware.DataBase.Repository;
using MetricaEngenhariaSoftware.Entity.Entidade.MES;

namespace MetricaEngenhariaSoftware.Controllers
{
    public class TipoSistemaController : Controller
    {
        public GenericRepository<MES_TIPO_SISTEMA> GenericRepository => new GenericRepository<MES_TIPO_SISTEMA>();

        [HttpGet]
        public ActionResult Grid()
        {
            var request = GenericRepository.GetAll();
            return View(request);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var request = id.HasValue ? GenericRepository.GetById(id.Value) : new MES_TIPO_SISTEMA();
            return View(request);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            GenericRepository.Delete(id);
            return RedirectToAction("Grid");
        }

        [HttpPost]
        public ActionResult AddOrUpdate(MES_TIPO_SISTEMA MES_TIPO_SISTEMA)
        {
            GenericRepository.AddOrUpdate(MES_TIPO_SISTEMA);

            return RedirectToAction("Grid");
        }
       
    }
}
