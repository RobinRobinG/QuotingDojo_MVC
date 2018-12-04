using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quoting_dojo2.Models;
using DbConnection;

namespace quoting_dojo2.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        // Create a User
        [HttpPost]
        [Route("create")]
        public IActionResult AddQuote(string Name, string Quote)
        {
            // other code
            string query = $"INSERT INTO quotes (name, quote) VALUES ('{Name}', '{Quote}')";
            DbConnector.Execute(query);
            // other code
            return RedirectToAction("GetQuotes");
        }

        [HttpGet]
        [Route("/quotes")]
        public IActionResult GetQuotes()
        {
                var AllQuotes = DbConnector.Query("SELECT * FROM quotes");
                // To provide this data, we could use ViewBag or a View Model.  ViewBag shown here:
                ViewBag.all_quotes = AllQuotes;

                // System.Console.WriteLine(AllQuotes);
                return View("Quotes");
        }
    }
}
