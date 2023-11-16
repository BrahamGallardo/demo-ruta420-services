using Demo.Ruta420.Application.Models;

namespace Demo.Ruta420.Application.Interfaces.Services
{
    public interface ISessionAsyncService
    {
        Task<SessionDto> GetSessionAsync(string email, string pwd);
    }
}
