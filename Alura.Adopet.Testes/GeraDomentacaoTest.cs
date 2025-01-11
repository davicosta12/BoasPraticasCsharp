using System.Reflection;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Testes
{
    public class GeraDomentacaoTest
    {
        [Fact]
        public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
        {
            //Arrange
            Assembly assembleComoTipoDocComando = Assembly.GetAssembly(typeof(DocComando))!;

            //Act
            Dictionary<string, DocComando> dictionary = assembleComoTipoDocComando.ToDictionary();

            //Assert
            Assert.NotNull(dictionary);
            Assert.NotEmpty(dictionary);
            Assert.Equal(4, dictionary.Count);
        }
    }
}