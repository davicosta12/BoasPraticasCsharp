using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Moq;
using Moq.Protected;

namespace Alura.Adopet.Testes.Builders
{
    public static class HttpClientMockBuilder
    {
        public static Mock<HttpMessageHandler> CriaHttpClientMock(HttpResponseMessage response)
        {
            Mock<HttpMessageHandler> handlerMock = new();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            return handlerMock;
        }


        public static Mock<HttpClientPet> GetMock()
        {
            var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());

            return httpClientPet;
        }

        public static Mock<HttpClientPet> GetMockList(List<Pet> lista)
        {
            var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());
            httpClientPet.Setup(_ => _.ListPetsAsync())
                .ReturnsAsync(lista);
            return httpClientPet;
        }
    }
}