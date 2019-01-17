using System;
using System.Diagnostics;
using System.Collections;
using System.Text;
using Microsoft.AspNetCore.Mvc;

using SEOParser.Models;
using SEOParser.Helpers;

namespace SEOParser.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Nothing to show now";
            return View();
        }

        [HttpPost]
        public IActionResult Index(String keyword, String url, string tryBrute)
        {

            MyGoogleApi api = new MyGoogleApi();
            ArrayList occurences = api.getSEO(url, keyword, 100, tryBrute == "true");

            ViewData["Message"] = String.Join('\n', occurences.ToArray());

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
