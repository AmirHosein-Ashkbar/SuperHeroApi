namespace SuperHeroApi.DTO
{
    public class BaseResponse<T>
    {
        public T? Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; } 
        public bool isSuccess { get; set; }
    }
}
