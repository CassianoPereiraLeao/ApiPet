namespace newapi.ownedtypes;

public class Password
{
    public string _password { get; private set; } = default!;
    private string? ValidateError { get; set; } = default!;

    protected Password() { }

    public Password(string password)
    {
        _password = password;
        ValidateError = Validate(password);
    }

    private string? Validate(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return "O campo senha não pode ser vazio";
        }

        if (password.Length < 8)
        {
            return "A senha deve conter no mínimo 8 caracteres";
        }

        return null;
    }

    public static string ToHash(Password password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password.ToString());
    }

    public bool IsValid() => ValidateError == null;

    public string? GetError() => ValidateError;

    public bool Verify(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, _password);
    }

    public override string ToString()
    {
        return _password;
    }
}