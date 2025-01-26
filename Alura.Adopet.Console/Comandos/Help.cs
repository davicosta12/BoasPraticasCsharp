using System.Reflection;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "help",
    documentacao: "adopet help <NOME_COMANDO> ou simplemente adopet help \n" +
    "adopet help <NOME_COMANDO> que exibe informações da ajuda.")]
    public class Help : IComando
    {
        private readonly Dictionary<string, DocComando> docs;
        private readonly string? comando;

        public Help(string? comando)
        {
            docs = Assembly.GetExecutingAssembly().ToDictionary();
            this.comando = comando;
        }

        public Task<Result> ExecutarAsync()
        {
            try
            {
                return Task.FromResult(Result.Ok()
                    .WithSuccess(new SuccessWithDocs(this.CreateHelpCommands())));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Result.Fail(new Error(ex.Message ?? "Exibição da documentação falhou!").CausedBy(ex)));
            }
        }

        private IEnumerable<string> CreateHelpCommands()
        {
            List<string> resultado = new();
            if (this.comando is null)
            {
                foreach (var doc in docs.Values)
                {
                    resultado.Add(doc.Documentacao);
                }
            }
            else
            {
                if (docs.ContainsKey(this.comando))
                {
                    var comando = docs[this.comando];
                    resultado.Add(comando.Documentacao);
                }
                else
                {
                    throw new ArgumentException("Comando não encontrado!");
                }
            }
            return resultado;
        }
    }
}