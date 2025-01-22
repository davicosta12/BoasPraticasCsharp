using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.UI;
using Alura.Adopet.Console.Utils;
using FluentResults;

var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));

string caminhoDoArquivoASerLido = args.Length > 1 && !string.IsNullOrEmpty(args[1]) ? args[1] : "";

var leitor = new LeitorDeArquivo(caminhoDoArquivo: caminhoDoArquivoASerLido);
Dictionary<string, IComando> comandosDoSistema = new()
{
    {"help", new Help()},
    {"import", new Import(httpClientPet,leitor)},
    {"list", new List(httpClientPet)},
    {"show", new Show()},
};

string comando = args[0].Trim();
IComando? comandoASerExecutado = comandosDoSistema[comando];
if (comandoASerExecutado is not null)
{
    Result result = await comandoASerExecutado.ExecutarAsync(args);
    ConsoleUI.ExibeResultado(result);
}
else
{
    ConsoleUI.ExibeResultado(Result.Fail("Comando inválido!"));
}