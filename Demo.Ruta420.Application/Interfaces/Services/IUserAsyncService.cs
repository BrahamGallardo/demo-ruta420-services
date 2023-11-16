using Demo.Ruta420.Application.Models;

namespace Demo.Ruta420.Application.Interfaces.Services
{
    public interface IUserAsyncService
    {
        Task<UserDto> GetByEmailAsync(string email);
    }
}
