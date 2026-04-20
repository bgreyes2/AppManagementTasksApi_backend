using AppManagementTaskApi.Net.DTOs;

namespace AppManagementTaskApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUserServiceAsync();
        Task<UserDto?> GetUserByIdAsync(int id_user);
        Task<UserDto> CreateUserAsync(UserDto dto);
        Task<bool> UpdateUserAsync(int id_user, UserDto dto);
        Task<bool> DeleteUserAsync(int id_user);
    }
}