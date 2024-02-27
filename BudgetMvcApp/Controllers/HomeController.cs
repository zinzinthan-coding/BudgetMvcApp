using BudgetMvcApp.EFDbContext;
using BudgetMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BudgetMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbcontext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDataModel reqModel)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.UserName == reqModel.UserName && u.PhoneNumber == reqModel.PhoneNumber);
            if (user is null)
            {
                await _dbcontext.Users.AddAsync(reqModel);
                int result = await _dbcontext.SaveChangesAsync();
                string message = result > 0 ? "Create Successful" : "Create Failed";

                MessageModel model = new MessageModel(result > 0, message);
                return Json(model);
            }
            return Json( new MessageModel(false, "This user is already exist"));
        }

        //public IActionResult Login()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Login(UserDataModel reqModel)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.UserName == reqModel.UserName && u.PhoneNumber == reqModel.PhoneNumber);
            if (user is null)
            {
                return Json(new MessageModel(false, "This user doesn't exist"));
            }
            return Json(new MessageModel(true, "Login Successful"));
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

    }
}
