using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetMvcApp.Models
{
    [Table("Tbl_Users")]
    public class UserDataModel
    {
        [Key]
        public int UserId { get; set;}
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
