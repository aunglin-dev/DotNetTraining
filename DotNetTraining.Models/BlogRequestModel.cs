namespace DotNetTraining.Models
{
    public class BlogRequestModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
