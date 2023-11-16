using AutoMapper;
using Demo.Ruta420.Application.Common.Exceptions;
using Demo.Ruta420.Application.Common.Specifications.UserSpec;
using Demo.Ruta420.Application.Interfaces;
using Demo.Ruta420.Application.Interfaces.Services;
using Demo.Ruta420.Application.Models;
using Demo.Ruta420.Domain.Entities;

namespace Demo.Ruta420.Application.Services.UserService
{
    public class UserAsyncService : IUserAsyncService
    {
        private readonly IRepositoryAsyncArdalis<User> _repo;
        private readonly IMapper _mapper;

        public UserAsyncService(IRepositoryAsyncArdalis<User> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            try
            {
                List<User> users = await _repo.ListAsync(new GetByEmailSpecification(email));
                if (users.FirstOrDefault() == null)
                {
                    throw new NotFoundException("User", email);
                }
                UserDto userDto = _mapper.Map<UserDto>(users.FirstOrDefault());
                return userDto;
            }
            catch (Exception e)
            {
                var ex = e.InnerException ?? new Exception(e.Message);
                throw ex;
            }
        }
    }
}
