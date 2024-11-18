using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class ArtistaService //: IArtistaService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public ArtistaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);
        }

        public async Task<IEnumerable<Artista>> GetArtistasAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Artista/ObtenerArtistaTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Artista>>();
        }

        public async Task<bool> CreateArtistaAsync(Artista Artista, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Artista/InsertarArtista", Artista);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateArtistaAsync(Artista Artista, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Artista/ActualizarArtista", Artista);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteArtistaAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Artista/EliminarArtista/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
