using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class SuscripcionService //: ISuscripcionService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public SuscripcionService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);
        }

        public async Task<IEnumerable<Suscripcion>> GetSuscripcionsAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Suscripcion/ObtenerSuscripcionTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Suscripcion>>();
        }

        public async Task<bool> CreateSuscripcionAsync(Suscripcion Suscripcion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Suscripcion/InsertarSuscripcion", Suscripcion);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateSuscripcionAsync(Suscripcion Suscripcion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Suscripcion/ActualizarSuscripcion", Suscripcion);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteSuscripcionAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Suscripcion/EliminarSuscripcion/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
