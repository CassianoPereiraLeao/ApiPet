using newapi.ownedtypes;

namespace newapi.domain.dtos;

public class UserDTO
{
    public UserDTO(string name, string email, string password)
    {
        Name = name;
        Email = new Email(email);
        Password = new Password(password);
    }
    public string Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Password Password { get; private set; }
}

public class UserDTOResponse
{
    public UserDTOResponse(Guid id, string name, Email email, Guid petId)
    {
        Id = id;
        Name = name;
        Email = email;
        PetId = petId;
    }
    public Guid Id { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Guid PetId { get; private set; } = default!;
}
