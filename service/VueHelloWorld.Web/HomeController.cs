using Microsoft.AspNetCore.Mvc;

namespace VueHelloWorld.Web
{
    [Route("api")]
    public class HomeController : Controller
    {
        public HomeController() { }

        public IActionResult Index()
        {
            return new OkObjectResult(new { Result = "Hello there test" });
        }
    }
}