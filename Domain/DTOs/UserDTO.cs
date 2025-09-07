using newapi.ownedtypes;

namespace newapi.domain.dtos;

public class UserDTO
{
    public UserDTO(string name, string email, string password, string profile)
    {
        Name = name;
        Email = new Email(email);
        Password = new Password(password);
        Profile = new Profile(profile);
    }

    public UserDTO(string name, Email email, Password password, Profile profile)
    {
        Name = name;
        Email = email;
        Password = password;
        Profile = profile;
    }

    public string Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Password Password { get; private set; } = default!;
    public Profile Profile { get; private set; } = default!;
}

public class UserDTOResponse
{
    public UserDTOResponse(Guid id, string name, Email email, string token, Profile profile, Guid petId)
    {
        Id = id;
        Name = name;
        Email = email;
        Token = token;
        Profile = profile;
        PetId = petId;
    }
    public Guid Id { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public string Token { get; private set; } = default!;
    public Profile Profile { get; private set; } = default!;
    public Guid PetId { get; private set; } = default!;
}
