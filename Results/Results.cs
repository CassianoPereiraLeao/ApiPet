using newapi.domain.entities;

namespace newapi.results;

public class UserResult
{
    public UserResult(bool Success, List<string?> Error, User? User)
    {
        this.Success = Success;
        this.Errors = Error;
        this.User = User;
    }
    public UserResult(bool Success, List<string?> Error)
    {
        this.Success = Success;
        this.Errors = Error;
    }
    public bool Success = default!;
    private readonly List<string?> Errors;
    public User? User { get; private set; }

    public List<string?> GetErrors()
    {
        return Errors;
    }
}
