using Microsoft.AspNetCore.Mvc;

namespace mustakuusi_cs_aspnetcore.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ApplicationController : ControllerBase
    {
        [Route("{*url}", Order = int.MaxValue)]
        [HttpHead]
        public IActionResult RouteNotFoundHead()
        {
            return StatusCode(404);
        }
        
        [Route("{*url}", Order = int.MaxValue)]
        [HttpGet]
        [HttpPost]
        [HttpPut]
        [HttpDelete]
        [HttpPatch]
        [HttpOptions]
        public IActionResult RouteNotFound()
        {
            return NotFound(new { status = 404, message = "Not Found" });
        }
    }
}