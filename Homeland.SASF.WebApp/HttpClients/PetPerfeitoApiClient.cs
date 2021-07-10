using Homeland.SASF.Model;
using Newtonsoft.Json;
using RestSharp;
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


        public List<PetPerfeitoApi> GetPetsRestSharp()
        {
            var client = new RestClient("http://petperfeito.kinghost.net/view/api.php?senha=e23e434r5443e33ee3e22");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content", "application/json");
            request.AddHeader("Cookie", "PHPSESSID=376224c1074d781eb01b1bf9ab46c2cc");
            IRestResponse response = client.Execute(request);
            PetRestCharp petRestCharp = JsonConvert.DeserializeObject<PetRestCharp>(response.Content);
            return petRestCharp.pets.ToList();
        }
    }
}
