using Homeland.SASF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Homeland.SASF.WebApp.HttpClients
{
    public class PetPerfeitoApiClient
    {
        private readonly HttpClient _httpClient;

        public PetPerfeitoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
        }

        public async Task<List<PetPerfeitoApi>> GetPets()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<PetPerfeitoApi>>();
        }
    }
}
