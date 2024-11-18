using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class CancionArtistaService //: ICancionArtistaService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public CancionArtistaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);
        }

        public async Task<IEnumerable<CancionArtista>> GetCancionArtistasAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("CancionArtista/ObtenerCancionArtistaTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<CancionArtista>>();
        }

        public async Task<bool> CreateCancionArtistaAsync(CancionArtista CancionArtista, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("CancionArtista/InsertarCancionArtista", CancionArtista);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCancionArtistaAsync(CancionArtista CancionArtista, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"CancionArtista/ActualizarCancionArtista", CancionArtista);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCancionArtistaAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"CancionArtista/EliminarCancionArtista/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
