using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class PlaService //: IPlaService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public PlaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);
        }

        public async Task<IEnumerable<Pla>> GetPlasAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Pla/ObtenerPlaTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pla>>();
        }

        public async Task<bool> CreatePlaAsync(Pla Pla, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Pla/InsertarPla", Pla);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdatePlaAsync(Pla Pla, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Pla/ActualizarPla", Pla);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePlaAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Pla/EliminarPla/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
