using AplikasiKota.Web.ViewModel;
using Newtonsoft.Json;
using System.Text;

namespace AplikasiKota.Web.Services
{
    public class KecamatanServices
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        private string routeApi = "";
        KecamatanViewModel response = new KecamatanViewModel();

        public KecamatanServices(string apiUrl)
        {
            routeApi = apiUrl;
        }
        public async Task<List<KecamatanViewModel>> GetAllKecamatan()
        {
            string response = await client.GetStringAsync($"{routeApi}/api/Kecamatan/GetKecamatanNative");
            List<KecamatanViewModel>? data = JsonConvert.DeserializeObject<List<KecamatanViewModel>>(response);
            return data ?? new List<KecamatanViewModel>();
        }


        public async Task<KecamatanViewModel> CreateKecamatan(KecamatanViewModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var request = await client.PostAsync($"{routeApi}/api/Kecamatan/CreateKecamatanNative", content);


            if (request.IsSuccessStatusCode)
            {
                var apiResponse = await request.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<KecamatanViewModel>(apiResponse);
            }
            return response ?? new KecamatanViewModel();
        }

        public async Task<KecamatanViewModel> UpdateKecamatan(KecamatanViewModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var request = await client.PutAsync($"{routeApi}/api/Kecamatan/UpdateKecamatanNative", content);


            if (request.IsSuccessStatusCode)
            {
                var apiResponse = await request.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<KecamatanViewModel>(apiResponse);
            }
            return response ?? new KecamatanViewModel();
        }

        public async Task<KecamatanViewModel> SoftDeleteKecamatan(int id)
        {
            var request = await client.DeleteAsync(routeApi + $"/api/Kecamatan/DeleteKecamatanNative/{id}/{true}");

            if (request.IsSuccessStatusCode)
            {
                var apiRespon = await request.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<KecamatanViewModel>(apiRespon);
            }

            return response ?? new KecamatanViewModel();

        }

        public async Task<KecamatanViewModel> GetByIdKecamatan(int id)
        {
            string response = await client.GetStringAsync($"{routeApi}/api/Kecamatan/GetById/{id}");
            KecamatanViewModel data = JsonConvert.DeserializeObject<KecamatanViewModel>(response);
            return data ?? new KecamatanViewModel();
        }
    }
}
