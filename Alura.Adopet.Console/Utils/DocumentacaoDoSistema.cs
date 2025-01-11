using System.Reflection;
using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Console.Utils
{
    public static class DocumentacaoDoSistema
    {
        public static Dictionary<string, DocComando> ToDictionary(this Assembly assembleComoTipoDocComando)
        {
            return assembleComoTipoDocComando.GetTypes()
                 .Where(t => t.GetCustomAttributes<DocComando>().Any())
                 .Select(t => t.GetCustomAttribute<DocComando>()!)
                 .ToDictionary(d => d.Instrucao);
        }
    }
}