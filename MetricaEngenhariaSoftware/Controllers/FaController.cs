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
        public ActionResult Details(int? id)
        {
            var request = id.HasValue ? GenericRepository.GetById(id.Value) : new MES_FA();
            return View(request);
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
            if (MES_FA.IntIdFa == 0)
                GenericRepository.Add(MES_FA);
            else
            {
                GenericRepository.Update(MES_FA);
            }

            return RedirectToAction("Grid");
        }
       
    }
}
