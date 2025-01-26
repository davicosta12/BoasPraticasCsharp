using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;
using Alura.Adopet.Testes.Builders;
using Moq;

namespace Alura.Adopet.Testes
{
    public class ImportTeste
    {
        [Fact]
        public async void QuandoListaVaziaNaoDeveChamarCreatePetAsync()
        {
            //Arrange
            List<Pet> listaDePet = new();
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePet);

            var httpClientPet = HttpClientMockBuilder.GetMock();

            var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

            //Act
            await import.ExecutarAsync();

            //Assert
            httpClientPet.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
        }

        [Fact]
        public async void QuandoArquivoImportacaoNaoExistirDeveRetornarUmaFalha()
        {
            //Arrange
            List<Pet> listaDePet = new();
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePet);
            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Throws<FileNotFoundException>();

            var httpClientPet = HttpClientMockBuilder.GetMock();

            var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

            //Ac
            var resultado = await import.ExecutarAsync();

            //Assert
            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public async void QuandoPetEstiverNoArquivoDeveSerImportado()
        {
            //Arrange
            List<Pet> listaDePet = new();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
                 "Lima", TipoPet.Cachorro);
            listaDePet.Add(pet);

            var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePet);

            var httpClientPet = HttpClientMockBuilder.GetMock();

            var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

            //Act
            var resultado = await import.ExecutarAsync();

            //Assert
            Assert.True(resultado.IsSuccess);
            SuccessWithPets sucesso = (SuccessWithPets)resultado.Successes[0];
            Assert.Equal("Lima", sucesso.Data.First().Nome);
        }
    }
}