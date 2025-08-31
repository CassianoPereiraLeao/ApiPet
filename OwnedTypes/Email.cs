using System.Text.RegularExpressions;

namespace newapi.ownedtypes;

public class Email
{
    public string _email { get; private set; } = default!;
    private string? ValidateError { get; set; } = default!;

    protected Email() { }

    public Email(string email)
    {
        _email = email;
        ValidateError = Validate(email);
    }

    private string? Validate(string email)
    {
        if (string.IsNullOrEmpty(_email))
        {
            return "O Email não pode ser vazio";
        }

        string pattern = @"^[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,}$";

        if (!Regex.IsMatch(_email, pattern))
        {
            return "Email inválido";
        }

        return null;
    }

    public bool IsValid() => ValidateError == null;
    public string? GetError() => ValidateError;

    public override string ToString()
    {
        return _email;
    }
}
