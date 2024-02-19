using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetMvcApp.Models
{
    [Table("Tbl_Expense")]
    public class BudgetExpenseDataModel
    {
        [Key]
        public int ExpenseId { get; set; } 
        public int BudgetId { get; set; }
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
        public DateTime ExpenseDateTime { get; set; } = DateTime.Now;
    }
}
