namespace BudgetMvcApp.Models
{
    public class BudgetExpenseDataModel
    {
        public int ExpenseId { get; set; } 
        public int BudgetId { get; set; }
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
        public DateTime ExpenseDateTime { get; set; } = DateTime.Now;
    }
}
