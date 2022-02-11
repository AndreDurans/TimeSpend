using TimeSpendForm.Models;

namespace TimeSpendForm.Services
{
    public interface ILogWorkService
    {
        Task<bool> NewLogWork(LogWork logWork);
    }
}
