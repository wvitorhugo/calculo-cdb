using Org.CalculoCDB.Application.Services;
using Org.CalculoCDB.Domain.Entities;
using Org.CalculoCDB.Domain.Exceptions;
using Xunit;

namespace Org.CalculoCDB.Application.Test.Services
{
    public class InvestimentoCDBTests
    {
        private readonly InvestimentoCDB _calculator;

        public InvestimentoCDBTests()
        {
            _calculator = new InvestimentoCDB();
        }


        [Fact]
        public void Calcular_DeveRetornarExcecaoParaPrazoNegativo()
        {
            var request = new InvestimentoRequest
            {
                Valor = 1000m,
                PrazoEmMeses = -2
            };

            Assert.Throws<PrazoInvalidoParametroException>(() => _calculator.Calcular(request));
        }

        [Fact]
        public void Calcular_DeveRetornarExcecaoParaValorNegativo()
        {
            var request = new InvestimentoRequest
            {
                Valor = -1000m,
                PrazoEmMeses = 12
            };

            Assert.Throws<ValorInvalidoParametroException>(() => _calculator.Calcular(request));
        }

        [Fact]
        public void Calcular_DeveRetornarSucessoParaValoresPositivos()
        {
            // Arrange
            var request = new InvestimentoRequest
            {
                Valor = 1000m,
                PrazoEmMeses = 6
            };
            const decimal ValorBrutoEsperado = 1059.76m;
            const decimal ValorTaxaEsperado = 13.45m;
            const decimal ValorLiquidoEsperado = 1046.31m;
            // Act
            var result = _calculator.Calcular(request);

            // Assert
            Assert.Equal(ValorBrutoEsperado, result.ValorBruto, 2);
            Assert.Equal(ValorTaxaEsperado, result.ValorTaxa, 2);
            Assert.Equal(ValorLiquidoEsperado, result.ValorLiquido, 2);
        }

        [Fact]
        public void Calcular_DeveRetornarValorCorretoParaPrazoDe6Meses()
        {
            // Arrange
            var request = new InvestimentoRequest
            {
                Valor = 1000m,
                PrazoEmMeses = 6
            };
            const decimal ValorBrutoEsperado = 1059.76m;
            const decimal ValorTaxaEsperado = 13.45m;
            const decimal ValorLiquidoEsperado = 1046.31m;
            // Act
            var result = _calculator.Calcular(request);

            // Assert
            Assert.Equal(ValorBrutoEsperado, result.ValorBruto, 2);
            Assert.Equal(ValorTaxaEsperado, result.ValorTaxa, 2);
            Assert.Equal(ValorLiquidoEsperado, result.ValorLiquido, 2);
        }

        [Fact]
        public void Calcular_DeveRetornarValorCorretoParaPrazoDe12Meses()
        {
            // Arrange
            var request = new InvestimentoRequest
            {
                Valor = 1000m,
                PrazoEmMeses = 12
            };
            const decimal ValorBrutoEsperado = 1123.08m;
            const decimal ValorTaxaEsperado = 24.62m;
            const decimal ValorLiquidoEsperado = 1098.46m;

            // Act
            var result = _calculator.Calcular(request);

            // Assert
            Assert.Equal(ValorBrutoEsperado, result.ValorBruto, 2);
            Assert.Equal(ValorTaxaEsperado, result.ValorTaxa, 2);
            Assert.Equal(ValorLiquidoEsperado, result.ValorLiquido, 2);
        }

        [Fact]
        public void Calcular_DeveRetornarValorCorretoParaPrazoDe24Meses()
        {
            // Arrange
            var request = new InvestimentoRequest
            {
                Valor = 1000m,
                PrazoEmMeses = 24
            };
            const decimal ValorBrutoEsperado = 1261.31m;
            const decimal ValorTaxaEsperado = 45.73m;
            const decimal ValorLiquidoEsperado = 1215.58m;

            // Act
            var result = _calculator.Calcular(request);

            // Assert
            Assert.Equal(ValorBrutoEsperado, result.ValorBruto, 2);
            Assert.Equal(ValorTaxaEsperado, result.ValorTaxa, 2);
            Assert.Equal(ValorLiquidoEsperado, result.ValorLiquido, 2);
        }

        [Fact]
        public void Calcular_DeveRetornarValorCorretoParaPrazoDe36Meses()
        {
            // Arrange
            var request = new InvestimentoRequest
            {
                Valor = 1000m,
                PrazoEmMeses = 36
            };
            const decimal ValorBrutoEsperado = 1416.56m;
            const decimal ValorTaxaEsperado = 62.48m;
            const decimal ValorLiquidoEsperado = 1354.08m;

            // Act
            var result = _calculator.Calcular(request);

            // Assert
            Assert.Equal(ValorBrutoEsperado, result.ValorBruto, 2);
            Assert.Equal(ValorTaxaEsperado, result.ValorTaxa, 2);
            Assert.Equal(ValorLiquidoEsperado, result.ValorLiquido, 2);
        }
    }
}