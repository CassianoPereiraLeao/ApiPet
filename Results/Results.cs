using newapi.domain.dtos;

namespace newapi.results;

public class UserResult
{
    public UserResult(bool Success, List<string?> Error, UserDTOResponse? User)
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

    public UserResult(bool Success, List<string?> Error, List<UserDTOResponse> usersResponse)
    {
        this.Success = Success;
        Errors = Error;
        UsersResponse = usersResponse;
    }

    public bool Success = default!;
    private readonly List<string?> Errors = [];
    public UserDTO? userDTO { get; set; }
    public UserDTOResponse? User { get; private set; }
    public List<UserDTOResponse> UsersResponse { get; private set; } = [];
    public string Token { get; private set; } = default!;

    public string? SecurityToken(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return "failt";
        }

        Token = token;
        return null;
    }

    public List<string?> GetErrors()
    {
        return Errors;
    }

    public string GetToken()
    {
        return Token;
    }
}
