namespace DotNetTraining.WebApi.Controllers;

[Route("api/blogs")]
[ApiController]
public class BlogController : BaseController
{
    private readonly IBlogBusinessLogic _blogBusinessLogic;

    public BlogController(IBlogBusinessLogic blogBusinessLogic)
    {
        _blogBusinessLogic = blogBusinessLogic;
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogsAsync([FromQuery] BlogRequestModel requestModel)
    {
        try
        {
            var model = await _blogBusinessLogic.GetBlogs(requestModel);
            return OkResult(model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseModel
            {
                RespCode = "999",
                RespDesp = ex.ToString()
            });
        }
    }
}
