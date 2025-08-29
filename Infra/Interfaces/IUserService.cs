using newapi.domain.dtos;
using newapi.results;

namespace newapi.infra.interfaces;

public interface IUserService
{
    Task<UserResult> Login(UserDTO userDTO);
}
