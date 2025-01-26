using Alura.Adopet.Console.Comandos;
using FluentResults;

namespace Alura.Adopet.Testes
{
    public class HelpTeste
    {
        [Fact]
        public async void QuandoComandoNaoExistirDeveRetornarFalha()
        {
            //Arrange
            string? comando = "comandoInexistente";
            var help = new Help(comando);

            //Act
            var resultado = await help.ExecutarAsync();

            //Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.IsFailed);
            IError error = resultado.Errors[0];
            Assert.Equal("Comando não encontrado!", error.Message);
        }

        [Theory]
        [InlineData("help")]
        [InlineData("show")]
        [InlineData("list")]
        [InlineData("import")]
        public async void QuandoComandoExistirDeveRetornarSucesso(string comando)
        {
            //Arrange
            var help = new Help(comando);

            //Act
            var resultado = await help.ExecutarAsync();

            //Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.IsSuccess);
        }
    }
}