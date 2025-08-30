using newapi.domain.dtos;
using newapi.results;

namespace newapi.infra.interfaces;

public interface IUserService
{
    Task<UserResult> GetAllUsers();
    Task<UserResult> GetUserById(Guid id);
    Task<UserResult> CreateUser(UserDTO userDTO);
    Task<UserResult> Login(UserDTO userDTO);
}
