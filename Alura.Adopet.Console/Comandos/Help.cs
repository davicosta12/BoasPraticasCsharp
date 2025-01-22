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
                return Task.FromResult(Result.Ok()
                    .WithSuccess(new SuccessWithDocs(this.CreateHelpCommands(parametros: args))));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Result.Fail(new Error("Exibição da documentação falhou!").CausedBy(ex)));
            }
        }

        private IEnumerable<string> CreateHelpCommands(string[] parametros)
        {
            List<string> resultado = new();
            if (parametros.Length == 1)
            {
                foreach (var doc in docs.Values)
                {
                    resultado.Add(doc.Documentacao);
                }
            }
            else if (parametros.Length == 2)
            {
                string comandoASerExibido = parametros[1];
                if (docs.ContainsKey(comandoASerExibido))
                {
                    var comando = docs[comandoASerExibido];
                    resultado.Add(comando.Documentacao);
                }
                else
                {
                    resultado.Add("Comando não encontrado!");
                }
            }
            return resultado;
        }
    }
}