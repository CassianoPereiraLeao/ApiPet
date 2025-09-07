using System.ComponentModel.DataAnnotations;
using newapi.ownedtypes;

namespace newapi.domain.entities;

public abstract class Login
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
    [Required]
    [StringLength(100)]
    [MinLength(3)]
    public string Name { get; private set; } = default!;
    public Profile Profile { get; private set; } = default!;

    public virtual void CreateName(string name)
    {
        Name = name;
    }

    public virtual void UpdateName(string name)
    {
        if (Name == name)
        {
            return;
        }
        Name = name;
    }

    public virtual string? CreateProfile(Profile profile)
    {
        if (!profile.Exists())
        {
            return profile.GetErrors();
        }

        Profile = profile;
        return null;
    }

    public virtual string? UpdateProfile(Profile profile)
    {
        if (Profile == profile)
        {
            return "O profile não pode ser igual ao anterior";
        }
        Profile = profile;
        return null;
    }
}