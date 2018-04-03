using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using nDeath.BLL.BusinesModel;
using nDeath.BLL.DTO;
using nDeath.WEB.Models;
using nDeath.BLL.Interfaces;
using System.Threading;

namespace nDeath.WEB.Controllers
{
    public class DeathController : Controller
    {
        private IDataService service;

        public DeathController(IDataService _service)
        {
            service = _service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(ParamViewModel coefficient)
        {

            if (ModelState.IsValid)
            {
                ParamDTO _coefficient = coefficient.ReplaceType(coefficient);
                PointsParabola pointPar = new PointsParabola(coefficient.ReplaceType(coefficient));
                int paramId = await service.FindParamsIdAsync(_coefficient);
                List<CacheDataDTO> cacheData = new List<CacheDataDTO>();
                List<PointsViewModel> points = new List<PointsViewModel>();
                if (paramId == -1)
                {
                   cacheData = pointPar.GetCacheDatas(_coefficient);
                   await service.AddParamsAndCacheDataAsync(_coefficient, cacheData);
                }
                else
                {
                    cacheData = await service.GetCacheDataAsync(paramId);
                }
                foreach (var c in cacheData)
                {
                    points.Add(new PointsViewModel(c.PointX, c.PointY));
                }
                ViewBag.Result = points;
                ViewBag.IsRotated = coefficient.A < 0;
                return View("Index");
            }
            return View("Index");
        }
    }
}