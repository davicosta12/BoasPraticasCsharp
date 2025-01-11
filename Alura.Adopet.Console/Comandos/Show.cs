using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show",
documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        public Task ExecutarAsync(string[] args)
        {
            this.ShowFileContent(caminhoASerExibido: args[1]);
            return Task.CompletedTask;
        }

        private void ShowFileContent(string caminhoASerExibido)
        {
            LeitorDeArquivo leitor = new();
            var listaDePets = leitor.RealizaLeitura(caminhoASerExibido);

            foreach (var pet in listaDePets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}