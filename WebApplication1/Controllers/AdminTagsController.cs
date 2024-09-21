using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models.ViewModals;

namespace WebApplication1.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BloggieDbContext bloggieDbContext;

        public AdminTagsController(BloggieDbContext bloggieDbContext) 
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagReauest) 
        {
            var tag = new Models.Domain.Tag
            {
                Name = addTagReauest.Name,
                DisplayName = addTagReauest.DisplayName
            };
            bloggieDbContext.Tags.Add(tag);
            return View("Add");
        }

        
    }
}
