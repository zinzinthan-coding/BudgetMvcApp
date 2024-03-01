namespace BudgetMvcApp.Models
{
    public class BudgetResponseModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int BudgetId { get; set; }
        public string BudgetName { get; set; }
        public int Budget { get; set; }
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public int Amount { get; set;}
        public DateTime ExpenseDateTime { get; set; }

    }
}
