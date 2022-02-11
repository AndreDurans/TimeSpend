using System.Text;
using System.Text.Json;
using TimeSpendForm.Models;

namespace TimeSpendForm.Services
{
    public class LogWorkService : ILogWorkService
    {
        private readonly HttpClient _httpClient;

        public LogWorkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> NewLogWork(LogWork logWork)
        {
            var logWorkContent = new StringContent(
                    JsonSerializer.Serialize(logWork.Note)
                ,   Encoding.UTF8
                ,   "application/json");
            _httpClient.DefaultRequestHeaders.Add("PRIVATE-TOKEN", logWork.PersonalToken);

            var response = await _httpClient.PostAsync(logWork.Url, logWorkContent);

            return response.StatusCode == System.Net.HttpStatusCode.Created;
        }
    }
}
