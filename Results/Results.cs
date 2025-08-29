using newapi.domain.entities;

namespace newapi.results;

public class UserResult
{
    public UserResult(bool Success, string? Error, User? User)
    {
        this.Success = Success;
        this.Error = Error;
        this.User = User;
    }
    public bool Success = default!;
    private readonly string? Error;
    public User? User { get; set; }

    public string? GetError()
    {
        return Error;
    }
}
