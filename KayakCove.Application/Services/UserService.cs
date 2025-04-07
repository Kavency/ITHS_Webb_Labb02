using KayakCove.Application.DTOs;
using KayakCove.Domain.Entities;
using KayakCove.Infrastructure.Interfaces;

namespace KayakCove.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();

        var userDtos = users.Select(u => new UserDto
        {
            Id = u.Id,
            Username = u.Username,
            Password = u.Password,
            Firstname = u.Firstname,
            Lastname = u.Lastname,
            Email = u.Email,
            Streetaddress = u.Streetaddress,
            Postalcode = u.Postalcode,
            City = u.City,
            Country = u.Country,
            Phonenumber = u.Phonenumber,
            RoleId = u.RoleId,
            Role = u.Role
        });

        return userDtos;
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var entity = await _userRepository.GetUserByIdAsync(id);
        var userDto = ConvertEntityToDto(entity);
        return userDto;
    }

    public async Task<UserDto> AuthenticateUserAsync(string username, string password)
    {
        var entity = await _userRepository.AuthenticateUserAsync(username, password);
        
        if(entity is null)
        {
            return new UserDto();
        }
        return ConvertEntityToDto(entity);
    }

    public async Task<bool> CreateUserAsync(UserDto dto)
    {
        var user = ConvertDtoToEntity(dto);
        return await _userRepository.CreateUserAsync(user);
    }


    public async Task<bool> UpdateUserAsync(UserDto userDto)
    {
        var user = await _userRepository.GetUserByIdAsync(userDto.Id);

        user.Username = userDto.Username;
        user.Password = userDto.Password;
        user.Firstname = userDto.Firstname;
        user.Lastname = userDto.Lastname;
        user.Email = userDto.Email;
        user.Streetaddress = userDto.Streetaddress;
        user.Postalcode = userDto.Postalcode;
        user.City = userDto.City;
        user.Country = userDto.Country;
        user.Phonenumber = userDto.Phonenumber;
        user.RoleId = userDto.RoleId;

        return await _userRepository.UpdateUserAsync(user);
    }


    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }


    private UserDto ConvertEntityToDto(User entity)
    {
        if (entity is null)
        {
            return new UserDto();
        }

        return new UserDto
        {
            Id = entity.Id,
            Username = entity.Username,
            Password = entity.Password,
            Firstname = entity.Firstname,
            Lastname = entity.Lastname,
            Email = entity.Email,
            Streetaddress = entity.Streetaddress,
            Postalcode = entity.Postalcode,
            City = entity.City,
            Country = entity.Country,
            Phonenumber = entity.Phonenumber,
            RoleId = entity.RoleId,
            Role = entity.Role
        };
    }


    private User ConvertDtoToEntity(UserDto dto)
    {
        return new User
        {
            Id = dto.Id,
            Username = dto.Username,
            Password = dto.Password,
            Firstname = dto.Firstname,
            Lastname = dto.Lastname,
            Email = dto.Email,
            Streetaddress = dto.Streetaddress,
            Postalcode = dto.Postalcode,
            City = dto.City,
            Country = dto.Country,
            Phonenumber = dto.Phonenumber,
            RoleId = dto.RoleId
        };
    }
}
