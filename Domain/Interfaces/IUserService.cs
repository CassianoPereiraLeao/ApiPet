using newapi.domain.dtos;
using newapi.results;

namespace newapi.domain.interfaces;

public interface IUserService
{
    Task<UserResult> GetAllUsers(int? page);
    Task<UserResult> GetUserById(Guid id);
    Task<UserResult> CreateUser(UserDTO userDTO);
    Task<UserResult> Login(UserDTO userDTO);
}
