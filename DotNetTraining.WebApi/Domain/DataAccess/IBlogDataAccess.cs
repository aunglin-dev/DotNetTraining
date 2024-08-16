namespace DotNetTraining.WebApi.Domain.DataAccess
{
    public interface IBlogDataAccess
    {
        Task<BlogListResponseModel> GetBlogs(BlogRequestModel requestModel);
    }
}