using backend_hdeleon.Models.DTOs.User;

namespace backend_hdeleon.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();

        Task<UserDto> GetUserById(int id);

        Task<UserDto> Add(UserInsertDto userInsertDto);

        Task<UserDto> Update(int id, UserUpdateDto userUpdateDto);

        Task Delete(int id);
    }
}
