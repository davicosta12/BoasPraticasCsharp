using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos
{
    public class HttpClientPet
    {
        HttpClient client;

        public HttpClientPet(string url)
        {
            this.client = ConfiguraHttpClient(url);
        }

        private HttpClient ConfiguraHttpClient(string url)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);
            return _client;
        }

        public async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }

        public Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            HttpResponseMessage? response = null;
            using (response = new HttpResponseMessage())
            {
                return client.PostAsJsonAsync("pet/add", pet);
            }
        }
    }
}