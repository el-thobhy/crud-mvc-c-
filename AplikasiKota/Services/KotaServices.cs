using AplikasiKota.Web.ViewModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AplikasiKota.Web.Services
{
    public class KotaServices
    {
        private static readonly HttpClient client = new HttpClient();
        private IConfiguration configuration;
        private string routeApi = "";
        KotaViewModel response = new KotaViewModel();

        public KotaServices(string apiUrl)
        {
            routeApi = apiUrl;
        }
        public async Task<List<KotaViewModel>> GetAllKota()
        {
            string response = await client.GetStringAsync($"{routeApi}/api/Kota/GetKotaNative");
            List<KotaViewModel>? data = JsonConvert.DeserializeObject<List<KotaViewModel>>(response);
            return data ?? new List<KotaViewModel>();
        }

        public async Task<KotaViewModel> CreateKota(KotaViewModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var request = await client.PostAsync($"{routeApi}/api/Kota/CreateKotaNative", content);


            if (request.IsSuccessStatusCode)
            {
                var apiResponse = await request.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<KotaViewModel>(apiResponse);
            }
            return response ?? new KotaViewModel();
        }


        public async Task<KotaViewModel> UpdateKota(KotaViewModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var request = await client.PutAsync($"{routeApi}/api/Kota/UpdateKotaNative", content);


            if (request.IsSuccessStatusCode)
            {
                var apiResponse = await request.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<KotaViewModel>(apiResponse);
            }
            return response ?? new KotaViewModel();
        }


        public async Task<KotaViewModel> SoftDeleteKota(int id)
        {
            var request = await client.DeleteAsync(routeApi + $"/api/Kota/DeleteKotaNative/{id}/{true}");

            if (request.IsSuccessStatusCode)
            {
                var apiRespon = await request.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<KotaViewModel>(apiRespon);
            }

            return response ?? new KotaViewModel();

        }


        public async Task<KotaViewModel> GetByIdKota(int id)
        {
            string response = await client.GetStringAsync($"{routeApi}/api/Kota/GetById/{id}");
           KotaViewModel data = JsonConvert.DeserializeObject<KotaViewModel>(response);
            return data ?? new KotaViewModel();
        }


    }
}
