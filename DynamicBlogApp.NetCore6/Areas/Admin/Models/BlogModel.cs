namespace DynamicBlogApp.NetCore6.Areas.Admin.Models
{
    public class BlogModel
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public int WriterId { get; set; }
        public string WriterName { get; set; }
    }
}
