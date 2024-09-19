using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminTagsController : Controller
    {
        // GET: AdminTagsController
        public IActionResult Add()
        {
            return View();
        }

        
    }
}
