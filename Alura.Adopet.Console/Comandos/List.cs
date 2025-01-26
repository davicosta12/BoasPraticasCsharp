using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list",
documentacao: "adopet list <ARQUIVO> comando que exibe no terminal a lista de pets importados no sistema.")]
    public class List : IComando
    {
        private readonly HttpClientPet httpClientPet;

        public List(HttpClientPet httpClientPet)
        {
            this.httpClientPet = httpClientPet;
        }

        public async Task<Result> ExecutarAsync()
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
            IEnumerable<Pet>? listaDePets = await httpClientPet.ListPetsAsync();
            return Result.Ok().WithSuccess(new SuccessWithPets(listaDePets, "Importação da lista de pets foi Realizada com Sucesso!"));
        }
    }
}