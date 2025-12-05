namespace ProjetoGusmaoFinal.Classes
{
    public class ApiResponse<Class> where Class : class
    {
        public List<Class> Data { get; set; } = [];
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = false;
    }
}
