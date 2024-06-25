using AplikasiKota.Web.Services;
using AplikasiKota.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AplikasiKota.Web.Controllers
{
    public class KotaController : Controller
    {
        private KotaServices _services;
        public KotaController(IConfiguration config)
        {
            _services = new KotaServices(config["API_URL"]);
        }
        public async Task<IActionResult> Index()
        {
            List<KotaViewModel> data = await _services.GetAllKota();
            return View(data);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Title = "Input Data Kota";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(KotaViewModel model)
        {
            KotaViewModel data = await _services.CreateKota(model);
            if (data.Id == 0)
            {
                ViewBag.Message = "Fail To Post Data";
            }
            return RedirectToAction("Index", "Kota");
        }


        public async Task<IActionResult> Edit(int id)
        {
            KotaViewModel data = await _services.GetByIdKota(id);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(KotaViewModel dataParam)
        {
            KotaViewModel respon = await _services.UpdateKota(dataParam);

            if (respon.Id == 0)
            {
                return Json(new { dataRespon = respon });
            }

            return View(dataParam);
        }


        public async Task<IActionResult> Delete(int id)
        {
            KotaViewModel data = await _services.GetByIdKota(id);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> SoftDelete(int id)
        {
            KotaViewModel respon = await _services.SoftDeleteKota(id);

            if (respon.Id == 0)
            {
                return Json(new { dataRespon = respon });
            }

            return RedirectToAction("Index");
        }
    }
}
