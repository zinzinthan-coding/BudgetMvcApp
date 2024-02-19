using BudgetMvcApp.EFDbContext;
using BudgetMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BudgetMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbcontext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext dbcontext, ILogger<HomeController> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CreateBudget()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult BudgetDetail()
        {
            return View();
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
