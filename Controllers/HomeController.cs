using System;
using Microsoft.AspNetCore.Mvc;

namespace keylookup.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger/ui");
        }
    }
}