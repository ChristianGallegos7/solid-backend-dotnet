using backend_hdeleon.Models.DTOs.User;
using backend_hdeleon.Repository;

namespace backend_hdeleon.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserDto> Add(UserInsertDto userInsertDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return users.Select(u => new UserDto
            {
               
            });
        }

        public Task<UserDto> Update(int id, UserUpdateDto userUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
