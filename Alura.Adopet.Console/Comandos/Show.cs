using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show",
documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        public Task<Result> ExecutarAsync(string[] args)
        {
            try
            {
                this.ShowFileContent(caminhoASerExibido: args[1]);
                return Task.FromResult(Result.Ok());
            }
            catch (Exception ex)
            {
                return Task.FromResult(Result.Fail(new Error("Exibição do conteúdo do arquivo importado falhou!").CausedBy(ex)));
            }
        }

        private void ShowFileContent(string caminhoASerExibido)
        {
            LeitorDeArquivo leitor = new LeitorDeArquivo(caminhoASerExibido);
            var listaDePets = leitor.RealizaLeitura();

            foreach (var pet in listaDePets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}