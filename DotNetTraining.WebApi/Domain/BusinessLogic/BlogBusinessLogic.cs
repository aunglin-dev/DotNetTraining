using DotNetTraining.WebApi.Domain.DataAccess;

namespace DotNetTraining.WebApi.Domain.BusinessLogic
{
    public class BlogBusinessLogic : IBlogBusinessLogic
    {
        private readonly IBlogDataAccess _blogDataAccess;

        public BlogBusinessLogic(IBlogDataAccess blogDataAccess)
        {
            _blogDataAccess = blogDataAccess;
        }

        public async Task<BlogListResponseModel> GetBlogs(BlogRequestModel requestModel)
        {
            if (requestModel.PageNo == 0)
            {
                return new BlogListResponseModel
                {
                    RespCode = "888",
                    RespDesp = "Invalid Page No."
                };
            }
            if (requestModel.PageSize == 0)
            {
                return new BlogListResponseModel
                {
                    RespCode = "888",
                    RespDesp = "Invalid Page Size."
                };
            }

            return await _blogDataAccess.GetBlogs(requestModel);
        }
    }
}
