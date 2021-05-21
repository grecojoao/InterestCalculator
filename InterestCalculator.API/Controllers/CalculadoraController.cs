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
    public class CalculadoraController : ControllerBase
    {
        [HttpPost("/calculajuros")]
        [ProducesResponseType(typeof(decimal?), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(decimal?), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<decimal?>> Post(
            decimal? valorInicial, int? meses,
            [FromServices] InterestCalculatorHandler handler,
            CancellationToken cancellationToken)
        {
            var command = new CalculateInterestCommand(valorInicial, meses);
            var commandResult = (CommandResult)await handler.Handle(command, cancellationToken);
            return commandResult.Sucess ?
                new OkObjectResult((decimal?)commandResult.Data) :
                new BadRequestObjectResult((decimal?)null);
        }
    }
}