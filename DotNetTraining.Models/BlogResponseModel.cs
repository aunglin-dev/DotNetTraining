namespace DotNetTraining.Models
{
    public class BlogResponseModel : ResponseModel
    {
        public BlogModel Blog { get; set; }
    }

    public class BlogListResponseModel : ResponseModel
    {
        public List<BlogModel> Blogs { get; set; }
    }
}
