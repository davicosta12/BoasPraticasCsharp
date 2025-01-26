using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Testes
{
    public class FabricaDeComandosTeste
    {
        [Fact]
        public void QuandoComandoNaoExistirDeveRetornarNulo()
        {
            //Arrange
            string[] argumentos = { "comandoInexistente" };

            //Act
            IComando? comando = FabricaDeComandos.CriarComando(argumentos);

            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmArrayDeArgumentosNuloDeveRetornarNulo()
        {
            //Arrange
            //Act
            IComando? comando = FabricaDeComandos.CriarComando(null);

            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmArrayVazioDeveRetornarNulo()
        {
            //Arrange
            string[] argumentos = { };

            //Act
            IComando? comando = FabricaDeComandos.CriarComando(argumentos);

            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoImport()
        {
            //Arrange
            string[] argumentos = { "import", "lista.csv" };

            //Act
            IComando? comando = FabricaDeComandos.CriarComando(argumentos);

            //Assert
            Assert.IsType<Import>(comando);
        }
    }
}