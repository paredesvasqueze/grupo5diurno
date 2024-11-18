using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class CancionService //: ICancionService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public CancionService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);
        }

        public async Task<IEnumerable<Cancion>> GetCancionsAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Cancion/ObtenerCancionTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Cancion>>();
        }

        public async Task<bool> CreateCancionAsync(Cancion Cancion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Cancion/InsertarCancion", Cancion);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCancionAsync(Cancion Cancion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Cancion/ActualizarCancion", Cancion);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCancionAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Cancion/EliminarCancion/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
