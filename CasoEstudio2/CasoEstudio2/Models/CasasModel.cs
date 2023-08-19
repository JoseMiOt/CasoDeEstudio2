using System.Net.Http.Headers;
using System.Net.Http;
using CasoEstudio2.Entities;
using CasoEstudio2.Interfaces;

namespace CasoEstudio2.Models
{
    public class CasasModel : ICasasModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private string _baseUrl;

        public CasasModel(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseUrl = _configuration.GetSection("Variables:urlBase").Value;
            _HttpContextAccessor = httpContextAccessor;
        }

        public CasasEntRespuesta? ConsultarCasas()
        {
            string url = "/api/Casas/ConsultarCasas";
            var response = _httpClient.GetAsync(_baseUrl + url).Result;
            return response.Content.ReadFromJsonAsync<CasasEntRespuesta>().Result;
        }

        public CasasEntRespuesta? ConsultarCasasDisponibles()
        {
            string url = "/api/Casas/ConsultarCasasDisponibles";
            var response = _httpClient.GetAsync(_baseUrl + url).Result;
            return response.Content.ReadFromJsonAsync<CasasEntRespuesta>().Result;
        }

        public CasasEntRespuesta? AlquilarCasa(CasasEntRespuesta entidad)
        {
            string url = "/api/Casas/AlquilarCasa";
            JsonContent jsonObject = JsonContent.Create(entidad);
            var response = _httpClient.PostAsync(_baseUrl + url, jsonObject).Result;
            return response.Content.ReadFromJsonAsync<CasasEntRespuesta>().Result;
        }


    }
}
