using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Api.Controllers;
[Route("api/[controller]")]
[Authorize]
[ApiController]
public class HelloController : ControllerBase
{
    [HttpGet]
    public ActionResult get() {
        return Ok();
    }
}
