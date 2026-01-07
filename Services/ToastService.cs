namespace ProjetoGusmaoFinal.Services
{
    public class ToastService
    {
        public event Action? OnChange;

        public string Message { get; private set; } = string.Empty;
        public bool Success { get; private set; }

        public async Task Show(string message, bool success, int duration = 2000)
        {
            Message = message;
            Success = success;
            OnChange?.Invoke();

            await Task.Delay(duration);

            Message = string.Empty;
            OnChange?.Invoke();
        }
    }

}
