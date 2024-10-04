namespace UserManagementAPI.Models
{
    public class ResponseDTO<T>
    {
        public ResponseDTO(T _data)
        {
            Data = _data;
        }

        public bool IsSuccess
        {
            get
            {
                return Error == null;
            }
        }
        public T Data { get; set; }
        public ErrorDTO Error { get; set; }
        public string Message { get; set; }
    }
}
