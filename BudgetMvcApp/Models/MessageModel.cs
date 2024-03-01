namespace BudgetMvcApp.Models
{
    public class MessageModel
    {
        public MessageModel()
        {
        }

        public MessageModel(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
      
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class UserResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int UserData { get; set; } 
        
    }
}
