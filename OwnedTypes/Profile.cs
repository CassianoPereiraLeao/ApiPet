namespace newapi.ownedtypes;

public class Profile
{
    public string _profile { get; private set; } = default!;
    private static List<string> Profiles { get; set; } = ["adm", "user", "pet"];
    private string? ValidateError { get; set; } = null;

    protected Profile() { }
    public Profile(string profile)
    {
        _profile = profile;
        ValidateError = Validate(profile);
    }

    private string? Validate(string profile) 
    {
        var role = profile.ToLower();
        if (string.IsNullOrEmpty(role))
        {
            return "O campo profile não pode ser nulo";
        }

        if (!Profiles.Contains(role))
        {
            return "O campo profile não contém esse tipo";
        }

        return null;
    }

    public bool Exists() { return ValidateError == null; }

    public string? GetErrors() { return ValidateError; }

    public override string ToString()
    {
        return _profile;
    }
}