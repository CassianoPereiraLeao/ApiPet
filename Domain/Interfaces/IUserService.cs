using newapi.domain.dtos;
using newapi.results;

namespace newapi.domain.interfaces;

public interface IUserService
{
    Task<UserResult> GetAllUsers(int? page, string key);
    Task<UserResult> GetUserById(Guid id, string key);
    Task<UserResult> CreateUser(UserDTO userDTO, string key);
    Task<UserResult> Login(UserDTO userDTO);
    Task<UserResult> UpdateUser(Guid id, UserDTO? userDTO, string key);
}
