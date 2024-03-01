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

                var userdata = await _dbcontext.Users.FirstOrDefaultAsync(u => u.UserName == reqModel.UserName && u.PhoneNumber == reqModel.PhoneNumber);
                UserResponseModel model = new UserResponseModel()
                {
                    IsSuccess = result > 0,
                    Message = message,
                    UserData = userdata.UserId
                };
                return Json(model);
            }
         
            return Json(new MessageModel(false, "This user is already exist"));
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
                return Json(new MessageModel(false, "This user doesn't exist."));
            }
            return Json(new MessageModel(true, "Login Successful."));
        }

        public async Task<IActionResult> CreateBudget(int id)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.UserId == id);
            return View(user);
        }

        public IActionResult Dashboard(int id)
        {
            var budget = (from b in _dbcontext.Budget
                         join u in _dbcontext.Users on b.UserId equals u.UserId 
                         join e in _dbcontext.Expense on b.BudgetId equals e.BudgetId
                         where u.UserId == id
                         select new BudgetResponseModel
                         {
                             UserId = id,
                             UserName = u.UserName,
                             BudgetId = b.BudgetId,
                             ExpenseId = e.ExpenseId,
                             BudgetName = b.BudgetName,
                             Budget = b.Budget,
                             ExpenseName = e.ExpenseName,
                             Amount = e.Amount,
                             ExpenseDateTime = e.ExpenseDateTime
                         });

            return View(budget);
        }

        public IActionResult BudgetDetail()
        {
            return View();
        }

    }
}
