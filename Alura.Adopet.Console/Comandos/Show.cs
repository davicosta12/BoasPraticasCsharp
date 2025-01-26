using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show",
documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        private readonly LeitorDeArquivo leitor;

        public Show(LeitorDeArquivo leitor)
        {
            this.leitor = leitor;
        }

        public Task<Result> ExecutarAsync()
        {
            try
            {
                var result = this.ShowFileContent();
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(Result.Fail(new Error("Exibição do conteúdo do arquivo importado falhou!").CausedBy(ex)));
            }
        }

        private Result ShowFileContent()
        {
            var listaDePets = this.leitor.RealizaLeitura();
            return Result.Ok().WithSuccess(new SuccessWithPets(listaDePets, "A Exibição do conteúdo do arquivo importado foi Realizada com Sucesso!"));
        }
    }
}