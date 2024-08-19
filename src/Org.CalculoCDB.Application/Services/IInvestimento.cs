using Org.CalculoCDB.Domain.Entities;

namespace Org.CalculoCDB.Application.Services
{
    public interface IInvestimento
    {
        InvestimentoResult Calcular(InvestimentoRequest request);
    }
}
