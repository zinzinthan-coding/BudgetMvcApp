using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetMvcApp.Models
{
    [Table("Tbl_Budget")]
    public class BudgetDataModel
    {
        [Key]
        public int BudgetId { get; set; }
        public int UserId { get; set; }
        public string BudgetName { get; set;}
        public int Budget { get; set; }
        public DateTime BudgetCreationDate { get; set; } = DateTime.Now;
    }
}
