using FrontEnd.Models;

namespace FrontEnd.Servicio
{
    public class PlaylistService //: IPlaylistService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        string _baseURL = string.Empty;

        public PlaylistService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = _configuration["UrlBaseAPIs"];
            _httpClient.BaseAddress = new Uri(_baseURL);
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("Playlist/ObtenerPlaylistTodos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Playlist>>();
        }

        public async Task<bool> CreatePlaylistAsync(Playlist Playlist, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("Playlist/InsertarPlaylist", Playlist);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdatePlaylistAsync(Playlist Playlist, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync($"Playlist/ActualizarPlaylist", Playlist);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePlaylistAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"Playlist/EliminarPlaylist/{id}");
            return response.IsSuccessStatusCode;
        }


    }
}
