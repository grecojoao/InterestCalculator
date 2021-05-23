using InterestCalculator.API.Responses;
using InterestCalculator.Domain.Commands;
using InterestCalculator.Domain.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace InterestCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        [HttpPost("/calculajuros")]
        [ProducesResponseType(typeof(RespostaRequisicao), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaRequisicao), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RespostaRequisicao>> Post(
            decimal? valorInicial, int? meses,
            [FromServices] InterestCalculatorHandler handler,
            CancellationToken cancellationToken)
        {
            var command = new CalculateInterestCommand(valorInicial, meses);
            var commandResult = (CommandResult)await handler.Handle(command, cancellationToken);
            return commandResult.Sucess ?
                new OkObjectResult(new RespostaRequisicao(true, commandResult.Message, (decimal?)commandResult.Data)) :
                new BadRequestObjectResult(new RespostaRequisicao(false, commandResult.Message, (decimal?)null));
        }
    }
}