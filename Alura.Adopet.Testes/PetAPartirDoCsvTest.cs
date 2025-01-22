using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;
using Xunit.Sdk;

namespace Alura.Adopet.Testes
{
    public class PetAPartirDoCsvTest
    {
        [Fact]
        public void QuandoStringForValidaDeveRetornaUmPet()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

            //Act
            Pet pet = linha.ConverteDoTexto();

            //Assert
            Assert.NotNull(pet);
        }

        [Fact]
        public async Task QuandoStringForNulaDeveRetornarUmaExcecao()
        {
            //Arrange
            string? linha = null;

            //Act+Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public async Task QuandoStringForVaziaDeveRetornarUmaExcecao()
        {
            //Arrange
            string linha = string.Empty;

            //Act+Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public async Task QuandoStringNaoTiverAQuantidadeSuficienteDeCamposDeveRetornarUmaExcecao()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;1";

            //Act+Assert
            Assert.ThrowsAny<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public async Task QuandoStringTiverUmGuidInvalidoDeveRetornarUmaExcecao()
        {
            //Arrange
            string linha = "dsa642df6q2e;Lima Limão;1";

            //Act+Assert
            Assert.ThrowsAny<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public async Task QuandoStringTiverUmTipoInvalidoDeveRetornarUmaExcecao()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;3";

            //Act+Assert
            Assert.ThrowsAny<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public async Task QuandoStringTiverUmTipoValidaDeveRetornarPetNaoNulo()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

            //Act
            Pet pet = linha.ConverteDoTexto();

            //Assert
            Assert.NotNull(pet);
        }
    }
}