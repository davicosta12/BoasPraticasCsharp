using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "help",
    documentacao: "adopet help <NOME_COMANDO> ou simplemente adopet help \n" +
    "adopet help <NOME_COMANDO> que exibe informações da ajuda.")]
    public class Help : IComando
    {
        private Dictionary<string, DocComando> docs;

        public Help()
        {
            docs = Assembly.GetExecutingAssembly().ToDictionary();
        }

        public Task<Result> ExecutarAsync(string[] args)
        {
            try
            {
                this.ShowHelpCommands(parametros: args);
                return Task.FromResult(Result.Ok());
            }
            catch (Exception ex)
            {
                return Task.FromResult(Result.Fail(new Error("Exibição da documentação falhou!").CausedBy(ex)));
            }
        }

        private void ShowHelpCommands(string[] parametros)
        {
            System.Console.WriteLine("Lista de comandos.");

            if (parametros.Length == 1)
            {
                System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine("Comando possíveis: ");

                foreach (var doc in docs.Values)
                {
                    System.Console.WriteLine(doc.Documentacao);
                }
            }
            else if (parametros.Length == 2)
            {
                string comandoASerExibido = parametros[1];
                if (docs.ContainsKey(comandoASerExibido))
                {
                    var comando = docs[comandoASerExibido];
                    System.Console.WriteLine(comando.Documentacao);
                }
            }
        }
    }
}