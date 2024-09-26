using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Domain;
using Tag = WebApplication1.Models.Domain.Tag;
using WebApplication1.Models.ViewModals;
using Microsoft.AspNetCore.Components.Web;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly BloggieDbContext bloggieDbContext;
        private readonly List<BlogPost> blogPosts;
        private readonly List<Tag> tags;


        public HomeController(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
            this.blogPosts = new List<BlogPost>();
            this.tags = new List<Tag>();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var tag = bloggieDbContext.Tags.ToList();
            ViewBag.Tag = tag;
            var blogPost = bloggieDbContext.BlogPosts.ToList();
			ViewBag.blogPost = blogPost;
			return View(new AddBlogPostRequest());
        }
        [HttpPost]
		public IActionResult Index(AddBlogPostRequest addBlogPostRequest)
        {
            if(ModelState.IsValid)
            {
                var blogPost = new BlogPost
                {
                    Id = Guid.NewGuid(),
                    Handing = addBlogPostRequest.Heading,
                    PageTitle = addBlogPostRequest.PageTitle,
                    Content = addBlogPostRequest.Content,
                    ShortDescription = addBlogPostRequest.ShortDescription,
                    FeaturedImageUrl = addBlogPostRequest.FeaturedImageUrl,
                    UrlHandle = addBlogPostRequest.UrlHandle,
                    PublishedDate = addBlogPostRequest.PoblishedDate,
                    Author = addBlogPostRequest.Author,
                    Visiable = addBlogPostRequest.Visible,
                    TagId = addBlogPostRequest.TagId
                };
                bloggieDbContext.BlogPosts.Add(blogPost);
                bloggieDbContext.SaveChanges();
            }
            ViewBag.BlogPost = bloggieDbContext.BlogPosts.ToList();
            return View(addBlogPostRequest);
        }

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}