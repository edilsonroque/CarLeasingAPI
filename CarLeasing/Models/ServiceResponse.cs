namespace CarLeasing.Models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }
        public string Message { get; set; } = String.Empty;
        public bool Success { get; set; } = true;
    }
}
