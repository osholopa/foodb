using Microsoft.AspNetCore.Mvc;

namespace FoodbWebAPI.Controllers
{
  [Route("/")]
  [ApiController]
  public class TestController: ControllerBase
  {
    [HttpGet("ping")]
    public ActionResult<string> PingPong() {
      return "pong";
    }
  }
}