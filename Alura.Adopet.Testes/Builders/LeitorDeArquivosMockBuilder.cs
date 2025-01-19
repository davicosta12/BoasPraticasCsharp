using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Utils;
using Moq;

namespace Alura.Adopet.Testes.Builders
{
    public static class LeitorDeArquivosMockBuilder
    {
        // public static Mock<LeitorDeArquivo> GetMock(List<Pet> listDePet)
        // {
        //     Mock<LeitorDeArquivo> leitorDeArquivo = new(MockBehavior.Default, listDePet);

        //     return leitorDeArquivo;
        // }

        public static Mock<LeitorDeArquivo> GetMock(List<Pet> listaDePet)
        {
            Mock<LeitorDeArquivo> leitorDeArquivo = new(MockBehavior.Default, It.IsAny<string>());
            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

            return leitorDeArquivo;
        }
    }
}