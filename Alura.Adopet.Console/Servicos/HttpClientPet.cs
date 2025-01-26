using System.Net.Http.Json;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos
{
    public class HttpClientPet
    {
        HttpClient client;

        public HttpClientPet(HttpClient client)
        {
            this.client = client;
        }

        public virtual async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }

        public virtual Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }
    }
}