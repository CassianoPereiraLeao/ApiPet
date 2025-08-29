using BCrypt.Net;

namespace newapi.ownedtypes;

public class Password
{
    public string _password { get; private set; } = default!;

    protected Password() { }

    public Password(string password)
    {
        _password = Validate(password);
    }

    private string Validate(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException("A senha não pode ser vazia");
        }

        if (password.Length < 8)
        {
            throw new ArgumentException("A senha deve conter mais de 8 caracteres");
        }

        return password;
    }

    public static string ToHash(Password password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password.ToString());
    }

    public bool Verify(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, _password);
    }

    public override string ToString()
    {
        return _password;
    }
}