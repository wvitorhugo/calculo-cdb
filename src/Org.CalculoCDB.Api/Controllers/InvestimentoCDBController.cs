using Org.CalculoCDB.Application.Services;
using Org.CalculoCDB.Domain.Entities;
using Org.CalculoCDB.Domain.Exceptions;
using System; 
using System.Web.Http;
using System.Web.Http.Cors;

namespace Org.CalculoCDB.Api.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class InvestimentoCDBController : ApiController
    { 
        [HttpPost]
        public IHttpActionResult Post([FromBody] InvestimentoRequest requisicao)
        {
            try
            {
                IInvestimento _investimento = new InvestimentoCDB();
                InvestimentoResult resultado = _investimento.Calcular(new InvestimentoRequest
                {
                    Valor = requisicao.Valor,
                    PrazoEmMeses = requisicao.PrazoEmMeses
                });

                return Ok(resultado);
            }
            catch (ValorInvalidoParametroException ex)
            {
                return BadRequest("Valor deve ser um valor monetário positivo.");
            }
            catch (PrazoInvalidoParametroException ex)
            {
                return BadRequest("PrazoEmMeses deve ser maior que 1.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}