namespace UserManagement.Services.Models
{
    public class ResponseDTO<T>
    {
        public bool IsSuccess { get; set; }

        public T Data { get; set; }
        public string Message { get; set; }
    }
}
