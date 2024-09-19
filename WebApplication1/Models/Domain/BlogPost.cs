namespace WebApplication1.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string Handing { get; set;}
        public string PageTitle { get; set; }
        public string Content{ get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public string Athor { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool Visiable { get; set; }
        
        public ICollection<Tag> tags { get; set; }
    }
}
