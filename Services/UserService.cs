using AppManagementTaskApi.Net.DTOs;
using AppManagementTaskApi.Net.Models.Entities;
using AppManagementTaskApi.Net.Repositories.Interfaces;
using AppManagementTaskApi.Services.Interfaces;
using Microsoft.Azure.Documents;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserDto>> GetUserServiceAsync()
    {
        var users = await _userRepository.GetUserAsync();

        return users.Select(u => new UserDto
        {
            id_user = u.id_user,
            name_user = u.name_user,
            email = u.email
        }).ToList();
    }


    public async Task<UserDto?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return null;

        return new UserDto
        {
            id_user = user.id_user,
            name_user = user.name_user,
            email = user.email
        };
    }


    public async Task<UserDto> CreateUserAsync(UserDto dto)
    {
        var user = new UserEntities  
        {
            name_user = dto.name_user,
            email = dto.email
        };

        var created = await _userRepository.CreateAsync(user);

        return new UserDto
        {
            id_user = created.id_user,
            name_user = created.name_user,
            email = created.email
        };
    }


    public async Task<bool> UpdateUserAsync(int id, UserDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return false;

        user.name_user = dto.name_user;
        user.email = dto.email;

        await _userRepository.UpdateAsync(user);

        return true;
    }


    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return false;

        await _userRepository.DeleteAsync(user);

        return true;
    }
}