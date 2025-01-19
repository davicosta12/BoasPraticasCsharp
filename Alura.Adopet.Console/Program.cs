using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utils;

var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
var leitor = new LeitorDeArquivo(args[1]);
Dictionary<string, IComando> comandosDoSistema = new()
{
    {"help", new Help()},
    {"import", new Import(httpClientPet,leitor)},
    {"list", new List(httpClientPet)},
    {"show", new Show()},
};

Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0].Trim();
    IComando? comandoASerExecutado = comandosDoSistema[comando];
    if (comandoASerExecutado is not null) await comandoASerExecutado.ExecutarAsync(args);
    else Console.WriteLine("Comando inválido!");
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}