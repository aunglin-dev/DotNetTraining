using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DotNetTraining.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult OkResult(object requestModel)
        {
            JObject jObj = JObject.FromObject(requestModel);
            if (jObj["RespCode"]!.ToString() == "000")
            {
                return Ok(requestModel);
            }
            if (jObj["RespCode"]!.ToString() == "888")
            {
                return BadRequest(requestModel);
            }
            return StatusCode(500, requestModel);
        }
    }
}
