using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterestCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCodeController : ControllerBase
    {
        [HttpGet("/showmethecode")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public ActionResult<string> Get() =>
            new OkObjectResult("https://github.com/grecojoao/InterestCalculator");
    }
}