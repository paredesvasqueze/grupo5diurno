using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class ReproduccionService //: IReproduccionService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public ReproduccionService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);
        }

        public async Task<IEnumerable<Reproduccion>> GetReproduccionsAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Reproduccion/ObtenerReproduccionTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Reproduccion>>();
        }

        public async Task<bool> CreateReproduccionAsync(Reproduccion Reproduccion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Reproduccion/InsertarReproduccion", Reproduccion);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateReproduccionAsync(Reproduccion Reproduccion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Reproduccion/ActualizarReproduccion", Reproduccion);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteReproduccionAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Reproduccion/EliminarReproduccion/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
