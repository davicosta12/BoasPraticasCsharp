using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;
using Alura.Adopet.Testes.Builders;
using FluentResults;

namespace Alura.Adopet.Testes
{
    public class ListTeste
    {
        [Fact]
        public async void QuandoExecutarComandoListDeveRetornarListaDePets()
        {
            //Arrange
            List<Pet> listaDePet = new();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
                 "Lima", TipoPet.Cachorro);
            listaDePet.Add(pet);

            var httpClientPet = HttpClientMockBuilder.GetMockList(listaDePet);

            var list = new List(httpClientPet.Object);

            //Act
            Result result = await list.ExecutarAsync();

            //Assert
            var resultado = (SuccessWithPets)result.Successes[0];
            Assert.Single(resultado.Data);
        }
    }
}