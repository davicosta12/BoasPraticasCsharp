using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list",
documentacao: "adopet list <ARQUIVO> comando que exibe no terminal a lista de pets importados no sistema.")]
    public class List : IComando
    {
        HttpClientPet httpClientPet;

        public List(HttpClientPet httpClientPet)
        {
            this.httpClientPet = httpClientPet;
        }

        public async Task<Result> ExecutarAsync(string[] args)
        {
            try
            {
                return await this.GetPetsAsync();
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error("A importação da lista de pets do sistema falhou!").CausedBy(ex));
            }
        }

        private async Task<Result> GetPetsAsync()
        {
            System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
            IEnumerable<Pet>? pets = await httpClientPet.ListPetsAsync();
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
            return Result.Ok();
        }
    }
}