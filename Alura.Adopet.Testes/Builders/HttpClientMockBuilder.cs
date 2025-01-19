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
    }
}