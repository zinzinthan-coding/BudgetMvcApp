namespace BudgetMvcApp.Models
{
    public class BudgetDataModel
    {
        public int BudgetId { get; set; }
        public int UserId { get; set; }
        public string BudgetName { get; set;}
        public int Budget { get; set; }
        public DateTime BudgetCreationDate { get; set; } = DateTime.Now;
    }
}
