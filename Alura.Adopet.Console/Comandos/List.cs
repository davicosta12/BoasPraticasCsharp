using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list",
documentacao: "adopet list <ARQUIVO> comando que exibe no terminal a lista de pets importados no sistema.")]
    public class List : IComando
    {
        HttpClientPet client;

        public List()
        {
            this.client = new("http://localhost:5057");
        }

        public async Task ExecutarAsync(string[] args)
        {
            await this.GetPetsAsync();
        }

        private async Task GetPetsAsync()
        {
            System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
            IEnumerable<Pet>? pets = await client.ListPetsAsync();
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}