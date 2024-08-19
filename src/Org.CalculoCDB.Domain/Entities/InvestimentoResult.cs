using System;

namespace Org.CalculoCDB.Domain.Entities
{
    public class InvestimentoResult
    {
        public InvestimentoResult(decimal bruto, decimal liquido, decimal taxa)
        {
            ValorBruto = bruto;
            ValorLiquido = liquido;
            ValorTaxa = taxa;
        }

        public Decimal ValorBruto { get; private set; }
        public Decimal ValorLiquido { get; private set; }
        public Decimal ValorTaxa { get; private set; }
    }
}
