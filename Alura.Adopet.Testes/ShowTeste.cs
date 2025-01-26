using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;
using Alura.Adopet.Testes.Builders;

namespace Alura.Adopet.Testes
{
    public class ShowTeste
    {
        [Fact]
        public async void QuandoArquivoImportacaoNaoExistirDeveRetornarUmaFalha()
        {
            //Arrange
            List<Pet> listaDePet = new();
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePet);
            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Throws<FileNotFoundException>();

            var show = new Show(leitorDeArquivo.Object);

            //Ac
            var resultado = await show.ExecutarAsync();

            //Assert
            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public async void QuandoArquivoImportacaoExistirDeveRetornarSucesso()
        {
            List<Pet> listaDePet = new();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
                 "Lima", TipoPet.Cachorro);
            listaDePet.Add(pet);

            var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePet);

            var show = new Show(leitorDeArquivo.Object);

            //Act
            var resultado = await show.ExecutarAsync();

            //Assert
            Assert.True(resultado.IsSuccess);
            SuccessWithPets sucesso = (SuccessWithPets)resultado.Successes[0];
            Assert.Single(sucesso.Data);
            Assert.Equal("A Exibição do conteúdo do arquivo importado foi Realizada com Sucesso!", sucesso.Message);
        }
    }
}