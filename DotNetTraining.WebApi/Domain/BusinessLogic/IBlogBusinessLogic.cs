namespace DotNetTraining.WebApi.Domain.BusinessLogic
{
    public interface IBlogBusinessLogic
    {
        Task<BlogListResponseModel> GetBlogs(BlogRequestModel requestModel);
    }
}