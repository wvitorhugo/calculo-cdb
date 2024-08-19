using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Org.CalculoCDB.Application.Services;
using Org.CalculoCDB.Domain.Entities;
using Org.CalculoCDB.Domain.Exceptions;
using System;

namespace Org.CalculoCDB.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestimentoCDBController : ControllerBase
    { 
        private readonly IInvestimento _investimento;

        public InvestimentoCDBController(IInvestimento investimento)
        {
            _investimento = investimento;
        }

        [HttpPost]
        public IActionResult Post([FromBody] InvestimentoRequest requisicao)
        {
            try
            {
                InvestimentoResult resultado = _investimento.Calcular(new InvestimentoRequest
                {
                    Valor = requisicao.Valor,
                    PrazoEmMeses = requisicao.PrazoEmMeses
                });
                 
                return Ok(resultado);
            }
            catch (ValorInvalidoParametroException ex)
            {
                return BadRequest(new { Message = "Valor deve ser um valor monetário positivo." });
            }
            catch (PrazoInvalidoParametroException ex)
            {
                return BadRequest(new { Message = "PrazoEmMeses deve ser maior que 1." });
            }
            catch (Exception)
            { 
                return StatusCode(500, "Ocorreu um erro inesperado.");
            }
        }
    }
}
