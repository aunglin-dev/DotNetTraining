using DotNetTraining.WebApi.Database;
using Microsoft.EntityFrameworkCore;

namespace DotNetTraining.WebApi.Domain.DataAccess
{
    public class BlogDataAccess : IBlogDataAccess
    {
        private readonly AppDbContext _db;

        public BlogDataAccess(AppDbContext db)
        {
            _db = db;
        }

        public async Task<BlogListResponseModel> GetBlogs(BlogRequestModel requestModel)
        {
            // select * from tbl_blog with (nolock)
            var lst = await _db.Blogs
                .AsNoTracking()
                .Skip((requestModel.PageNo - 1) * requestModel.PageSize)
                .Take(requestModel.PageSize)
                .ToListAsync();
            BlogListResponseModel model = new BlogListResponseModel
            {
                Blogs = lst.Select(x => new BlogModel
                {
                    Id = x.BlogId,
                    Title = x.BlogTitle,
                    Author = x.BlogAuthor,
                    Content = x.BlogContent,
                }).ToList(),
                RespCode = "000",
                RespDesp = "Success."
            };
            return model;
        }
    }
}
