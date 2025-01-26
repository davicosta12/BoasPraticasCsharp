using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Comandos
{
    public static class FabricaDeComandos
    {
        public static IComando? CriarComando(string[] argumentos)
        {
            if (argumentos is not null && argumentos.Count() > 0)
            {
                string comando = argumentos[0];
                switch (comando)
                {
                    case "import":
                        var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                        string caminhoDoArquivoASerLido = new(argumentos[1]);
                        var leitor = new LeitorDeArquivo(caminhoDoArquivo: caminhoDoArquivoASerLido);
                        return new Import(httpClientPet, leitor);
                    case "list":
                        var httpClientPetList = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                        return new List(httpClientPetList);
                    case "show":
                        string caminhoDoArquivoASerLidoShow = new(argumentos[1]);
                        var leitorShow = new LeitorDeArquivo(caminhoDoArquivo: caminhoDoArquivoASerLidoShow);
                        return new Show(leitorShow);
                    case "help":
                        var comandoASerExibido = argumentos.Length == 2 ? argumentos[1] : null;
                        return new Help(comandoASerExibido);
                    default: return null;
                }
            }

            return null;
        }
    }
}