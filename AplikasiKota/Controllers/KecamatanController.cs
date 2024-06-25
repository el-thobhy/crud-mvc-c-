using AplikasiKota.Web.Services;
using AplikasiKota.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AplikasiKota.Web.Controllers
{
    public class KecamatanController : Controller
    {
        private KecamatanServices _services;
        public KecamatanController(IConfiguration config)
        {
            _services = new KecamatanServices(config["API_URL"]);
        }
        public async Task<IActionResult> Index()
        {
            List<KecamatanViewModel> data = await _services.GetAllKecamatan();
            return View(data);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Title = "Input Data Kecamatan";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(KecamatanViewModel model)
        {
            KecamatanViewModel data = await _services.CreateKecamatan(model);
            if (data.Id == 0)
            {
                ViewBag.Message = "Fail To Post Data";
            }
            return RedirectToAction("Index", "Kecamatan");
        }

        public async Task<IActionResult> Edit(int id)
        {
            KecamatanViewModel data = await _services.GetByIdKecamatan(id);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(KecamatanViewModel dataParam)
        {
            KecamatanViewModel respon = await _services.UpdateKecamatan(dataParam);

            if (respon.Id == 0)
            {
                return Json(new { dataRespon = respon });
            }

            return View(dataParam);
        }


        public async Task<IActionResult> Delete(int id)
        {
            KecamatanViewModel data = await _services.GetByIdKecamatan(id);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> SoftDelete(int id)
        {
            KecamatanViewModel respon = await _services.SoftDeleteKecamatan(id);

            if (respon.Id == 0)
            {
                return Json(new { dataRespon = respon });
            }

            return RedirectToAction("Index");
        }

    }
}
