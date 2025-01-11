using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Testes;

public class UnitTest1
{
    [Fact]
    public async Task ListaPetsDeveRetornarUmaListaNaoVazia()
    {
        //Arrange
        var clientePet = new HttpClientPet(url: "http://localhost:5057");

        //Act
        var lista = await clientePet.ListPetsAsync();

        //Assert
        Assert.NotNull(lista);
        Assert.NotEmpty(lista);
    }

    [Fact]
    public async Task QuandoAPIForaDeveRetornarUmaExcecao()
    {
        //Arrange
        var clientePet = new HttpClientPet(url: "http://localhost:111");

        //Act+Assert
        await Assert.ThrowsAnyAsync<Exception>(() => clientePet.ListPetsAsync());
    }
}