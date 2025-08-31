using newapi.domain.dtos;
using newapi.domain.entities;

namespace newapi.results;

public class UserResult
{
    public UserResult(bool Success, List<string?> Error, User? User)
    {
        this.Success = Success;
        Errors = Error;
        this.User = User;
    }
    public UserResult(bool Success, List<string?> Error)
    {
        this.Success = Success;
        Errors = Error;
    }

    public UserResult(bool Success, List<string?> Error, List<User> users)
    {
        this.Success = Success;
        Errors = Error;
        Users = users;
    }

    public UserResult(bool Success, List<string?> Error, List<UserDTOResponse> usersResponse)
    {
        this.Success = Success;
        Errors = Error;
        UsersResponse = usersResponse;
    }

    public bool Success = default!;
    private readonly List<string?> Errors = [];
    public User? User { get; private set; }
    public List<User> Users { get; private set; } = [];
    public List<UserDTOResponse> UsersResponse { get; private set; } = [];

    public List<string?> GetErrors()
    {
        return Errors;
    }
}
