using Org.CalculoCDB.Domain.Entities;
using Org.CalculoCDB.Domain.Exceptions;
using System;

namespace Org.CalculoCDB.Application.Services
{
    public class InvestimentoCDB : IInvestimento
    {
        private const decimal TaxaCDI = 0.009m;
        private const decimal TaxaTB = 1.08m;
        private const int PrecisaoCasaDecimal = 2;

        public InvestimentoResult Calcular(InvestimentoRequest request)
        {
            if (request.PrazoEmMeses <= 0)
            {
                throw new PrazoInvalidoParametroException();
            }
            if (request.Valor <= 0)
            {
                throw new ValorInvalidoParametroException();
            }
            decimal valorBruto = Math.Round(CalcularValorBruto(request.Valor, request.PrazoEmMeses), PrecisaoCasaDecimal);
            decimal valorTaxa = Math.Round(CalcularTaxa(request.PrazoEmMeses, valorBruto - request.Valor), PrecisaoCasaDecimal);
            decimal valorLiquido = Math.Round(valorBruto - valorTaxa, PrecisaoCasaDecimal);

            return new InvestimentoResult(valorBruto, valorLiquido, valorTaxa);
        }

        private decimal CalcularValorBruto(decimal valorInicial, int meses)
        {
            decimal amount = valorInicial;
            for (int i = 0; i < meses; i++)
            {
                amount *= (1 + (TaxaCDI * TaxaTB));
            }
            return amount;
        }

        private decimal CalcularTaxa(int meses, decimal profit)
        {
            decimal taxRate = GetImpostoTaxa(meses);
            return profit * taxRate;
        }

        private decimal GetImpostoTaxa(int meses)
        {
            if (meses <= 6) return 0.225m;
            if (meses <= 12) return 0.20m;
            if (meses <= 24) return 0.175m;
            return 0.15m;
        }
    }
}
