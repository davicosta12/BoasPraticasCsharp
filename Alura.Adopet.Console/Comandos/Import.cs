using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "import",
documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]

    public class Import : IComando
    {
        private readonly HttpClientPet httpClientPet;
        private readonly LeitorDeArquivo leitor;

        public Import(HttpClientPet httpClientPet, LeitorDeArquivo leitorDeArquivo)
        {
            this.httpClientPet = httpClientPet;
            this.leitor = leitorDeArquivo;
        }

        public async Task<Result> ExecutarAsync()
        {
            try
            {
                return await this.ImportacaoArquivoPet();
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(ex));
            }
        }

        private async Task<Result> ImportacaoArquivoPet()
        {
            IEnumerable<Pet> listaDePet = leitor.RealizaLeitura();
            foreach (var pet in listaDePet)
            {
                await httpClientPet.CreatePetAsync(pet);
            }
            return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação Realizada com Sucesso!"));
        }
    }
}